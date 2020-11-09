using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.MailSystem
{
    public class Printer
    {
        private MailManager _mm;
        public Printer(MailManager _mm)
        {
            this._mm = _mm;
            this._mm.MailArrived += mm_MailArrived; //+= tab tab (non costruisco il delegate, ci mette direttamente il nome metodo ma è come se facesse delegate
        } //lo costruisce lui behind the scenes

        private void mm_MailArrived(object sender, MailEventArgs args)
        {
            Console.WriteLine("I'm a Printer \r\n Mail from: {0}, Mail to: {1} \r\n Subject: {2} \t\t Body:{3}",
                             args.From, args.To, args.Subject, args.Body);
        }
    }
}
