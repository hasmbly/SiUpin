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
using SiUpin.Shared.UphSaranas.Queries;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphSarana
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

        public GetUphSaranaResponse Entity { get; set; }
        public UpdateUphSaranaRequest Model { get; set; } = new UpdateUphSaranaRequest();
        public ApiResponse<CreateUphSaranaResponse> Response { get; set; }

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

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Model);
        }

        protected async Task GetEntityByID()
        {
            IsLoading = true;

            Entity = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphSaranaResponse>>
                ($"{Constants.URI.UphSarana.Base}/{EntityID}")).Result.Result;

            Model.UphSaranaID = Entity.UphSaranaID;

            await GetUphIDandNames();
            Model.UphID = Entity.UphID;
            SelectedUph = Entity.Uph.Name;

            Model.tahun = Entity.tahun;
            Model.asal_bantuans = Entity.asal_bantuans;
            Model.lain = Entity.lain;
            Model.nama_alat = Entity.nama_alat;
            Model.kapasitas_terpasang = Entity.kapasitas_terpasang;
            Model.kapasitas_terpakai = Entity.kapasitas_terpakai;
            Model.satuan = Entity.satuan;
            Model.jenis_mesin = Entity.jenis_mesin;
            Model.status = Entity.status;
            Model.alasans = Entity.alasans;
            Model.lain_alasan = Entity.lain_alasan;

            GetTahuns();
            GetAsalBantuans();
            GetAlasans();
            GetJenisMesins();
            GetStatus();
            await GetSatuans();

            IsLoading = false;
            StateHasChanged();
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

            if (Model.asal_bantuans.Count() > 0)
            {
                foreach (var item in AsalBantuans)
                    if (Model.asal_bantuans.Any(x => x == item.Name))
                        item.IsChoosen = true;
            }
        }

        private void GetAlasans()
        {
            foreach (var item in Constants.UphSarana.Alasans)
                Alasans.Add(new Alasan { IsChoosen = false, Name = item });

            if (Model.alasans.Count() > 0)
            {
                foreach (var item in Alasans)
                    if (Model.alasans.Any(x => x == item.Name))
                        item.IsChoosen = true;
            }
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

                var client = await Http.PutAsJsonAsync(Constants.URI.UphSarana.Base, new CreateUphSaranaRequest
                {
                    UphID = Model.UphID,
                    UphSaranaID = Model.UphSaranaID,

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
