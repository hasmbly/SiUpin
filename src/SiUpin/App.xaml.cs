using System.Diagnostics;
using SiUpin.Views.Templates;
using Xamarin.Forms;

namespace SiUpin
{
    public partial class App : Application
    {
        public static string BaseImageUrl { get; } = "https://cdn.syncfusion.com/essential-ui-kit-for-xamarin.forms/common/uikitimages/";

        public App()
        {
            // Syncfusion license
            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("MzI4ODQ5QDMxMzgyZTMzMmUzME5GS2JQK0pJZWhPMDhXOGUwNUtTVkQwTm1mYko3dFJ5eVNNNTdzWDN4alE9");

            InitializeComponent();

            MainPage = new EventListTemplate();
        }

        protected override void OnStart()
        {
            Debug.WriteLine("OnStart");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("OnSleep");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("OnResume");
        }
    }
}