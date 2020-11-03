using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources
{
    public class Impiegato : Persona , IPrintLetter
    {
        public String Matricola { get; set; }

        public Impiegato() 
            : base("aaaaaa", "bbbbb") //errore se non ho il costruttore senza PARAMETRI, quindi o aggiungo costruttore persona e basta o chiamo costruttore classe base
        {
            Indirizzo = "hjk";
        }

        public Impiegato(string nome, string cognome, int eta)
            : base(nome, cognome) //errore se non ho il costruttore senza PARAMETRI, quindi o aggiungo costruttore persona e basta o chiamo costruttore classe base
        {
            Eta = eta;
        }
        public void StampaLettera (string testo)
        {
            string txt = testo.ToLower(); //traformo in minuscolo
            Console.WriteLine(txt);

        }
    }
}
