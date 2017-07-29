using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public bool onBoarding = true;
        public int systemNumber = 0;
        public bool remote = true;

        public App()
        {
            InitializeComponent();

            Home = new CEN4010.MainPage();


            if (onBoarding)
            {
                var nav = new NavigationPage(new CEN4010.OnboardingPage());
                MainPage = nav;
            }
            else
            {
                var nav = new NavigationPage(Home);
                MainPage = nav;
            }
        }

        protected override void OnStart()
        {
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
            var temperature = 0;
            var item = await client.GetThermostat(systemNumber);
            if (remote)
            {
                if (item.Id != 0)
                {
                    temperature = item.CurrentTemp;
                }
            }
            else
            {
                temperature = (int)system.getTemperature();
                ThermostatItem update = new ThermostatItem();
                update.Id = 1;
                update.CurrentTemp = temperature;
                await client.UpdateThermostat(update, false);
            }

            Home.UpdateActivated();
            Home.UpdateTemperature(temperature.ToString());

            if (item.Id != 0 && item.SetTemp != system.getSet())
            {
                await Task.Delay(TimeSpan.FromSeconds(5));
                item = await client.GetThermostat(systemNumber);
                system.changeSet(item.SetTemp);
                Home.UpdateSet(item.SetTemp);
            }
        }

        public bool tickEvent()
        {
            TempHandler();
            return true;
        }

        public void StartTimer()
        {
            tickEvent();
            Device.StartTimer(TimeSpan.FromSeconds(5), tickEvent);
        }
    }
}
