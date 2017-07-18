using CEN4010.Onboarding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CEN4010
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OnboardingPage : ContentPage
	{
		public OnboardingPage ()
		{
			InitializeComponent ();
		}

        private async void base_Clicked(object sender, EventArgs e)
        {
            var baseSetup = new BaseSetupPage();
            await Navigation.PushAsync(baseSetup);
        }

        private async void remote_Clicked(object sender, EventArgs e)
        {
            var remoteSetup = new RemoteSetupPage();
            await Navigation.PushAsync(remoteSetup);
        }
    }
}