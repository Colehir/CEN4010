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
            return scaleTemp(temperature, isCelsius);
        }
        
        public double getAmbientTemp()
        {
            return scaleTemp(ambientTemp, isCelsius);
        }
        
        public bool toggleScale()
        {
            isCelsius=!isCelsius;
            return isCelsius;
        }
        
        public bool getScale()
        {
            return isCelsius;
        }
        
        public double scaleTemp(double temp, bool scale = false)    //returns the temperature as celcius or fahrenheit as requested; defaults to fahrenheit
        {
            if (scale) //return temperature in celcius
            {
                return (temp-32)*5/9;
            }
            else //return temperature in fahrenheit
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
        private bool isCelsius = false; //what scale is being used - TODO: link this variable to setting on settings page
        private double temperature = 71.0;
        private double ambientTemp = 80.0;  //temperature without A/C
    }
}
