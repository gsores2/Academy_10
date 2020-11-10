using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Termometro
{
   public class S1
    {
        private Termometro _t1;

        public S1(Termometro t1) // qui poi mm è un puntatore a un'istanza vera
        {
            this._t1 = t1;
            TemperatureEventHandler del = new TemperatureEventHandler(t1_TemperatureTooHigh);
            this._t1.TemperatureTooHigh += del; // invoco add_MailArrived()
          
        }
       
        public void t1_TemperatureTooHigh(Object sender, double Randtemperature) // predispongo il metodo
        {
            Console.WriteLine("I'm S1, Temperature: {0}", Randtemperature);
                             
        }
    }
}
