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
            return temperature;
        }
        
        public double getAmbientTemp()
        {
            return ambientTemp;
        }
        
        public void setAmbientTemp(double temp)
        {
            ambientTemp = temp;
        }
        
        public void changeTemperature(bool acOn)
        {
            if (acOn)
            {
                temperature -= .25;
            }
            else
            {
                temperature += 0.25;
            }
            
        }
        private double temperature = 71.0;
        private double ambientTemp = 80.0;  //temperature without A/C
    }
}
