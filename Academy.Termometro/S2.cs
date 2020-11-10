using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Termometro
{
   public class S2
    {
        private Termometro _t2;

        public S2(Termometro t2) // qui poi mm è un puntatore a un'istanza vera
        {
            this._t2 = t2;
            TemperatureEventHandler del = new TemperatureEventHandler(t2_TemperatureTooHigh);
            this._t2.TemperatureTooHigh += del; // invoco add_MailArrived()

        }

        public void t2_TemperatureTooHigh(Object sender, double Randtemperature) // predispongo il metodo
        {
            Console.WriteLine("I'm S2, Temperature: {0}", Randtemperature);

        }
    }
}
