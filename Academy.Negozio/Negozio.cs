using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Negozio
{
    public class Negozio
    {
        protected string nome;
        protected string proprietario;
        protected List<Prodotto> Lst_Prodotti;

        protected Prodotto prod { get; set; }
        public Negozio(string nome, string proprietario)
        {

        }

        public Negozio(string nome, string proprietario, Prodotto prod)
        {
            Lst_Prodotti = new List<Prodotto>();


            Lst_Prodotti.Add(prod);

        }
        public Negozio(string nome, string proprietario, List<Prodotto> Lst_Prodotti)
        {

        }

    }
}
