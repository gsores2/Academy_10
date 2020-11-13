using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Negozio
{
    public class Prodotto
    {
        protected int codice;
        protected string descrizione;
        protected double prezzo;
        private int sconto;
        public Prodotto(int codice, string descrizione, double prezzo, int sconto)
        {
            this.codice = codice;
            this.descrizione = descrizione;
            this.prezzo = prezzo;
            this.sconto = sconto;
        }
        public Prodotto(string descrizione, double prezzo, int sconto)
        {
          
            this.descrizione = descrizione;
            this.prezzo = prezzo;
            this.sconto = sconto;
            this.codice = -1;
        }
         public Prodotto(int codice, string descrizione)
        {
            this.codice = codice;
            this.descrizione = descrizione;
            
            prezzo = 0;
            sconto = 0;
        }
         public Prodotto( string descrizione)
        {
           
            this.descrizione = descrizione;
            
            prezzo = 0;
            sconto = 0;
            codice = -1;
        }
        public string GetCodice()
        {
            return codice.ToString(); 
        }
        public string GetDescrizione()
        {
            return descrizione;
        }
        public string GetPrezzo()
        {
            return prezzo.ToString()+" $";
        }
        public string GetSconto()
        {
            return sconto.ToString()+" %";
        }
    }
}
