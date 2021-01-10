using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.ParameterJawabans.Queries.GetParameterJawabansByIndikatorName;
using SiUpin.Shared.UphGmps.Commands;
using SiUpin.Shared.Uphs.Queries.GetUphIDandNames;
using SiUpin.WebUI.Common;

namespace SiUpin.WebUI.Pages.Admin.Uph.UphGmp
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

        public CreateUphGmpRequest Model { get; set; } = new CreateUphGmpRequest();
        public ApiResponse<CreateUphGmpResponse> Response { get; set; }

        private EditContext _editContext;

        private bool IsHidden = false;

        public void CancelClick()
        {
            DialogIsOpenStatus.InvokeAsync(false);
        }

        public IList<Gmp> Gmps { get; set; } = new List<Gmp>();
        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();

        protected override async Task OnInitializedAsync()
        {
            _editContext = new EditContext(Model);

            await GetNamaGmps();
            await GetUphIDandNames();

            StateHasChanged();
        }

        private void HandleNamaGmp(bool condition, int index)
        {
            Gmps[index].IsGmpChoosen = condition;

            if (condition)
            {
                Model.nama_gmps.Add(Gmps[index].NamaGmp);
            }
            else
            {
                Model.nama_gmps.Remove(Gmps[index].NamaGmp);
            }
        }

        private async Task GetNamaGmps()
        {
            var result = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetParameterJawabansByIndikatorNameResponse>>
                ($"{Constants.URI.ParameterJawaban.ByIndikatorName}" +
                $"{Constants.ParameterIndikator.ParameterIndikatorName.KesesuaianDenganGMP}")).Result.Result.ParameterJawabans.Select(x => x.Name).ToList();

            foreach (var item in result)
            {
                Gmps.Add(new Gmp { IsGmpChoosen = false, NamaGmp = item });
            }
        }

        private async Task GetUphIDandNames()
            => UphIDandNames = Task.FromResult(await Http.GetFromJsonAsync<ApiResponse<GetUphIDandNamesResponse>>(Constants.URI.Uph.UphIDandNames)).Result.Result.UphIDandNames.ToList();

        private async Task HandleSubmit()
        {
            if (_editContext.Validate())
            {
                IsLoadingCircle = true;

                var client = await Http.PostAsJsonAsync(Constants.URI.UphGmp.Register, new CreateUphGmpRequest
                {
                    UphID = Model.UphID,

                    nama_gmps = Model.nama_gmps,
                });

                Response = Task.FromResult(await client.Content.ReadFromJsonAsync<ApiResponse<CreateUphGmpResponse>>()).Result;

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

        public class Gmp
        {
            public string NamaGmp { get; set; }
            public bool IsGmpChoosen { get; set; }
        }
    }
}
