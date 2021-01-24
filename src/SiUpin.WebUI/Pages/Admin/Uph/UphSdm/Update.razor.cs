using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.Provinsis.Queries.GetProvinsis;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.Shared.UphSdms.Commands;
using SiUpin.Shared.UphSdms.Queries;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphSdm
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

        public GetUphSdmResponse Entity { get; set; }
        public CreateUphSdmRequest Model { get; set; } = new CreateUphSdmRequest();
        public ApiResponse<CreateUphSdmResponse> Response { get; set; }

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

        public IList<SumberModal> SumberModals { get; set; } = new List<SumberModal>();
        public IList<SOP> SOPs { get; set; } = new List<SOP>();

        public IList<string> Tahuns { get; set; } = new List<string>();
        public string SelectTahuns
        {
            get => Model.tahun;
            set => Model.tahun = value;
        }

        public IList<string> StrukturModals { get; set; } = new List<string>();
        public string SelectStrukturModals
        {
            get => Model.struktur_modal;
            set => Model.struktur_modal = value;
        }

        public IList<string> Provinsis { get; set; } = new List<string>();
        public string SelectProvinsis
        {
            get => Model.lokasi;
            set => Model.lokasi = value;
        }

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Model);
        }

        protected async Task GetEntityByID()
        {
            IsLoading = true;

            Entity = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphSdmResponse>>
                ($"{Constants.URI.UphSdm.Base}/{EntityID}")).Result.Result;

            Model.UphSdmID = Entity.UphSdmID;

            await GetUphIDandNames();
            Model.UphID = Entity.UphID;
            SelectedUph = Entity.Uph.Name;

            Model.struktur_modal = Entity.struktur_modal;
            Model.jml_sdm = Entity.jml_sdm;
            Model.sumber_modals = Entity.sumber_modals;
            Model.sops = Entity.sops;
            Model.nama_pelatihan = Entity.nama_pelatihan;
            Model.penyelenggara = Entity.penyelenggara;
            Model.lokasi = Entity.lokasi;
            Model.tahun = Entity.tahun;

            GetTahuns();
            GetStrukturModals();
            GetSumberModals();
            GetSOPs();
            GetTahuns();
            await GetProvinsis();

            IsLoading = false;
            StateHasChanged();
        }

        private void HandleSumberModal(bool condition, int index)
        {
            SumberModals[index].IsChoosen = condition;

            if (condition)
            {
                Model.sumber_modals.Add(SumberModals[index].Name);
            }
            else
            {
                Model.sumber_modals.Remove(SumberModals[index].Name);
            }
        }

        private void HandleSOP(bool condition, int index)
        {
            SOPs[index].IsChoosen = condition;

            if (condition)
            {
                Model.sops.Add(SOPs[index].Name);
            }
            else
            {
                Model.sops.Remove(SOPs[index].Name);
            }
        }

        private async Task GetUphIDandNames() =>
            UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private void GetSumberModals()
        {
            foreach (var item in Constants.UphSdm.SumberModals)
                SumberModals.Add(new SumberModal { IsChoosen = false, Name = item });

            if (Model.sumber_modals.Count() > 0)
            {
                foreach (var item in SumberModals)
                    if (Model.sumber_modals.Any(x => x == item.Name))
                        item.IsChoosen = true;
            }
        }

        private void GetSOPs()
        {
            foreach (var item in Constants.UphSdm.SOPs)
                SOPs.Add(new SOP { IsChoosen = false, Name = item });

            if (Model.sops.Count() > 0)
            {
                foreach (var item in SOPs)
                    if (Model.sops.Any(x => x == item.Name))
                        item.IsChoosen = true;
            }
        }

        private void GetStrukturModals()
        {
            foreach (var item in Constants.UphSdm.StrukturModals)
                StrukturModals.Add(item);
        }

        private void GetTahuns()
        {
            foreach (var item in Constants.UphSdm.Tahuns)
                Tahuns.Add(item.ToString());
        }

        private async Task GetProvinsis() =>
            Provinsis = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetProvinsisResponse>>(Constants.URI.Region.GetProvinsis)).Result.Result.Data.Select(x => x.Name).ToList();

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PutAsJsonAsync(Constants.URI.UphSdm.Base, new CreateUphSdmRequest
                {
                    UphID = Model.UphID,
                    UphSdmID = Model.UphSdmID,

                    struktur_modal = Model.struktur_modal,
                    jml_sdm = Model.jml_sdm,
                    sumber_modals = Model.sumber_modals,
                    sops = Model.sops,
                    nama_pelatihan = Model.nama_pelatihan,
                    penyelenggara = Model.penyelenggara,
                    lokasi = Model.lokasi,
                    tahun = Model.tahun
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<CreateUphSdmResponse>>()).Result;

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

        public class SumberModal
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }

        public class SOP
        {
            public string Name { get; set; }
            public bool IsChoosen { get; set; }
        }
    }
}
