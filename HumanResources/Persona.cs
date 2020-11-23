using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HumanResources
{
    public class Persona :IComparable //per avere compare to
    {
        protected String Nome; //proprieta' prop tab tab le proprieta' sono tutte protette (ereditabili ma non modificabili dall'esterno)
        protected String Cognome;
        protected int Eta;
        public string Indirizzo { get; set; }
        public Ruolo Inquadramento; // ho creato un ruolo .cs che è un enum

        public Persona() //COSTRUTTORE BASE 
        {
        }

        public Persona(string nome, string cognome, Ruolo r) //overload 1
        {
            Nome = nome;
            Cognome = cognome;
            this.Inquadramento = r;

        }
        
        public Persona(string nome, string cognome) // costruttore ctor tab tab, e' un metodo che non ha il valore di ritorno perche' mi da' indirizzo istanza
        {
            Nome = nome;
            Cognome = cognome;
            Inquadramento = Ruolo.TerzoLivello;
           
        }
        public void SetEta (int x) //metodo public per settare una proprieta private
        {
            this.Eta = x;
        }
        public override string ToString()  //ereditato da object, ritorna una stringa che rappresenta l'oggetto (lo modifico per farmi ridare quello che voglio
        {
            string s = "Persona: " + Nome + "\t\t" + Cognome + "\r\n" + "Eta': "
                + Eta + "\r\n" + "Indirizzo:" + Indirizzo;

            return s; //base.tostring invoca il metodo cosi com'e' 
        }

        // QUESTO FATTO IL 30/10
        public override bool Equals(object obj) //ereditato da object, ne faccio override per fare in modo che mi dica che sono guuali due persone con stesso noem e cognome anche con diverso indirizzo
        {
            Persona p = (Persona)obj; // DEVO FARE DOWNCAST DA OBJECT  PERCHE' VEDA ANCHE PERSONA!
            return (this.Nome == p.Nome && this.Cognome == p.Cognome);
            
             // DI SOLITO IN EQUALS SI FA COINCIDERE L'HASH CODE PERCUI LO DEVO AGGIUSTARE 

            
        }

        public override int GetHashCode() //per farmi ridare stesso ahsh epr persone con stesso noem e cognome anche se istanze diverse 
        {
            String s = this.Nome + this.Cognome;
            return s.GetHashCode(); 

        }
        public int CompareTo(object obj) // se 99-98 e' maggiore di 0 mi da' 1 quindi la mia istanza e' piu' grande
        {  // compare to è un metoso dell'interfaccia IComparable
            Persona p = (Persona)obj; //DOWNCAST
            // return this.Eta - p.Eta; posso usare un solo return
            return (int)this.Inquadramento - (int)p.Inquadramento;
        }

        
    }
}
