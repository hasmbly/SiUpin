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
using SiUpin.Shared.JenisTernaks.Queries.GetJenisTernaks;
using SiUpin.Shared.Satuans.Queries.GetSatuans;
using SiUpin.Shared.UphBahanBakus.Commands;
using SiUpin.Shared.UphBahanBakus.Queries;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphBahanBaku
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
        public bool IsDisabledLoginButton { get; set; }

        public GetUphBahanBakuResponse Entity { get; set; }
        public UpdateUphBahanBakuRequest Model { get; set; } = new UpdateUphBahanBakuRequest();
        public ApiResponse<UpdateUphBahanBakuResponse> Response { get; set; }

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

        protected override void OnInitialized()
        {
            _editContext = new EditContext(Model);
        }

        private async Task GetEntityByID()
        {
            IsLoading = true;

            Entity = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphBahanBakuResponse>>($"{Constants.URI.UphBahanBaku.Base}/{EntityID}")).Result.Result;

            Model.UphBahanBakuID = Entity.UphBahanBakuID;

            await GetUphIDandNames();
            Model.UphID = Entity.UphID;
            SelectedUph = Entity.Uph.Name;

            await GetJenisTernaks();
            Model.JenisTernakID = Entity.JenisTernakID;
            SelectJenisTernak = Entity.JenisTernakID;

            await GetJenisKomoditis();
            Model.JenisKomoditiID = Entity.JenisKomoditiID;
            SelectJenisKomoditi = Entity.JenisKomoditiID;

            await GetSatuans();
            Model.SatuanID = Entity.SatuanID;
            SelectSatuan = Entity.SatuanID;

            Model.TotalKebutuhan = Entity.TotalKebutuhan;
            Model.Nilai = Entity.Nilai;

            foreach (var item in Entity.AsalBahanBakus)
            {
                var isExist = Entity.AsalBahanBakus.Any(x => x == item);

                System.Console.WriteLine($"{item} - isExist: {isExist}");

                if (isExist)
                {
                    if (item == Constants.UphBahanBaku.AsalBahanBakus[0])
                    {
                        SelectedAsalBahanBaku_00 = true;

                        IsLoading = false;
                        StateHasChanged();
                    }
                    else if (item == Constants.UphBahanBaku.AsalBahanBakus[1])
                    {
                        SelectedAsalBahanBaku_01 = true;

                        IsLoading = false;
                        StateHasChanged();
                    }
                }
            }

            IsLoading = false;
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

                var client = await Http.PutAsJsonAsync(Constants.URI.UphBahanBaku.Base, new UpdateUphBahanBakuRequest
                {
                    UphBahanBakuID = Model.UphBahanBakuID,
                    UphID = Model.UphID,
                    JenisKomoditiID = Model.JenisKomoditiID,
                    JenisTernakID = Model.JenisTernakID,
                    SatuanID = Model.SatuanID,
                    AsalBahanBakus = Model.AsalBahanBakus,
                    TotalKebutuhan = Model.TotalKebutuhan,
                    Nilai = Model.Nilai
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<UpdateUphBahanBakuResponse>>()).Result;

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
