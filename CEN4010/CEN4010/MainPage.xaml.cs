using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CEN4010
{
    public partial class MainPage : ContentPage
    {
        Thermostat system = new Thermostat();
        public bool tickEvent()
        {
            Temp.Text = system.getTemperature().ToString();
            return true;
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            setTemp.Text = system.changeSet(e.NewValue).ToString();
        }

        void toggleAC(object sender, EventArgs e)
        {
            if(system.toggleAC())
            {
                activateAC.Text = "Turn AC Off";
            }
            else
            {
                activateAC.Text = "Turn AC On";
             }
        }

        public MainPage()
        {
            InitializeComponent();

            Slider.Value = 70.0;
            setTemp.Text = system.changeSet(Slider.Value).ToString();

            activateAC.Clicked += toggleAC;

            tickEvent();
            Device.StartTimer(TimeSpan.FromSeconds(1), tickEvent);
            Slider.ValueChanged += OnSliderValueChanged;
        }
    }
}
