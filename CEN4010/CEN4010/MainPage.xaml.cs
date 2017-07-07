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

        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            setTemp.Text = ((App)Application.Current).system.changeSet(e.NewValue).ToString();
            ThermostatItem update = new ThermostatItem();
            update.Id = 1;
            update.SetTemp = (int)e.NewValue;
            changeSetAsync(update);
        }

        void changeSetAsync(ThermostatItem update)
        {
            ((App)Application.Current).client.UpdateThermostat(update, false);
        }

        void toggleAC(object sender, EventArgs e)
        {
            if(((App)Application.Current).system.toggleAC())
            {
                activateAC.Text = "Turn AC Off";
            }
            else
            {
                activateAC.Text = "Turn AC On";
             }
        }

        public void UpdateTemperature(string temperature)
        {
            Temp.Text = temperature;
        }

        public void UpdateSet(int temperature)
        {
            Slider.ValueChanged -= OnSliderValueChanged;
            setTemp.Text = temperature.ToString();
            Slider.Value = temperature;
            Slider.ValueChanged += OnSliderValueChanged;
        }

        public MainPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Slider.Value = 70.0;
            setTemp.Text = ((App)Application.Current).system.changeSet(Slider.Value).ToString();

            activateAC.Clicked += toggleAC;

            Slider.ValueChanged += OnSliderValueChanged;
        }

        private async void settings_Clicked(object sender, EventArgs e)
        {
            var settingPage = new SettingsPage();
            await Navigation.PushAsync(settingPage);
        }
    }
}
