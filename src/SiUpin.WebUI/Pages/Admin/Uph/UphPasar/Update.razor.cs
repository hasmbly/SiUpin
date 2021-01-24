using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.UphPasars.Commands;
using SiUpin.Shared.UphPasars.Queries;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphPasar
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

        public GetUphPasarResponse Entity { get; set; }
        public CreateUphPasarRequest Model { get; set; } = new CreateUphPasarRequest();
        public ApiResponse<CreateUphPasarResponse> Response { get; set; }

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

        public void CancelClick() => DialogIsOpenStatus.InvokeAsync(false);

        public IList<Mekanisme> Mekanismes { get; set; } = new List<Mekanisme>();
        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();

        public IList<string> JangkauanPemasarans { get; set; } = new List<string>();
        public string SelectJangkauanPemasaran
        {
            get => Model.jangkauan;
            set => Model.jangkauan = value;
        }

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Model);
        }

        private async Task GetEntityByID()
        {
            IsLoading = true;

            Entity = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphPasarResponse>>
                ($"{Constants.URI.UphPasar.Base}/{EntityID}")).Result.Result;

            Model.UphPasarID = Entity.UphPasarID;

            await GetUphIDandNames();
            Model.UphID = Entity.UphID;
            SelectedUph = Entity.Uph.Name;

            Model.mekanismes = Entity.mekanismes;
            Model.lain = Entity.lain;
            Model.jangkauan = Entity.jangkauan;
            Model.jml_penjualan = Entity.jml_penjualan;
            Model.omset = Entity.omset;

            await GetUphIDandNames();

            GetMekanismes();
            GetJangkauanPemasarans();

            IsLoading = false;
            StateHasChanged();
        }

        private void HandleMekanisme(bool condition, int index)
        {
            Mekanismes[index].IsChoosen = condition;

            if (condition)
            {
                Model.mekanismes.Add(Mekanismes[index].Name);
            }
            else
            {
                Model.mekanismes.Remove(Mekanismes[index].Name);

                if (Mekanismes[index].Name == "Lainya")
                {
                    Model.lain = null;
                }
            }
        }

        private void GetMekanismes()
        {
            foreach (var item in Constants.UphPasar.Mekanismes)
                Mekanismes.Add(new Mekanisme { IsChoosen = false, Name = item });

            if (Model.mekanismes.Count() > 0)
            {
                foreach (var item in Mekanismes)
                    if (Model.mekanismes.Any(x => x == item.Name))
                        item.IsChoosen = true;
            }
        }

        private void GetJangkauanPemasarans()
        {
            foreach (var item in Constants.UphPasar.JangkauanPemasarans)
                JangkauanPemasarans.Add(item);
        }

        private async Task GetUphIDandNames() =>
            UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PutAsJsonAsync(Constants.URI.UphPasar.Base, new CreateUphPasarRequest
                {
                    UphPasarID = Model.UphPasarID,
                    UphID = Model.UphID,
                    mekanismes = Model.mekanismes,
                    lain = Model.lain,
                    jangkauan = Model.jangkauan,
                    jml_penjualan = Model.jml_penjualan,
                    omset = Model.omset
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<CreateUphPasarResponse>>()).Result;

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

        public class Mekanisme
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }
    }
}
