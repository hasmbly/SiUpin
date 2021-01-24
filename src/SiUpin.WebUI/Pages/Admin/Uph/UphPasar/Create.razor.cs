using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.UphPasars.Commands;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphPasar
{
    public partial class Create
    {
        [Parameter]
        public bool DialogIsOpen { get; set; } = false;

        [Parameter]
        public EventCallback<bool> DialogIsOpenStatus { get; set; }

        [Parameter]
        public EventCallback<bool> OnSuccessSubmit { get; set; }

        private bool IsLoading = false;
        public bool IsLoadingCircle { get; set; }

        public CreateUphPasarRequest Model { get; set; } = new CreateUphPasarRequest();
        public ApiResponse<CreateUphPasarResponse> Response { get; set; }

        private EditContext _editContext;

        private bool IsHidden = false;

        public void CancelClick() => DialogIsOpenStatus.InvokeAsync(false);

        public IList<Mekanisme> Mekanismes { get; set; } = new List<Mekanisme>();
        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();


        public IList<string> JangkauanPemasarans { get; set; } = new List<string>();
        public string SelectJangkauanPemasaran
        {
            get => Model.jangkauan;
            set => Model.jangkauan = value;
        }

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(Model);

            await GetUphIDandNames();
            GetMekanismes();
            GetJangkauanPemasarans();
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
        }

        private void GetJangkauanPemasarans()
        {
            foreach (var item in Constants.UphPasar.JangkauanPemasarans)
                JangkauanPemasarans.Add(item);
        }

        private async Task GetUphIDandNames()
            => UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PostAsJsonAsync(Constants.URI.UphPasar.Register, new CreateUphPasarRequest
                {
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
