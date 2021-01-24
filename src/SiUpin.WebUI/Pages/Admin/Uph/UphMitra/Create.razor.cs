using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.Shared.UphMitras.Commands;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphMitra
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

        public CreateUphMitraRequest Model { get; set; } = new CreateUphMitraRequest();
        public ApiResponse<CreateUphMitraResponse> Response { get; set; }

        private EditContext _editContext;

        public DateTime? awalPeriode
        {
            get => DateTime.Parse(Model.awal_periode);
            set => Model.awal_periode = value.Value.ToLocalTime().ToString();
        }

        public DateTime? akhirPeriode
        {
            get => DateTime.Parse(Model.akhir_periode);
            set => Model.akhir_periode = value.Value.ToLocalTime().ToString();
        }

        private bool IsHidden = false;

        public void CancelClick() => DialogIsOpenStatus.InvokeAsync(false);

        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();
        public IList<LembagaMitra> LembagaMitras { get; set; } = new List<LembagaMitra>();
        public IList<JenisMitra> JenisMitras { get; set; } = new List<JenisMitra>();
        public IList<Sarana> Saranas { get; set; } = new List<Sarana>();
        public IList<Promosi> Promosis { get; set; } = new List<Promosi>();
        public IList<Fasilitasi> Fasilitasis { get; set; } = new List<Fasilitasi>();

        public IList<string> Bermitras { get; set; } = new List<string>();
        public string SelectBermitra
        {
            get => Model.bermitra;
            set => Model.bermitra = value;
        }

        public IList<string> SasaranKemitraans { get; set; } = new List<string>();
        public string SelectSasaranKemitraan
        {
            get => Model.sasaran;
            set => Model.sasaran = value;
        }

        public IList<string> JenisUsahas { get; set; } = new List<string>();
        public string SelectJenisUsaha
        {
            get => Model.jenis_usaha;
            set => Model.jenis_usaha = value;
        }

        public IList<string> Satuans { get; set; } = new List<string>();
        public string SelectSatuan
        {
            get => Model.satuan_bahan;
            set => Model.satuan_bahan = value;
        }

        public IList<string> Kompetensis { get; set; } = new List<string>();
        public string SelectKompetensi
        {
            get => Model.detail_kopetensi;
            set => Model.detail_kopetensi = value;
        }

        public IList<string> Limbahs { get; set; } = new List<string>();
        public string SelectLimbah
        {
            get => Model.manajemen_limbah;
            set => Model.manajemen_limbah = value;
        }

        public IList<string> Perjanjians { get; set; } = new List<string>();
        public string SelectPerjanjian
        {
            get => Model.perjanjian;
            set => Model.perjanjian = value;
        }

        public IList<string> Status { get; set; } = new List<string>();
        public string SelectStatus
        {
            get => Model.status;
            set => Model.status = value;
        }

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(Model);

            Model.awal_periode = DateTime.Now.ToString();
            Model.akhir_periode = DateTime.Now.ToString();

            await GetUphIDandNames();
            GetLembagaMitras();
            GetJenisMitras();
            GetSaranas();
            GetPromosis();
            GetFasilitasis();
            await GetSatuans();
            GetKompetensis();
            GetLimbahs();
            GetBermitras();
            GetSasaranKemitraans();
            GetJenisUsahas();
            GetPerjanjians();
            GetStatus();
        }

        private void HandleLembagaMitras(bool condition, int index)
        {
            LembagaMitras[index].IsChoosen = condition;

            if (condition)
            {
                Model.lembagas.Add(LembagaMitras[index].Name);
            }
            else
            {
                Model.lembagas.Remove(LembagaMitras[index].Name);

                if (LembagaMitras[index].Name == "Lainya")
                {
                    Model.lembaga_lain = null;
                }
            }
        }

        private void HandleJenisMitras(bool condition, int index)
        {
            JenisMitras[index].IsChoosen = condition;

            if (condition)
            {
                Model.jenis_mitras.Add(JenisMitras[index].Name);
            }
            else
            {
                Model.jenis_mitras.Remove(JenisMitras[index].Name);

                switch (LembagaMitras[index].Name)
                {
                    case "Bahan baku":
                        Model.detail_bahan = null;
                        Model.satuan_bahan = null;
                        break;
                    case "Sarana Prasarana":
                        Model.detail_saranas = null;
                        break;
                    case "Peningkatan kompetensi":
                        Model.detail_kopetensi = null;
                        break;
                    case "Promosi dan pemasaran":
                        Model.detail_promosis = null;
                        break;
                    case "Fasilitasi":
                        Model.detail_fasilitasis = null;
                        break;
                    case "Manajemen Limbah":
                        Model.manajemen_limbah = null;
                        break;
                    default:
                        break;
                }
            }
        }

        private void HandleSaranas(bool condition, int index)
        {
            Saranas[index].IsChoosen = condition;

            if (condition)
            {
                Model.detail_saranas.Add(Saranas[index].Name);
            }
            else
            {
                Model.detail_saranas.Remove(Saranas[index].Name);
            }
        }

        private void HandlePromosis(bool condition, int index)
        {
            Promosis[index].IsChoosen = condition;

            if (condition)
            {
                Model.detail_promosis.Add(Promosis[index].Name);
            }
            else
            {
                Model.detail_promosis.Remove(Promosis[index].Name);
            }
        }

        private void HandleFasilitasis(bool condition, int index)
        {
            Fasilitasis[index].IsChoosen = condition;

            if (condition)
            {
                Model.detail_fasilitasis.Add(Fasilitasis[index].Name);
            }
            else
            {
                Model.detail_fasilitasis.Remove(Fasilitasis[index].Name);
            }
        }

        private async Task GetUphIDandNames()
            => UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private void GetLembagaMitras()
        {
            foreach (var item in Constants.UphMitra.LembagaBermitras)
                LembagaMitras.Add(new LembagaMitra { IsChoosen = false, Name = item });
        }

        private void GetJenisMitras()
        {
            foreach (var item in Constants.UphMitra.JenisMitras)
                JenisMitras.Add(new JenisMitra { IsChoosen = false, Name = item });
        }

        private void GetSaranas()
        {
            foreach (var item in Constants.UphMitra.DetailSaranas)
                Saranas.Add(new Sarana { IsChoosen = false, Name = item });
        }

        private void GetPromosis()
        {
            foreach (var item in Constants.UphMitra.DetailPromosis)
                Promosis.Add(new Promosi { IsChoosen = false, Name = item });
        }

        private void GetFasilitasis()
        {
            foreach (var item in Constants.UphMitra.DetailFasilitasis)
                Fasilitasis.Add(new Fasilitasi { IsChoosen = false, Name = item });
        }

        private async Task GetSatuans()
        {
            var result = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetSatuansResponse>>(Constants.URI.Satuan.Base))
                .Result.Result.Data.Select(x => x.Name).ToList();

            foreach (var item in result)
                Satuans.Add(item);
        }

        private void GetKompetensis()
        {
            foreach (var item in Constants.UphMitra.DetailKompetensis)
                Kompetensis.Add(item);
        }

        private void GetLimbahs()
        {
            foreach (var item in Constants.UphMitra.DetailLimbahs)
                Limbahs.Add(item);
        }

        private void GetBermitras()
        {
            foreach (var item in Constants.UphMitra.Bermitras)
                Bermitras.Add(item);
        }

        private void GetSasaranKemitraans()
        {
            foreach (var item in Constants.UphMitra.SasaranKemitraans)
                SasaranKemitraans.Add(item);
        }

        private void GetJenisUsahas()
        {
            foreach (var item in Constants.UphMitra.JenisUsahas)
                JenisUsahas.Add(item);
        }

        private void GetPerjanjians()
        {
            foreach (var item in Constants.UphMitra.Perjanjians)
                Perjanjians.Add(item);
        }

        private void GetStatus()
        {
            foreach (var item in Constants.UphMitra.Status)
                Status.Add(item);
        }

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PostAsJsonAsync(Constants.URI.UphMitra.Register, new CreateUphMitraRequest
                {
                    UphID = Model.UphID,

                    bermitra = Model.bermitra,
                    sasaran = Model.sasaran,
                    jenis_usaha = Model.jenis_usaha,

                    lembagas = Model.lembagas,
                    lembaga_lain = Model.lembaga_lain,

                    nama_perusahaan = Model.nama_perusahaan,
                    alamat = Model.alamat,
                    penanggungjawab = Model.penanggungjawab,
                    no_hp = Model.no_hp,

                    jenis_mitras = Model.jenis_mitras,
                    detail_bahan = Model.detail_bahan,
                    satuan_bahan = Model.satuan_bahan,

                    detail_saranas = Model.detail_saranas,
                    detail_kopetensi = Model.detail_kopetensi,
                    detail_promosis = Model.detail_promosis,
                    detail_fasilitasis = Model.detail_fasilitasis,
                    manajemen_limbah = Model.manajemen_limbah,

                    perjanjian = Model.perjanjian,
                    awal_periode = Model.awal_periode,
                    akhir_periode = Model.akhir_periode,
                    status = Model.status
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<CreateUphMitraResponse>>()).Result;

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

        public class LembagaMitra
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }

        public class JenisMitra
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }

        public class Sarana
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }

        public class Promosi
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }

        public class Fasilitasi
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }
    }
}