using System;

namespace SiUpin.WebUI.Common.StateProvider
{
    public class HandlingPageStateProvider
    {
        public bool IsUnderContructions { get; set; } = false;

        public event Action OnChange;

        public void EnableIsUnderContructions()
        {
            IsUnderContructions = true;
            NotifyStateChanged();
        }

        public void ResetIsUnderContructions()
        {
            IsUnderContructions = false;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
