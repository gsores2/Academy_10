using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Termometro
{
    public class S3
    {
        private Termometro _t3;

        public S3(Termometro t3) // qui poi mm è un puntatore a un'istanza vera
        {
            this._t3 = t3;
            TemperatureEventHandler del = new TemperatureEventHandler(t3_TemperatureTooHigh);
            this._t3.TemperatureTooHigh += del; // invoco add_MailArrived()

        }

        public void t3_TemperatureTooHigh(Object sender, double Randtemperature) // predispongo il metodo
        {
            Console.WriteLine("I'm S3, Temperature: {0}", Randtemperature);

        }
    }
}
