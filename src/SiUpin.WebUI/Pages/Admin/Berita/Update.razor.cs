using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorInputFile;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Beritas.Commands.UpdateBerita;
using SiUpin.Shared.Beritas.Queries.GetBerita;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Berita
{
    public partial class Update
    {
        public string _ID { get; set; }

        [Parameter]
        public string EntityID
        {
            get => _ID;
            set
            {
                if (_ID != value)
                {
                    _ID = value;

                    InvokeAsync(async () =>
                    {
                        await GetEntityByID();
                    });
                }
            }
        }

        [Parameter]
        public bool DialogIsOpen { get; set; } = false;

        [Parameter]
        public EventCallback<bool> DialogIsOpenStatus { get; set; }

        [Parameter]
        public EventCallback<bool> OnSuccessSubmit { get; set; }

        private bool IsLoading = false;
        public bool IsLoadingCircle { get; set; }
        public bool IsDisabledLoginButton { get; set; }

        public GetBeritaResponse Entity { get; set; }
        public UpdateBeritaRequest Model { get; set; } = new UpdateBeritaRequest();
        public ApiResponse<UpdateBeritaResponse> Response { get; set; }

        private EditContext _editContext;

        public IFileListEntry FileList;
        public string FileName;

        private void HandleFileListBlazor(IFileListEntry[] files)
        {
            FileList = files.FirstOrDefault();
            FileName = files.FirstOrDefault().Name;
        }

        public void CancelClick()
        {
            DialogIsOpenStatus.InvokeAsync(false);
        }

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Model);
        }

        private async Task GetEntityByID()
        {
            IsLoading = true;

            Entity = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetBeritaResponse>>($"{Constants.URI.Berita.Base}/{EntityID}")).Result.Result;

            Model.BeritaID = Entity.BeritaID;
            Model.Title = Entity.Title;
            Model.Description = Entity.Description;

            FileName = Entity.UrlOriginPhoto;

            IsLoading = false;
            StateHasChanged();
        }

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PutAsJsonAsync(Constants.URI.Berita.Base, new UpdateBeritaRequest
                {
                    BeritaID = Model.BeritaID,
                    Title = Model.Title,
                    Description = Model.Description
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<UpdateBeritaResponse>>()).Result;

                if (!Response.Status.IsError)
                {
                    await uploadFileAsync(Response.Result.BeritaID, Constants.FileEntityType.Berita);

                    IsLoadingCircle = false;

                    await DialogIsOpenStatus.InvokeAsync(false);

                    await OnSuccessSubmit.InvokeAsync(true);

                    StateHasChanged();
                }
                else
                {
                    Toaster.Add(Response.Status.Message, MatToastType.Danger);

                    IsLoadingCircle = false;
                    StateHasChanged();
                }
            }
            else
            {
                _editContext.AddDataAnnotationsValidation();
                Toaster.AddErrors(_editContext.GetValidationMessages());
            }
        }

        private async Task uploadFileAsync(string entityID, string entityType)
        {
            if (FileList != null)
            {
                var content = new MultipartFormDataContent();
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");

                content.Add(new StringContent(entityID), "EntityID");
                content.Add(new StringContent(entityType), "EntityType");

                content.Add(new StreamContent(FileList.Data, (int)FileList.Data.Length), "Files", FileList.Name);

                await Http.PostAsync(Constants.URI.File.Register, content);
            }
        }
    }
}
