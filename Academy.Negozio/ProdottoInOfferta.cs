using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Negozio
{
    public class ProdottoInOfferta : Prodotto
    {

        public DateTime data_inizio { get; set; }
        public DateTime data_fine { get; set; }
        public ProdottoInOfferta(int codice, string descrizione, double prezzo, int sconto) : base(codice, descrizione, prezzo, sconto)
        {
            
        }
        public ProdottoInOfferta(string descrizione, double prezzo, int sconto) : base( descrizione, prezzo, sconto)
        {
            
        }
        public ProdottoInOfferta(int codice, string descrizione) : base(codice, descrizione)
        {
        }
        public ProdottoInOfferta(string descrizione) : base(descrizione)
        {
        }
        
    }
}
