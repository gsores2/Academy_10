using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Termometro
{
    public delegate void TemperatureEventHandler(Object sender, double temperature); //dichiarazione delegate
    public class Termometro
    { 
     
        public event TemperatureEventHandler TemperatureTooHigh; // dichiarazione evento 
        public void SimulateTemp(double temp)
        {
            if (temp >25 && TemperatureTooHigh!=null) 
            {
                TemperatureTooHigh?.Invoke(this, temp); //sollevazione evento 
            }

              
        }

    }
}
