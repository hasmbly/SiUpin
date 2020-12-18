using System.Collections.Generic;
using MatBlazor;

namespace SiUpin.WebUI.Common
{
    public static class SnackbarExtensions
    {
        public static void AddErrors(this IMatToaster toaster, IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                toaster.Add(error, MatToastType.Danger);
            }
        }
    }
}
