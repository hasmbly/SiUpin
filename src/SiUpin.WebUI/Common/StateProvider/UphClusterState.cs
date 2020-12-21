using System;
using SiUpin.Shared.Uphs.Queries.GetUphClusterGrades;

namespace SiUpin.WebUI.Common.StateProvider
{
    public class UphClusterState
    {
        public bool ShouldUpdate { get; set; } = true;

        public GetUphClusterGradesResponse Model = new GetUphClusterGradesResponse();

        public event Action OnChange;

        public void SetShouldUpdate(bool condition)
        {
            ShouldUpdate = condition;

            NotifyStateChanged();
        }

        public void SetModelState(GetUphClusterGradesResponse model)
        {
            Model = model;

            NotifyStateChanged();
        }

        public void ResetState()
        {
            ShouldUpdate = false;
            Model = null;

            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
