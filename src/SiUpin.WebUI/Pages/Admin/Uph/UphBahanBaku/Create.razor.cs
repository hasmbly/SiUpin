using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.JenisKomiditis.Common.GetAllJenisKomiditi;
using SiUpin.Shared.JenisKomiditis.Queries.GetAllJenisKomiditi;
using SiUpin.Shared.JenisTernaks.Queries.Common;
using SiUpin.Shared.JenisTernaks.Queries.GetJenisTernaks;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.Shared.UphBahanBakus.Commands;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphBahanBaku
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
        public bool IsDisabledLoginButton { get; set; }

        public CreateUphBahanBakuRequest Model { get; set; } = new CreateUphBahanBakuRequest();
        public ApiResponse<CreateUphBahanBakuResponse> Response { get; set; }

        private EditContext _editContext;

        public IList<JenisTernakDTO> JenisTernaks { get; set; } = new List<JenisTernakDTO>();
        public string SelectJenisTernak
        {
            get => Model.JenisTernakID;
            set => Model.JenisTernakID = value;
        }

        public IList<JenisKomoditiDTO> JenisKomoditis { get; set; } = new List<JenisKomoditiDTO>();
        public string SelectJenisKomoditi
        {
            get => Model.JenisKomoditiID;
            set => Model.JenisKomoditiID = value;
        }

        public IList<SatuanDTO> Satuans { get; set; } = new List<SatuanDTO>();
        public string SelectSatuan
        {
            get => Model.SatuanID;
            set => Model.SatuanID = value;
        }

        public bool AsalBahanBaku_00 { get; set; }
        public bool SelectedAsalBahanBaku_00
        {
            get => AsalBahanBaku_00;
            set
            {
                AsalBahanBaku_00 = value;

                HandleAsalBahanBaku_00(value);
            }
        }

        public bool AsalBahanBaku_01 { get; set; }
        public bool SelectedAsalBahanBaku_01
        {
            get => AsalBahanBaku_01;
            set
            {
                AsalBahanBaku_01 = value;

                HandleAsalBahanBaku_01(value);
            }
        }

        private string asalBahanBaku_00 = Constants.UphBahanBaku.AsalBahanBakus[0];
        private string asalBahanBaku_01 = Constants.UphBahanBaku.AsalBahanBakus[1];
        
        private bool IsHidden = false;

        public void CancelClick()
        {
            DialogIsOpenStatus.InvokeAsync(false);
        }

        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();
        public IList<string> AsalBahanBakus { get; set; } = new List<string>();

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(Model);

            await GetJenisTernaks();
            await GetJenisKomoditis();
            await GetSatuans();
            await GetUphIDandNames();

            StateHasChanged();
        }

        private void HandleAsalBahanBaku_00(bool condition)
        {
            if (condition)
            {
                Model.AsalBahanBakus.Add(asalBahanBaku_00);
            }
            else
            {
                Model.AsalBahanBakus.Remove(asalBahanBaku_00);
            }
        }

        private void HandleAsalBahanBaku_01(bool condition)
        {
            if (condition)
            {
                Model.AsalBahanBakus.Add(asalBahanBaku_01);
            }
            else
            {
                Model.AsalBahanBakus.Remove(asalBahanBaku_01);
            }
        }

        private async Task GetJenisTernaks()
            => JenisTernaks = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetJenisTernaksResponse>>(Constants.URI.JenisTernak.Base)).Result.Result.Data.ToList();

        private async Task GetJenisKomoditis()
             => JenisKomoditis = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetAllJenisKomiditiResponse>>(Constants.URI.JenisKomoditi.Base)).Result.Result.JenisKomoditis.ToList();

        private async Task GetSatuans()
            => Satuans = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetSatuansResponse>>(Constants.URI.Satuan.Base)).Result.Result.Data.ToList();

        private async Task GetUphIDandNames()
            => UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PostAsJsonAsync(Constants.URI.UphBahanBaku.Register, new CreateUphBahanBakuRequest
                {
                    UphID = Model.UphID,
                    JenisKomoditiID = Model.JenisKomoditiID,
                    JenisTernakID = Model.JenisTernakID,
                    SatuanID = Model.SatuanID,
                    TotalKebutuhan = Model.TotalKebutuhan,
                    AsalBahanBakus = Model.AsalBahanBakus,
                    AsalBahanBaku = Model.AsalBahanBakus.ToString(),
                    Nilai = Model.Nilai
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<CreateUphBahanBakuResponse>>()).Result;

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
    }
}
