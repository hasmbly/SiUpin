using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.ParameterJawabans.Queries.GetParameterJawabansByIndikatorName;
using SiUpin.Shared.UphGmps.Commands;
using SiUpin.Shared.UphGmps.Queries;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphGmp
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

        public GetUphGmpResponse Entity { get; set; }
        public UpdateUphGmpRequest Model { get; set; } = new UpdateUphGmpRequest();
        public ApiResponse<UpdateUphGmpResponse> Response { get; set; }

        private EditContext _editContext;

        private bool IsHidden = false;

        public string _uph { get; set; }
        public string SelectedUph
        {
            get => _uph;
            set
            {
                _uph = value;

                if (!string.IsNullOrEmpty(value))
                    Model.UphID = UphIDandNames.FirstOrDefault(x => x.Name == value).UphID;
            }
        }

        public void CancelClick()
        {
            DialogIsOpenStatus.InvokeAsync(false);
        }

        public IList<Gmp> Gmps { get; set; } = new List<Gmp>();
        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Model);
        }

        private async Task GetEntityByID()
        {
            IsLoading = true;

            Entity = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphGmpResponse>>($"{Constants.URI.UphGmp.Base}/{EntityID}")).Result.Result;

            Model.UphGmpID = Entity.UphGmpID;

            await GetUphIDandNames();
            Model.UphID = Entity.UphID;
            SelectedUph = Entity.Uph.Name;

            await GetNamaGmps();

            if (Entity.nama_gmps.Count() > 0)
            {
                if (Gmps.Count() > 0)
                {
                    foreach (var nama_gmp in Entity.nama_gmps)
                    {
                        if (!string.IsNullOrEmpty(nama_gmp))
                            Gmps.FirstOrDefault(x => x.NamaGmp == nama_gmp).IsGmpChoosen = true;
                    }
                }
            }

            IsLoading = false;
            StateHasChanged();
        }

        private void HandleNamaGmp(bool condition, int index)
        {
            Gmps[index].IsGmpChoosen = condition;

            if (condition)
            {
                Model.nama_gmps.Add(Gmps[index].NamaGmp);
            }
            else
            {
                Model.nama_gmps.Remove(Gmps[index].NamaGmp);
            }
        }

        private async Task GetNamaGmps()
        {
            var result = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetParameterJawabansByIndikatorNameResponse>>
                ($"{Constants.URI.ParameterJawaban.ByIndikatorName}" +
                $"{Constants.ParameterIndikator.ParameterIndikatorName.KesesuaianDenganGMP}")).Result.Result.ParameterJawabans.Select(x => x.Name).ToList();

            foreach (var item in result)
            {
                Gmps.Add(new Gmp { IsGmpChoosen = false, NamaGmp = item });
            }
        }

        private async Task GetUphIDandNames()
            => UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PutAsJsonAsync(Constants.URI.UphGmp.Base, new UpdateUphGmpRequest
                {
                    UphGmpID = Model.UphGmpID,
                    UphID = Model.UphID,

                    nama_gmps = Model.nama_gmps,
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<UpdateUphGmpResponse>>()).Result;

                if (!Response.Status.IsError)
                {
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

        public class Gmp
        {
            public string NamaGmp { get; set; }
            public bool IsGmpChoosen { get; set; }
        }
    }
}
