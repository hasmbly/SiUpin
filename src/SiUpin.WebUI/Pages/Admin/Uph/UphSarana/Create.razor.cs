using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.Shared.UphSaranas.Commands;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphSarana
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

        public CreateUphSaranaRequest Model { get; set; } = new CreateUphSaranaRequest();
        public ApiResponse<CreateUphSaranaResponse> Response { get; set; }

        private EditContext _editContext;

        private bool IsHidden = false;

        public void CancelClick() => DialogIsOpenStatus.InvokeAsync(false);

        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();

        public IList<AsalBantuan> AsalBantuans { get; set; } = new List<AsalBantuan>();
        public IList<Alasan> Alasans { get; set; } = new List<Alasan>();

        public IList<string> Tahuns { get; set; } = new List<string>();
        public string SelectTahuns
        {
            get => Model.tahun;
            set => Model.tahun = value;
        }

        public IList<string> JenisMesins { get; set; } = new List<string>();
        public string SelectJenisMesins
        {
            get => Model.jenis_mesin;
            set => Model.jenis_mesin = value;
        }

        public IList<string> Status { get; set; } = new List<string>();
        public string SelectStatus
        {
            get => Model.status;
            set => Model.status = value;
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
            GetTahuns();
            GetAsalBantuans();
            GetAlasans();
            GetJenisMesins();
            GetStatus();
            await GetSatuans();
        }

        private void HandleAsalBantuan(bool condition, int index)
        {
            AsalBantuans[index].IsChoosen = condition;

            if (condition)
            {
                Model.asal_bantuans.Add(AsalBantuans[index].Name);
            }
            else
            {
                Model.asal_bantuans.Remove(AsalBantuans[index].Name);
            }
        }

        private void HandleAlasan(bool condition, int index)
        {
            Alasans[index].IsChoosen = condition;

            if (condition)
            {
                Model.alasans.Add(Alasans[index].Name);
            }
            else
            {
                Model.alasans.Remove(Alasans[index].Name);
            }
        }

        private async Task GetUphIDandNames() =>
            UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private void GetAsalBantuans()
        {
            foreach (var item in Constants.UphSarana.AsalBantuans)
                AsalBantuans.Add(new AsalBantuan { IsChoosen = false, Name = item });
        }

        private void GetAlasans()
        {
            foreach (var item in Constants.UphSarana.Alasans)
                Alasans.Add(new Alasan { IsChoosen = false, Name = item });
        }

        private void GetJenisMesins()
        {
            foreach (var item in Constants.UphSarana.JenisMesins)
                JenisMesins.Add(item);
        }

        private void GetTahuns()
        {
            foreach (var item in Constants.UphSarana.Tahuns)
                Tahuns.Add(item.ToString());
        }

        private void GetStatus()
        {
            foreach (var item in Constants.UphSarana.Status)
                Status.Add(item);
        }

        private async Task GetSatuans() =>
            Satuans = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetSatuansResponse>>(Constants.URI.Satuan.Base)).Result.Result.Data.Select(x => x.Name).ToList();

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PostAsJsonAsync(Constants.URI.UphSarana.Register, new CreateUphSaranaRequest
                {
                    UphID = Model.UphID,

                    tahun = Model.tahun,
                    asal_bantuans = Model.asal_bantuans,
                    lain = Model.lain,
                    nama_alat = Model.nama_alat,
                    kapasitas_terpasang = Model.kapasitas_terpasang,
                    kapasitas_terpakai = Model.kapasitas_terpakai,
                    satuan = Model.satuan,
                    jenis_mesin = Model.jenis_mesin,
                    status = Model.status,
                    alasans = Model.alasans,
                    lain_alasan = Model.lain_alasan
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<CreateUphSaranaResponse>>()).Result;

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

        public class AsalBantuan
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }

        public class Alasan
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }
    }
}
