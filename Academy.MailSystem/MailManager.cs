using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.MailSystem
{   // faccio una classe mail event args per contenere gl arogmenti dell'event handler
    
//        l'object sender è colui che ha sollevato l'evento
    public class MailManager
    { // sto dichiarando l'evento
        public event MailManagerEventHandler MailArrived;
        public void SimulateMailArrived(string from, string to, string subject, string body) // simulazione di sollevamento evento
        {

            MailEventArgs args = new MailEventArgs() // li ho creati nella classe delegatestuff per comodita

            {
                Body = body,
                From = from,
                Subject = subject,
                To = to
            };
            // devo sollevare l'evento, quindo scorrere la lista dei delegate
            if (MailArrived != null) // se qualcuno si è sottoscritto
            {
                foreach (var item in MailArrived.GetInvocationList().ToList())
                {
                    MailManagerEventHandler mm_eh = (MailManagerEventHandler)item; // downcast per non avere un delegate generico
                    mm_eh(this, args);//uso il puntatore come metodo, metto this perchè sono io che sollevo l'evento e ci passo gli argomenit 
                }
            }

            // analogo di tutto quello che ho nell'if è MailArrived(this, args) o MailArrived?.Invoce(this, args)
        }
    }
    
}
