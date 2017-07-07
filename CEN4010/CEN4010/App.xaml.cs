using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace CEN4010
{
    public partial class App : Application
    {
        // Globally accessable variables
        public Thermostat system = new Thermostat();
        public CEN4010.MainPage Home;
        private static ThermostatService ThermService = new ThermostatService();
        public ThermostatManager client = new ThermostatManager(ThermService);
        public App()
        {
            InitializeComponent();

            Home = new CEN4010.MainPage();
            var nav = new NavigationPage(Home);
            MainPage = nav;
        }

        protected override void OnStart()
        {
            tickEvent();
            Device.StartTimer(TimeSpan.FromSeconds(5), tickEvent);
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async void TempHandler()
        {
            var temperature = system.getTemperature();
            var item = await client.GetThermostat();
            if (item.Id != 0)
            {
                system.changeSet(item.SetTemp);
                Home.UpdateSet(item.SetTemp);
            }
            Home.UpdateTemperature(temperature.ToString());
        }

        public bool tickEvent()
        {
            TempHandler();
            return true;
        }
    }
}
