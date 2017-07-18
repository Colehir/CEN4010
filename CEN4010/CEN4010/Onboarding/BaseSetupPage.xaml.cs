using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CEN4010.Onboarding
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BaseSetupPage : ContentPage
	{
		public BaseSetupPage ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            systemNumber.Text = "1";
        }
        private void done_Clicked(object sender, EventArgs e)
        {
            if (int.TryParse(systemNumber.Text, out ((App)Application.Current).systemNumber))
            {
                var nav = new NavigationPage(((App)Application.Current).Home);
                ((App)Application.Current).MainPage = nav;
                ((App)Application.Current).StartTimer();
                ((App)Application.Current).onBoarding = false;
                ((App)Application.Current).remote = false;
            }
        }
    }
}