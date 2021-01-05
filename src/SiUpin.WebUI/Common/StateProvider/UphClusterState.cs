using System;
using System.Net.Http;
using System.Net.Http.Json;
using SiUpin.Shared.Common.ApiEnvelopes;
using SiUpin.Shared.UphMitras.Queries;
using SiUpin.Shared.Uphs.Queries.GetUphClusterGrades;

namespace SiUpin.WebUI.Common.StateProvider
{
    public class UphClusterState
    {
        private HttpClient _httpClient;

        public GetUphClusterGradesResponse Model = new GetUphClusterGradesResponse();
        private ApiResponse<GetUphClusterGradesResponse> items;

        public GetUphMitraClusterGradesResponse ModelUphMitraCluster = new GetUphMitraClusterGradesResponse();
        private ApiResponse<GetUphMitraClusterGradesResponse> itemsUphMitraCluster;

        public event Action OnChange;

        public bool IsLoadForModel { get; set; } = false;

        public UphClusterState(HttpClient httpClient)
        {
            _httpClient = httpClient;

            SetShouldUpdate();
        }

        public async void SetShouldUpdate()
        {
            IsLoadForModel = true;

            items = await _httpClient.GetFromJsonAsync<ApiResponse<GetUphClusterGradesResponse>>(Constants.URI.Uph.ClusterGrade);
            itemsUphMitraCluster = await _httpClient.GetFromJsonAsync<ApiResponse<GetUphMitraClusterGradesResponse>>(Constants.URI.UphMitra.ClusterGrade);

            if (items.Result != null && itemsUphMitraCluster.Result != null)
            {
                Model = items.Result;
                ModelUphMitraCluster = itemsUphMitraCluster.Result;

                IsLoadForModel = false;

                NotifyStateChanged();
            }
        }

        public void ResetState()
        {
            Model = null;

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
