using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.Kecamatans.Queries.GetKecamatansByKotaID;
using SiUpin.Shared.Kelurahans.Queries.GetKelurahansByKecamatanID;
using SiUpin.Shared.Kotas.Queries.GetKotasByProvinsiID;
using SiUpin.Shared.Provinsis.Queries.GetProvinsis;
using SiUpin.Shared.Roles.Queries.GetRoles;
using SiUpin.Shared.Users.Commands.CreateUser;
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
        public bool IsDisabledLoginButton { get; set; }

        public CreateUserRequest Model { get; set; } = new CreateUserRequest();
        public ApiResponse<CreateUserResponse> Response { get; set; }

        private EditContext _editContext;

        public string SelectRole
        {
            get => Model.RoleID;
            set => Model.RoleID = value;
        }

        public string SelectProvinsi
        {
            get => Model.ProvinsiID;
            set
            {
                Model.ProvinsiID = value;
                InvokeAsync(async () =>
                {
                    await GetKotasByProvinsiID(value);
                    StateHasChanged();
                });
            }
        }

        public string SelectKota
        {
            get => Model.KotaID;
            set
            {
                Model.KotaID = value;
                InvokeAsync(async () =>
                {
                    await GetKecamatansByKotaID(value);
                    StateHasChanged();
                });
            }
        }

        public string SelectKecamatan
        {
            get => Model.KecamatanID;
            set
            {
                Model.KecamatanID = value;
                InvokeAsync(async () =>
                {
                    await GetKelurahansByKecamatanID(value);
                    StateHasChanged();
                });
            }
        }

        public string SelectKelurahan
        {
            get => Model.KelurahanID;
            set => Model.KelurahanID = value;
        }

        public IList<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
        public IList<ProvinsiDTO> Provinsis { get; set; } = new List<ProvinsiDTO>();
        public IList<KotaDTO> Kotas { get; set; } = new List<KotaDTO>();
        public IList<KecamatanDTO> Kecamatans { get; set; } = new List<KecamatanDTO>();
        public IList<KelurahanDTO> Kelurahans { get; set; } = new List<KelurahanDTO>();

        public void CancelClick()
        {
            DialogIsOpenStatus.InvokeAsync(false);
        }

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(Model);

            await GetRoles();
            await GetProvinsis();

            StateHasChanged();
        }

        private async Task GetRoles()
            => Roles = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetRolesResponse>>(Constants.URI.User.GetRoles)).Result.Result.Data.ToList();
        private async Task GetProvinsis()
            => Provinsis = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetProvinsisResponse>>(Constants.URI.Region.GetProvinsis)).Result.Result.Data.ToList();
        private async Task GetKotasByProvinsiID(string ID)
            => Kotas = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetKotasByProvinsiIDResponse>>($"{Constants.URI.Region.GetKotasByProvinsiID}{ID}")).Result.Result.Data.ToList();
        private async Task GetKecamatansByKotaID(string ID)
            => Kecamatans = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetKecamatansByKotaIDResponse>>($"{Constants.URI.Region.GetKecamatansByKotaID}{ID}")).Result.Result.Data.ToList();
        private async Task GetKelurahansByKecamatanID(string ID)
            => Kelurahans = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetKelurahansByKecamatanIDResponse>>($"{Constants.URI.Region.GetKelurahansByKecamatanID}{ID}")).Result.Result.Data.ToList();

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoading = true;

                var client = await Http.PostAsJsonAsync<CreateUserRequest>(Constants.URI.User.Register, new CreateUserRequest
                {
                    Username = Model.Username,
                    Password = Model.Password,

                    Alamat = Model.Alamat,
                    Email = Model.Email,
                    Fullname = Model.Fullname,
                    Instansi = Model.Instansi,
                    Jabatan = Model.Jabatan,
                    NIP = Model.NIP,
                    Telepon = Model.Telepon,

                    RoleID = Model.RoleID,
                    ProvinsiID = Model.ProvinsiID,
                    KotaID = Model.KotaID,
                    KecamatanID = Model.KecamatanID,
                    KelurahanID = Model.KelurahanID
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<CreateUserResponse>>()).Result;

                if (!Response.Status.IsError)
                {
                    IsLoading = false;

                    await DialogIsOpenStatus.InvokeAsync(false);

                    await OnSuccessSubmit.InvokeAsync(true);

                    StateHasChanged();
                }
                else
                {
                    Toaster.Add(Response.Status.Message, MatToastType.Danger);

                    IsLoading = false;
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
