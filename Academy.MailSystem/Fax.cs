using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.MailSystem
{
   public class Fax
    {
        private MailManager _mm; // dichiaro istanza di mail manager che qui è puntatore vuoto (istanza nulla del notifier)
        public Fax(MailManager mm) // qui poi mm è un puntatore a un'istanza vera
        {
            this._mm = mm;
            MailManagerEventHandler del = new MailManagerEventHandler(mm_MailArrived);
            this._mm.MailArrived += del; // invoco add_MailArrived()
        }
        public void mm_MailArrived (Object sender, MailEventArgs args) // predispongo il metodo
        {
            Console.WriteLine("I'm a Fax \r\n Mail from: {0}, Mail to: {1} \r\n Subject: {2} \t\t Body:{3}",
                              args.From, args.To, args.Subject, args.Body);
        }
    }
}
