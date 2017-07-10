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
        private bool isDirty = false;
        private int newValue;
        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            setTemp.Text = ((App)Application.Current).system.changeSet(e.NewValue).ToString();
            newValue = (int)e.NewValue;
            isDirty = true;
        }

        bool sliderTick()
        {
            if(isDirty == true)
            {
                ThermostatItem update = new ThermostatItem();
                update.Id = 1;
                update.SetTemp = newValue;
                changeSetAsync(update);
                isDirty = false;
            }
            return true;
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

            Device.StartTimer(TimeSpan.FromSeconds(5), sliderTick);
        }

        private async void settings_Clicked(object sender, EventArgs e)
        {
            var settingPage = new SettingsPage();
            await Navigation.PushAsync(settingPage);
        }
    }
}
