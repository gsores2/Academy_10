using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Negozio
{
    class Program
    {
        static void Main(string[] args)
        {

            string Nome_Negozio = "";
            string Proprietaro_Negozio = "";
            List<Prodotto> Prodotti = new List<Prodotto>();
            List<ProdottoInOfferta> ProdottiInOfferta = new List<ProdottoInOfferta>();


            // creo 10 prodotti e li metto nel negozio
            for (int i = 0; i < 1; i++)
            {

                Console.WriteLine("Inserire la descrizione del prodotto (Codice, Descrizione, Prezzo, Sconto): ");
                
                string ricevuto = Console.ReadLine();
                char[] chararray = new char[1];
                chararray[0] = ' ';
                String[] resultarray = ricevuto.Split(chararray);
                if (resultarray.Length== 4)
                {
                    int Codice = Int32.Parse(resultarray[0]);
                    string Descrizione = resultarray[1];
                    double Price =Double.Parse(resultarray[2], CultureInfo.InvariantCulture);
                    Prodotto myProdotto = new Prodotto(Codice, Descrizione, Price, 0);
                    Prodotti.Add(myProdotto);

                }
                else if (resultarray.Length == 3)
                {
                  
                    string Descrizione = resultarray[0];
                    double Price = Double.Parse(resultarray[1], CultureInfo.InvariantCulture);
                    Prodotto myProdotto = new Prodotto( Descrizione, Price, 0);
                    Prodotti.Add(myProdotto);
                }
                else if (resultarray.Length == 2)
                {
                    int Codice = Int32.Parse(resultarray[0]);
                    string Descrizione = resultarray[1];
                   
                    Prodotto myProdotto = new Prodotto(Codice, Descrizione);
                    Prodotti.Add(myProdotto);

                }
                else if (resultarray.Length == 1)
                {
                    
                    string Descrizione = resultarray[0];

                    Prodotto myProdotto = new Prodotto (Descrizione);
                    Prodotti.Add(myProdotto);


                }
                //else if (resultarray.Length != 1 && resultarray.Length != 2 && resultarray.Length != 3 && resultarray.Length != 4)
                //{
                //    Console.WriteLine("E' stato inserito un numero errato di parametri");
                    
                //}

                

            }
            
           

            // creo 10 prodotti in offerta e li metto nel negozio
            for (int i = 0; i < 1; i++)
            {


                Console.WriteLine("Inserire la descrizione del prodotto in sconto (Codice, Descrizione, Prezzo, Sconto, Data di Inizio e Data di Fine): ");
                string ricevuto = Console.ReadLine();
                char[] chararray = new char[1];
                chararray[0] = ' ';
                String[] resultarray = ricevuto.Split(chararray);
                if (resultarray.Length == 6)
                {
                    int Codice = Int32.Parse(resultarray[0]);
                    string Descrizione = resultarray[1];
                    double Price = Double.Parse(resultarray[2], CultureInfo.InvariantCulture);
                    int Sconto = Int32.Parse(resultarray[3]);
                    ProdottoInOfferta myProdotto = new ProdottoInOfferta(Codice, Descrizione, Price, Sconto);
                    char[] separator = new char[1];
                    separator[0] = '-';
                    String[] resultdata = resultarray[4].Split(separator);
                    DateTime newDateTime = new DateTime(Int32.Parse(resultdata[2]), Int32.Parse(resultdata[1]), Int32.Parse(resultdata[0]));

                    char[] separator1 = new char[1];
                    separator[0] = '-';
                    String[] resultdata1 = resultarray[5].Split(separator);

                    DateTime newDateTime1 = new DateTime(Int32.Parse(resultdata1[2]), Int32.Parse(resultdata1[1]), Int32.Parse(resultdata1[0]));

                    myProdotto.data_inizio = newDateTime;
                    myProdotto.data_fine = newDateTime1;
                    
                    DateTime now = DateTime.Now;
                    TimeSpan ts = now - myProdotto.data_inizio;
                    int days = Math.Abs(ts.Days);
                    if (myProdotto.data_inizio<= now && myProdotto.data_fine.AddDays(1)>=now)
                    { ProdottiInOfferta.Add(myProdotto); }
                  

                }
                else if (resultarray.Length == 5)
                {

                    string Descrizione = resultarray[0];
                    double Price = Double.Parse(resultarray[1], CultureInfo.InvariantCulture); 
                    int Sconto = Int32.Parse(resultarray[3]);
                    ProdottoInOfferta myProdotto = new ProdottoInOfferta(Descrizione, Price, Sconto);
                    char[] separator = new char[1];
                    separator[0] = '-';
                    String[] resultdata = resultarray[4].Split(separator);
                    DateTime newDateTime = new DateTime(Int32.Parse(resultdata[2]), Int32.Parse(resultdata[0]), Int32.Parse(resultdata[1]));

                    char[] separator1 = new char[1];
                    separator[0] = '-';
                    String[] resultdata1 = resultarray[5].Split(separator);
                    DateTime newDateTime1 = new DateTime(Int32.Parse(resultdata1[2]), Int32.Parse(resultdata1[0]), Int32.Parse(resultdata1[1]));

                    myProdotto.data_inizio = newDateTime;
                    myProdotto.data_fine = newDateTime1;
                    DateTime now = DateTime.Now;
                    //TimeSpan ts = now - myProdotto.data_inizio;
                    //int days = Math.Abs(ts.Days);
                    //if  (myProdotto.data_inizio <= now && myProdotto.data_fine.AddDays(1) >= now)

                    
                        ProdottiInOfferta.Add(myProdotto);
                    
                    
                }
                else if (resultarray.Length == 4)
                {
                    int Codice = Int32.Parse(resultarray[0]);
                    string Descrizione = resultarray[1];

                    ProdottoInOfferta myProdotto = new ProdottoInOfferta(Codice, Descrizione);
                    char[] separator = new char[1];
                    separator[0] = '-';
                    String[] resultdata = resultarray[4].Split(separator);
                    DateTime newDateTime = new DateTime(Int32.Parse(resultdata[2]), Int32.Parse(resultdata[0]), Int32.Parse(resultdata[1]));

                    char[] separator1 = new char[1];
                    separator[0] = '-';
                    String[] resultdata1 = resultarray[5].Split(separator);
                    DateTime newDateTime1 = new DateTime(Int32.Parse(resultdata1[2]), Int32.Parse(resultdata1[0]), Int32.Parse(resultdata1[1]));

                    myProdotto.data_inizio = newDateTime;
                    myProdotto.data_fine = newDateTime1;
                   
                        ProdottiInOfferta.Add(myProdotto);
                    

                }
                else if (resultarray.Length == 3)
                {

                    string Descrizione = resultarray[0];

                    ProdottoInOfferta myProdotto = new ProdottoInOfferta(Descrizione);
                    char[] separator = new char[1];
                    separator[0] = '-';
                    String[] resultdata = resultarray[4].Split(separator);
                    DateTime newDateTime = new DateTime(Int32.Parse(resultdata[2]), Int32.Parse(resultdata[0]), Int32.Parse(resultdata[1]));

                    char[] separator1 = new char[1];
                    separator[0] = '-';
                    String[] resultdata1 = resultarray[5].Split(separator);
                    DateTime newDateTime1 = new DateTime(Int32.Parse(resultdata1[2]), Int32.Parse(resultdata1[0]), Int32.Parse(resultdata1[1]));

                    myProdotto.data_inizio = newDateTime;
                    myProdotto.data_fine = newDateTime1;
                    DateTime now = DateTime.Now;
                    //TimeSpan ts = now - myProdotto.data_inizio;
                    //int days = Math.Abs(ts.Days);
                    
                        ProdottiInOfferta.Add(myProdotto);
                    


                }
                //else
                //{
                //    Console.WriteLine("E' stato inserito un numero errato di parametri");

                //}


            }
            Console.WriteLine("Inserire il nome del negozio e del proprietario:");

            string ricevuto_nome = Console.ReadLine();
            char[] chararray_nome = new char[1];
            chararray_nome[0] = ' ';
            String[] resultarray_nome = ricevuto_nome.Split(chararray_nome);

            Negozio myNegozio = new Negozio(Nome_Negozio, Proprietaro_Negozio, Prodotti);

            Console.WriteLine(resultarray_nome[0]+"  "+ "da "+ resultarray_nome[1]+ "\r\n Lista dei Prodotti:");
            foreach (var item in Prodotti)
            {
                Console.WriteLine("Prodotto: " + item.GetCodice() + "  " + item.GetDescrizione() + " " + item.GetPrezzo() + " ");/* + item.GetSconto())*/
            }
            foreach (var item in ProdottiInOfferta)
            {
                DateTime now = DateTime.Now;
                //TimeSpan ts = now - myProdotto.data_inizio;
                //int days = Math.Abs(ts.Days);
                if (item.data_inizio <= now && item.data_fine.AddDays(1) >= now)

                {
                    string data_inizio_string = item.data_inizio.ToString("dd.MM.yyy");
                    string data_fine_string = item.data_fine.ToString("dd.MM.yyy");
                    Console.WriteLine("Prodotto in Sconto:" + item.GetCodice() + "  " + item.GetDescrizione() + "  " + item.GetPrezzo() + "  " + item.GetSconto() + "  " + data_inizio_string + " " + data_fine_string);
                }
                }

            //Console.WriteLine("Lista dei Prodotti in offerta");
            //foreach (var item in ProdottiInOfferta)
            //{
            //    Console.WriteLine("Prodotto in offerta" + item);
            //}




        }


    }
}
