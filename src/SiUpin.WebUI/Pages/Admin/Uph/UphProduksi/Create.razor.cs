using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.ParameterJawabans.Queries.GetParameterJawabansByIndikatorName;
using SiUpin.Shared.ProdukOlahans.Queries.GetProdukOlahans;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.Shared.UphProduksis.Commands;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphProduksi
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

        public CreateUphProduksiRequest Model { get; set; } = new CreateUphProduksiRequest();
        public ApiResponse<CreateUphProduksiResponse> Response { get; set; }

        private EditContext _editContext;

        private bool IsHidden = false;

        public void CancelClick() => DialogIsOpenStatus.InvokeAsync(false);

        public IList<Sertifikat> Sertifikats { get; set; } = new List<Sertifikat>();
        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();

        public IList<string> JumlahHariProduksis { get; set; } = new List<string>();
        public string SelectJumlahHariProduksi
        {
            get => Model.jml_hari_produksi;
            set => Model.jml_hari_produksi = value;
        }

        public IList<string> IzinEdars { get; set; } = new List<string>();
        public string SelectIzinEdar
        {
            get => Model.izin_edar;
            set => Model.izin_edar = value;
        }

        public IList<string> ProdukOlahans { get; set; } = new List<string>();
        public string SelectProdukOlahans
        {
            get => Model.bahan_baku;
            set => Model.bahan_baku = value;
        }

        public IList<string> Satuans { get; set; } = new List<string>();
        public string SelectSatuans
        {
            get => Model.satuan;
            set => Model.satuan = value;
        }

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(Model);

            await GetUphIDandNames();
            GetSertifikats();
            await GetProdukOlahans();
            await GetSatuans();
            await GetJumlahHariProduksis();
            await GetIzinEdars();
        }

        private void HandleSertifikat(bool condition, int index)
        {
            Sertifikats[index].IsChoosen = condition;

            if (condition)
            {
                Model.sertifikats.Add(Sertifikats[index].Name);
            }
            else
            {
                Model.sertifikats.Remove(Sertifikats[index].Name);
            }
        }

        private async Task GetUphIDandNames() =>
            UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private void GetSertifikats()
        {
            foreach (var item in Constants.UphProduksi.Sertifikats)
                Sertifikats.Add(new Sertifikat { IsChoosen = false, Name = item });
        }

        private async Task GetProdukOlahans() =>
            ProdukOlahans = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetProdukOlahansResponse>>(Constants.URI.ProdukOlahan.Base)).Result.Result.Data.Select(x => x.Name).ToList();

        private async Task GetSatuans() =>
            Satuans = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetSatuansResponse>>(Constants.URI.Satuan.Base)).Result.Result.Data.Select(x => x.Name).ToList();

        private async Task GetJumlahHariProduksis()
        {
            var result = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetParameterJawabansByIndikatorNameResponse>>
                ($"{Constants.URI.ParameterJawaban.ByIndikatorName}" + $"{Constants.ParameterIndikator.ParameterIndikatorName.JumlahHariProduksi}")).Result.Result.ParameterJawabans.Select(x => x.Name).ToList();

            foreach (var item in result)
                JumlahHariProduksis.Add(item);
        }

        private async Task GetIzinEdars()
        {
            var result = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetParameterJawabansByIndikatorNameResponse>>
                ($"{Constants.URI.ParameterJawaban.ByIndikatorName}" + $"{Constants.ParameterIndikator.ParameterIndikatorName.IzinEdar}")).Result.Result.ParameterJawabans.Select(x => x.Name).ToList();

            foreach (var item in result)
                IzinEdars.Add(item);
        }

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PostAsJsonAsync(Constants.URI.UphProduksi.Register, new CreateUphProduksiRequest
                {
                    UphID = Model.UphID,

                    sertifikats = Model.sertifikats,
                    izin_edar = Model.izin_edar,
                    jml_hari_produksi = Model.jml_hari_produksi,
                    jml_produksi = Model.jml_produksi,
                    satuan = Model.satuan,
                    bahan_baku = Model.bahan_baku
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<CreateUphProduksiResponse>>()).Result;

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

        public class Sertifikat
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }
    }
}
