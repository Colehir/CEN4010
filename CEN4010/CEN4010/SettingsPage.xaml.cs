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
    public partial class SettingsPage : ContentPage
    {
        
        public SettingsPage()
        {
            InitializeComponent();
        }
        
        void toggleScale(object sender, EventArgs e)
        {
            bool currentScale = ((App)Application.Current).system.toggleScale();
            if(currentScale)
            {
                scaleName.Text = "Celsius";
            }
            else
            {
                scaleName.Text = "Fahrenheit";
            }
        }

        protected override void OnAppearing()
        {
            scale.Clicked += toggleScale;
        }
    }
}
