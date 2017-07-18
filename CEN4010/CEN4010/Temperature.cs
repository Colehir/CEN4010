using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN4010
{
    public class Temperature
    {
        public double getTemperature()
        {
            return scaleTemp(temperature, isCelcius);
        }
        
        public double getAmbientTemp()
        {
            return scaleTemp(ambientTemp, isCelcius);
        }
        
        public bool toggleTemp()
        {
            isCelcius=!isCelcius;
            return isCelcius;
        }
        
        public double scaleTemp(double temp, bool scale = false)    //returns the temperature as celcius or ferenheit as requested; defaults to ferenheit
        {
            if (scale) //return temperature in celcius
            {
                return (temp-32)*5/9;
            }
            else //return temperature in ferenheit
            {
                return temp;
            }
        }
        
        public double setAmbientTemp(double temp)
        {
            ambientTemp = temp;
            return ambientTemp;
        }
        
        public void changeTemperature(bool acOn)
        {
            if (acOn)
            {
                temperature -= .25;
            }
            else    //the temperature should reach equilibrium
            {
                if(temperature < ambientTemp)
                {
                    temperature += .25;
                }
                else if(temperature > ambientTemp)
                {
                    temperature -= .25;
                }
            }
            
        }
        private bool isCelcius = false; //what scale is being used - TODO: link this variable to setting on settings page
        private double temperature = 71.0;
        private double ambientTemp = 80.0;  //temperature without A/C
    }
}
