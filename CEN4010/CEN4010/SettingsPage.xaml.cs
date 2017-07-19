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
        Temperature temp = new Temperature();
        
        public SettingsPage()
        {
            InitializeComponent();
        }
        
        void toggleScale(object sender, EventArgs e)
        {
            bool scale = temp.toggleScale();
            if(scale)
            {
                scale.Text = "Celsius";
            }
            else
            {
                scale.Text = "Fahrenheit";
            }
        }

        protected override void OnAppearing()
        {
            scale.clicked += toggleScale;
        }
    }
}
