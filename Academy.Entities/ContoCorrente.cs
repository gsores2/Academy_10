using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Entities
{
    public class ContoCorrente
    {
        string string_result = "";
        private string numeroConto;
        private double saldo;
        Movimento movimento_eseguito;
        Cliente owner; // serve perche conto corrente esiste solo se ho un cliente
        public List <Movimento> Movimenti= new List<Movimento>() ;
        //public List<Movimento> Movimenti{ get; } // cosi mi creo una lista con i movimenti
        public ContoCorrente(Cliente owner) // lo valorizzo quando lo creo, non posso avere un costruttore vuoto
        {
            //Movimenti = new List<Movimento>() ; // creo la lista quando creo il conto corrente
            this.owner = owner; 

        }
        
        public Cliente GetOwner()
        {   


            return this.owner;
        }
       
        public string GetNumeroConto()
        {   


            return numeroConto;
        }

        public double GetSaldo()
        {

            return saldo;

        }
        public ContoCorrente(string numeroConto, double saldo)
        {
            this.numeroConto = numeroConto;
            this.saldo = saldo;
          
        }
        
        public OperationResult Deposita(double cifra)
        {
            saldo += cifra;
            Movimento deposito = new Movimento() // così inizializzo una classe in un modo diverso
            {
                //Owner = this.GetOwner().Username,
                Tipo = TipoMovimento.Deposito,
                Importo = cifra,
                Data = DateTime.Now,// data di adesso
                Beneficiario = ""
            };
            deposito.NumConto = this.numeroConto;
            movimento_eseguito = deposito;
            Movimenti.Add(deposito);
            string_result = "Deposito: " + deposito.Importo.ToString() + "  Data: " + deposito.Data.ToString("yyyy, MMMM dd");
            return OperationResult.Operazione_OK;
        }
        public OperationResult Preleva(double cifra)
        {
            OperationResult result =  OperationResult.FondiInsufficienti;
            if (saldo>= cifra)
            {
                saldo -= cifra;
                result = OperationResult.Operazione_OK;
                Movimento prelievo = new Movimento() // così inizializzo una classe in un modo diverso
                {
                    //Owner = this.GetOwner().Username,
                    Tipo = TipoMovimento.Prelievo,
                    Importo = cifra,
                    Data = DateTime.Now, // data di adesso
                    Beneficiario = ""
                };
                prelievo.NumConto = this.numeroConto;
                movimento_eseguito = prelievo;
                Movimenti.Add(prelievo);
                string_result = "Prelievo: " + prelievo.Importo.ToString() + "  Data: " + prelievo.Data.ToString("yyyy, MMMM dd");
             
            }
           else
            {
                result = OperationResult.FondiInsufficienti;
                string_result = "Errore";
            }
            
            return result;
        }

        public OperationResult Bonifico ( double cifra, string beneficiario)
        {  

            OperationResult result = OperationResult.FondiInsufficienti;
            if (saldo >= cifra)
            {
                saldo -= cifra;
                result = OperationResult.Operazione_OK;
                Movimento bonifico = new Movimento() // così inizializzo una classe in un modo diverso
                {
                    //Owner = this.GetOwner().Username,
                    Tipo = TipoMovimento.Bonifico,
                    Importo = cifra,
                    Data = DateTime.Now, // data di adesso
                    Beneficiario = beneficiario
                };
                bonifico.NumConto = this.numeroConto;
                movimento_eseguito = bonifico;
                Movimenti.Add(bonifico);

                string_result = "Bonifico: " + bonifico.Importo.ToString() + "  Beneficiario: " + bonifico.Beneficiario + "  Data: " + bonifico.Data.ToString("yyyy, MMMM dd");

            }
            else
            {
                result = OperationResult.FondiInsufficienti;
                string_result = "Errore";

            }

            return result;

        }

        public Movimento GetMovimento()
        {
            return movimento_eseguito;
        }

        public string ShowMovimenti(string mov)
        {
            return string_result;
        }
    }
}
