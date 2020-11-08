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
        private string tempCCFileName;
        public FileSystemDataManager()
        {
            usersFileName = System.IO.Path.Combine(bankDir, "Users.txt");
            CCFileName = System.IO.Path.Combine(bankDir, "ContiCorrenti.txt");
            MovimentiFileName = System.IO.Path.Combine(bankDir, "Movimenti.txt");
            tempCCFileName= System.IO.Path.Combine(bankDir, "MovimentiTemp.txt");
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

        public DataOperationResult AggiornaFileMovimenti(Movimento mov)
        {

            
            DataOperationResult result = new DataOperationResult();
            try
            {
                System.IO.StreamWriter sw_clienti = System.IO.File.AppendText(MovimentiFileName); // aggiorno file movimenti (devo aggiornare anche il file cc con saldo)
                string new_cliente = mov.NumConto + ";" +
                                    mov.Tipo + ";" +
                                    mov.Importo + ";" +
                                    mov.Data + ";" +
                                    mov.Beneficiario;
                sw_clienti.WriteLine(new_cliente);
                sw_clienti.Close();

                /* manca finire di aggiorare il saldo nel file conto corrente
                string line_to_read;
                string line_to_write = null;
                char[] chararray = new char[1]; // se scrivessi char[] ca starei dichiarando un puntatore vuoto
                chararray[0] = ';';
                using (System.IO.StreamReader fileCC = new System.IO.StreamReader(CCFileName))
                {
                    while (!String.IsNullOrEmpty(line_to_read = fileCC.ReadLine())) // quella tra paresntesi si chiama guardia ed e' un espressione booleana
                    {
                        String[] resultArray = line_to_read.Split(chararray);
                        string current_conto = resultArray[0];
                        if (current_conto== mov.NumConto)
                      //RSOLVERE      line_to_write= mov.NumConto() + ";" + new_cc.GetSaldo() + ";" + newCliente.Username; 
                    }
                    
                    string line = null;
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(CCFileName))
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(tempCCFileName))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line == line_to_write)
                            {
                                writer.WriteLine(line_to_write);
                            }
                            else
                            {
                                writer.WriteLine(line);
                            }
                            line_number++;
                        }
                    }


                    int line_to_edit = 2;
                string sourceFile = "source.txt";
                string destinationFile = "target.txt";
                string tempFile = "target2.txt";

                // Read the appropriate line from the file.
                string lineToWrite = null;
                using (StreamReader reader = new StreamReader(sourceFile))
                {
                    for (int i = 1; i <= line_to_edit; ++i)
                        lineToWrite = reader.ReadLine();
                }

                if (lineToWrite == null)
                    throw new InvalidDataException("Line does not exist in " + sourceFile);

                // Read from the target file and write to a new file.
                int line_number = 1;
                string line = null;
                using (StreamReader reader = new StreamReader(destinationFile))
                using (StreamWriter writer = new StreamWriter(tempFile))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line_number == line_to_edit)
                        {
                            writer.WriteLine(lineToWrite);
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                        line_number++;
                    }
                }

                // TODO: Delete the old file and replace it with the new file here.
                //System.IO.StreamWriter sw_cc = System.IO.File.AppendText(CCFileName); // creo il conto corrente solo se ho un cliente
                //ContoCorrente new_cc = mov.mioConto;
                //string s_new_cc = new_cc.GetNumeroConto() + ";" + new_cc.GetSaldo() + ";" + newCliente.Username;
                //sw_cc.WriteLine(s_new_cc);
                //sw_cc.Close();
                */
                result.isOK = true;
            }
            catch (Exception excp)
            {

                result.isOK = false;
                result.Message = excp.Message;
            }
           
            return result;
        }
    }
    
}
