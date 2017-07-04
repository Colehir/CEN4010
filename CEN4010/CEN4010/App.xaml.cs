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
            Device.StartTimer(TimeSpan.FromSeconds(1), tickEvent);
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

        public bool tickEvent()
        {
            Home.UpdateTemperature(system.getTemperature().ToString());
            return true;
        }
    }
}
