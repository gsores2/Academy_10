using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.MailSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager mm = new MailManager();
            Fax fax = new Fax(mm);
            Printer prn = new Printer(mm);

            mm.SimulateMailArrived("Maria","Marco","cena","Usciamo stasera?"); // simulo arrivo mail
            mm.SimulateMailArrived("Marco", "Maria", "cena", "Lavoro");
        }
    }
}
