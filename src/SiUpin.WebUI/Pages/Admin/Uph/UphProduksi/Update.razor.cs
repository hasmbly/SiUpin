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
using SiUpin.Shared.UphProduksis.Queries;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphProduksi
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

        public GetUphProduksiResponse Entity { get; set; }
        public CreateUphProduksiRequest Model { get; set; } = new CreateUphProduksiRequest();
        public ApiResponse<CreateUphProduksiResponse> Response { get; set; }

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

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Model);
        }

        protected async Task GetEntityByID()
        {
            IsLoading = true;

            Entity = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphProduksiResponse>>
                ($"{Constants.URI.UphProduksi.Base}/{EntityID}")).Result.Result;

            Model.UphProduksiID = Entity.UphProduksiID;

            await GetUphIDandNames();
            Model.UphID = Entity.UphID;
            SelectedUph = Entity.Uph.Name;

            Model.sertifikats = Entity.sertifikats;
            Model.izin_edar = Entity.izin_edar;
            Model.jml_hari_produksi = Entity.jml_hari_produksi;
            Model.jml_produksi = Entity.jml_produksi;
            Model.satuan = Entity.satuan;
            Model.bahan_baku = Entity.bahan_baku;

            await GetUphIDandNames();
            GetSertifikats();
            await GetProdukOlahans();
            await GetSatuans();
            await GetJumlahHariProduksis();
            await GetIzinEdars();

            IsLoading = false;
            StateHasChanged();
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

            if (Model.sertifikats.Count() > 0)
            {
                foreach (var item in Sertifikats)
                    if (Model.sertifikats.Any(x => x == item.Name))
                        item.IsChoosen = true;
            }
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

                var client = await Http.PutAsJsonAsync(Constants.URI.UphProduksi.Base, new CreateUphProduksiRequest
                {
                    UphProduksiID = Model.UphProduksiID,
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
