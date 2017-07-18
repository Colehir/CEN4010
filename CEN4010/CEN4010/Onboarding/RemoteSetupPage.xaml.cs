using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CEN4010.Onboarding
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RemoteSetupPage : ContentPage
	{
		public RemoteSetupPage ()
		{
			InitializeComponent ();
		}

        private void done_Clicked(object sender, EventArgs e)
        {
            try {
                if (int.TryParse(systemNumber.Text, out ((App)Application.Current).systemNumber))
                {
                    var nav = new NavigationPage(((App)Application.Current).Home);
                    ((App)Application.Current).MainPage = nav;
                    ((App)Application.Current).StartTimer();
                    ((App)Application.Current).onBoarding = false;
                    ((App)Application.Current).remote = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}