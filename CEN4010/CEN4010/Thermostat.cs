using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEN4010
{
    public class Thermostat
    {
        public double getTemperature()
        {
            if (acOnUser)
            {
                if (temp.getTemperature() > setTemperature)
                {
                    acOn = true;
                }
                else
                {
                    acOn = false;
                }
                temp.changeTemperature(acOn);
                return Math.Floor(temp.getTemperature());
            }
            else
            {
                temp.changeTemperature(false);
                return Math.Floor(temp.getTemperature());
            }
        }
        public int changeSet(double set)
        {
            setTemperature = (int)set;
            return setTemperature;
        }
        public int getSet()
        {
            return setTemperature;
        }

        public bool toggleAC()
        {
            acOnUser = !acOnUser;
            return acOnUser;
        }

        public bool getAC()
        {
            return acOnUser;
        }

        public bool toggleScale()
        {
            return temp.toggleScale();
        }

        private int setTemperature = 80;
        private bool acOn = false;
        private bool acOnUser = false;
        private Temperature temp = new Temperature();
    }

    public class ThermostatItem
    {
        public long Id { get; set; }
        public int CurrentTemp { get; set; }
        public int SetTemp { get; set; }
        public bool acActivated { get; set; }
        public bool toggleAc { get; set; }
    }
}
