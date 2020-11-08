using Academy.DataManager;
using Academy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DataManager
{
    public class FileSystemDataManager : IDataManager
    { 
        private string bankDir= @"C:\Users\giulia.soresini\Desktop";
        private string usersFileName;
        private string clientiFileName;
        private string CCFileName;
        private string MovimentiFileName;
        public FileSystemDataManager()
        {
            usersFileName = System.IO.Path.Combine(bankDir, "Users.txt");
            CCFileName = System.IO.Path.Combine(bankDir, "ContiCorrenti.txt");
            MovimentiFileName = System.IO.Path.Combine(bankDir, "Movimenti.txt");
            clientiFileName = System.IO.Path.Combine(bankDir, "Clienti.txt");
        }
        public bool LoginIsOK(string username, string password)
        {
            bool result = false;
            
            string line;
            char[] chararray = new char[1]; // se scrivessi char[] ca starei dichiarando un puntatore vuoto
            chararray[0] = ';';
            using (System.IO.StreamReader fileuser = new System.IO.StreamReader(usersFileName))
            {
                while ((line = fileuser.ReadLine()) != null) // quella tra paresntesi si chiama guardia ed e' un espressione booleana
                {
                    String[] resultArray = line.Split(chararray);
                    string current_user = resultArray[0];
                    string current_pw = resultArray[1];
                    if (username == current_user && password == current_pw)
                    {
                        result = true;
                        break;
                    }

                }
                fileuser.Close();

            }
            return (result);
        }
        public bool UserIsAnOwner(string username)
        {
            bool result = false;
           
            string line;
            char[] chararray = new char[1]; // se scrivessi char[] ca starei dichiarando un puntatore vuoto
            chararray[0] = ';';
            using (System.IO.StreamReader fileCC = new System.IO.StreamReader(CCFileName))
            {
                
                while (!String.IsNullOrEmpty(line = fileCC.ReadLine())) // quella tra paresntesi si chiama guardia ed e' un espressione booleana
                { // confronto con Null o Empty perchè se cancello non è più null
                    String[] resultArray = line.Split(chararray);
                    string current_user = resultArray[2];

                    if (username == current_user)
                    {
                        result = true;
                        break;
                    }



                }
                fileCC.Close(); 
            } // alla fine di questo lo distrugge
            return (result);
        }

        public DataOperationResult CreateNewCliente(Cliente newCliente) // devo scrivere una riga nel file clienti
        {
            DataOperationResult result = new DataOperationResult();
            try
            {
                System.IO.StreamWriter sw_clienti = System.IO.File.AppendText(clientiFileName);
                string new_cliente = newCliente.Username + ";" +
                                    newCliente.FirstName + ";" +
                                    newCliente.LastName + ";" +
                                    newCliente.CF;
                sw_clienti.WriteLine(new_cliente);
                sw_clienti.Close();
                System.IO.StreamWriter sw_cc = System.IO.File.AppendText(CCFileName); // creo il conto corrente solo se ho un cliente
                ContoCorrente new_cc = newCliente.mioConto;
                string s_new_cc = new_cc.GetNumeroConto() + ";" + new_cc.GetSaldo() + ";" + newCliente.Username;
                sw_cc.WriteLine(s_new_cc);
                sw_cc.Close();
                result.isOK = true;
            }
            catch (Exception excp)
            {

                result.isOK = false;
                result.Message = excp.Message;
            }
           
            return result;
        }

     

        public ContoCorrente GetContoCorrenteByUsername(string username)
        {
            ContoCorrente cc_result = null;

            using (System.IO.StreamReader file = new System.IO.StreamReader(CCFileName))
            {
                string line;
                char[] chararray = new char[1]; // se scrivessi char[] ca starei dichiarando un puntatore vuoto
                chararray[0] = ';';
                while (!String.IsNullOrEmpty(line = file.ReadLine())) // quella tra paresntesi si chiama guardia ed e' un espressione booleana
                {
                    String[] resultArray = line.Split(chararray);
                    string current_user = resultArray[2];
                    if (username == current_user)
                    {
                        cc_result = new ContoCorrente(resultArray[0], Double.Parse(resultArray[1]));
                        break;
                    }
                }
                file.Close();
            }

            return cc_result;
        }

        public bool AggiornaFileMovimenti(string user)
        {
            
        }
    }
    
}
