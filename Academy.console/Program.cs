using System; // cosi' non mi serve indiare il name space dopo
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Threading;
using System.Xml.Schema;
using Academy.GeometryAbstract;
using HumanResources; //referenzio assembly
//using Academy.Geometry;
namespace Academy.console
{
    class Program
    {
        static void Main(string[] args) // vuole in input un array di stringhe che si chiama args
        {
            //TestSplit();  //27/10
            //TestReadFile();  //27/10
            //TestHR(); //28/10
            //TestGeometry(); //28/10
            // TestGeometryAbstract();  //29/10
            // TestLoops();  //29/10
            //TestProblema();  //30/10
            //TestGeneric();   //30/10
            //TestUni_001(); //2/11
            ///TestUni_002(); //2/11
            //TestUni_003(); //3/11
            Test_tris(); //3/11 risoluzione del testo in test uni 003
        }



        /// <summary>
        /// 3/11 testo problema tris
        /// </summary>
        private static void TestUni_003()
        {
            //thereisaWinner = false;
            //GameOver = false;
            // while(thereisaWinner || GameOver)
            // {
            // if(!GameOver)
            //   {Move(A)
            //    conut++;
            //      if (A is winner) 
            //      {thereisaWinner=true;
            //         break;
            //      } 
            // else 
            // {
            //      if(!GameOver)
            // {
              //  Move(B)
              // count++;
            //      if (B is winner) 
            //      {thereisaWinner=true;
            //         break;
            //      }
            //RISOULZIONE DA TEST TRIS FINO A INIT TRIS (3/11)

                //}

            }
        private static void Test_tris()
        {
            int[,] Tris = new int[3, 3]; // inizializzo la matrice
            initTris(Tris); // chiamo initTris per inizializzare la matrice (lo potevo fare anche qui)

            bool ThereIsaWinner = false;
            bool NoMoreMoves = false;
            bool A_isWinner = false;
            bool B_isWinner = false;

            while (!ThereIsaWinner && !NoMoreMoves)
            {
                Move(1, Tris); //A è il mio 1, B è il mio 2, chiamo il metodo Move a cui devo passare il numero del giocatore che gioca e la matrice in cui gioca
                A_isWinner = IsWinner(1, Tris); // mi ridà un booleano che è vero se A ha vinto o su riga o su colonna o su diagonale
                if (A_isWinner)
                {
                    ThereIsaWinner = true; // esco dal while
                }
                else // se A non ha vinto guardo se ci sono ancora mosse 
                {
                    if (!ThereAreMoves(Tris)) // se non ci sono più caselle libere 
                    {
                        NoMoreMoves = true; // esco dal while
                    }
                    else // altrimenti gioca B
                    {
                        Move(2, Tris);
                        B_isWinner = IsWinner(2, Tris);
                        if (B_isWinner)
                        {
                            ThereIsaWinner = true;
                        }
                        else
                        {
                            if (!ThereAreMoves(Tris))
                                NoMoreMoves = true;
                        }
                    }
                }
            } 

            /*Per muovere: pesco e poi calcolo i numeri modulo 9, ciclando se la casella pescata è vuota,
            Altrimenti pesco ogni volta tra un numero minore di elementi e occupo la k-esima casella vuota.
             */
            /*ThereAreMoves basta inizializzare a 0 tutto e controllare se ci sono degli zeri...*/
            /* IsWinner facciamo 3 funzioni che controllino righe, colonne e diagonali, e ogni volta che dobbiamo controllare
             * se x ha vinto, vedere dove stanno i suoi simboli e controllare solo per quelli... faremo al più 27 controlli quindi okay... */


            PrintTris(Tris);  // chiamo print tris 
            System.Console.WriteLine("'A is Winner' is {0}; 'B is Winner' is {1}", A_isWinner.ToString(), B_isWinner.ToString());

        }
        private static bool IsWinner(int v, int[,] matrix) // v mi dice chi sta giocando
        {
            bool result = false; 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == v) // controlla dove stanno 1 o 2 a seconda che stia giocando A o B sia in righe che in colonne che in diagonale
                    {
                        result = RowControl(v, i, matrix); // se isEqual è vero in RowControl allora result è vero quindi nella riga i-esima ho trovato un tris
                        if (result == true) break;
                        result = ColumnControl(v, j, matrix);  // se isEqual è vero in ColumnControl allora result è vero quindi nella colonna j-esima ho trovato un tris
                        if (result == true) break;
                        if ((i + j) % 2 == 0) result = DiagonalControl(v, i, j, matrix); // sto sulla diagonale se la somma di riga e colonna è pari 
                        if (result == true) break;
                    }
                }
                if (result == true) break;
            }

            return result;
        }
        private static bool DiagonalControl(int v, int i, int j, int[,] matrix)
        {
            bool diagonal = false;
            bool antidiagonal = false;
            if (i == j) // sono sulla diagonale 
            {
                diagonal = true;
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[k, k] == v) diagonal = diagonal && true; // rimane vera solo se tutta la diagonale è uguale a v
                    else diagonal = diagonal && false;
                }
            }
            if (i + j == 2) // sull'antidiagonale la somma degli indici è 2
            {
                antidiagonal = true;
                for (int k = 0; k < matrix.GetLength(0); k++)
                {
                    if (matrix[k, matrix.GetLength(0) - 1 - k] == v) antidiagonal = antidiagonal && true;
                    else antidiagonal = antidiagonal && false;
                }
            }

            return (diagonal || antidiagonal); // ritorna vero se una delle due è vera
        }
        private static bool ColumnControl(int v, int j, int[,] matrix) // funziona come RowControl
        {
            bool isEqual = true;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == v) isEqual = isEqual && true;
                else isEqual = isEqual && false;
            }
            return isEqual;
        }
        private static bool RowControl(int v, int i, int[,] matrix)
        { //restituisce true se v è vincitore lungo la riga i

            bool isEqual = true;
            for (int j = 0; j < matrix.GetLength(1); j++) // se sto controllando la riga i-esima scorrono le colonne
            {
                if (matrix[i, j] == v) isEqual = isEqual && true; // se lo è in tutta la riga allora rimane vero, altrimenti diventa falso
                else isEqual = isEqual && false;
            }
            return isEqual;
        }
        private static bool ThereAreMoves(int[,] matrix)
        {
            bool result = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        result = true; // se anche solo 1 è lbera mi ridaà che ci sono mosse 
                        break;
                    }
                }
                if (result == true) break;
            }
            return result;
        }
        private static void Move(int v, int[,] matrix) // A Move devo passare il numero del giocatore che gioca e la matrice in cui gioca
        {
            int position = Academy.Helper.RandomHelper.randomNumber(0, 9); //mi ridà interi da 0 a 8 perchè esclude il secondo 
            while (!isAvailable(position, matrix)) // finchè non è disponibile vai avanti nell'array circolare
            {
                position = (position + 1) % 9; // cosi avanzo di uno rispetto a dove ero
            }
            matrix[position / 3, position % 3] = v; // ci metto 1 o 2 a seconda di chi sta giocando 
        }
        private static bool isAvailable(int position, int[,] matrix) // controlla se la posizione che ho appena generato è disponibile nella matrice su cui sto giocando
        {
            bool result = false;
            if (matrix[position / 3, position % 3] == 0) result = true; // se è zero è libera altrimenti no (ho fatto corrispondenza tra intero che va da 0 a 8 con la corrispondente 
            return result;                                              // posizione in matrice (la riga è il risultato della divisione per tre, la colonna il resto della divisione per 3)
        }
        private static void PrintTris(int[,] matrix)
        {
            char[,] temp = new char[matrix.GetLength(0), matrix.GetLength(1)]; // faccio caratteri 
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0) temp[i, j] = ' ';
                    if (matrix[i, j] == 1) temp[i, j] = 'X';
                    if (matrix[i, j] == 2) temp[i, j] = 'O';
                }
            }
            System.Console.WriteLine("{0}\t{1}\t{2}", temp[0, 0], temp[0, 1], temp[0, 2]);
            System.Console.WriteLine("{0}\t{1}\t{2}", temp[1, 0], temp[1, 1], temp[1, 2]);
            System.Console.WriteLine("{0}\t{1}\t{2}", temp[2, 0], temp[2, 1], temp[2, 2]);

        }
        private static void initTris(int[,] matrix) // inizializza la matrice a tutti 0 
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }




        /// <summary>
        /// TEST UNI 002 2/11
        /// CONVERSIONE DA BINARIO A DECIMALE
        /// </summary>

        private static void TestUni_002()
        {
            string b = "11011001";
            int converted_binary = Academy.Helper.RandomHelper.BinaryConversion(b); // Sta in random helper
            Console.WriteLine(converted_binary);
            Console.ReadLine();
        }



        /// <summary>
        /// TEST UNI 001 2/11
        /// Scrivere un programma "Tutti uguali" che prende un array di 10 numeri interi contenente valori a piacere (senza bisogno di chiederli all’utente) e stampa "tutti uguali" se i valori
        /// dell’array sono tutti uguali, oppure stampa "non tutti uguali" altrimenti. (Il programma deve essere
        /// scritto facendo finta di non sapere quali siano i valori inseriti nell’array). Per riempire l'array utilizzare la classe 
        /// RandomHelper in 2 casi: 1. restituisce valori casuali, 2. restituisce valori uguali
        /// </summary>
        private static void TestUni_001()
        {
            int min =  0;
            int max = 100; 
           // int[] int_Arr_rand = new int[10];
            int[] int_Arr_DIV = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10}; 
            int[] int_Arr_equals = new int[10];
            for (int i = 0; i < 10; i++)
            {
                //int_Arr_rand[i] = Academy.Helper.RandomHelper.randomNumber(min, max);
                
                int_Arr_equals[i] = Academy.Helper.RandomHelper.GetSameInt(max); // mi ridà sempre lo stesso numero casuale

            }
            //printArr(int_Arr_equals);
            // result=printArr(int_Arr_rand);
           // if (result) System.Console.WriteLine("Tutti Uguali");
            //else System.Console.WriteLine("Non tutti uguali");
            bool result = printArrAllDifferent(int_Arr_DIV);
            if (result) System.Console.WriteLine("Tutti Diversi");
            else System.Console.WriteLine("Non tutti diversi");
            System.Console.ReadLine();
        }
        private static bool printArrAllDifferent(int[] array)
        {

            int flag = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i+1; j < array.Length; j++) // tanto li ho controllati prima
                {

                    if (array[i] == array[j])
                    {
                        
                            flag = 1;
                        break;

                    }
                }
            }

            if (flag == 0) return true;
            else return false;
        }
        private static bool printArr(int[] array)
        {
            int flag = 0;
           
            for (int i = 0; i < array.Length; i++)
            {
                
                    if (array[i] == array[i-1])
                    {
                       
                        flag = 1;
                        break;

                    }
                
            }
            if (flag == 0) return true;
            else return false;

            
        }



        /// <summary>
        /// TEST GENERIC:30/10 PER RISPIEGARE IL CONCETTO DI GENERICS
        /// </summary>
        private static void TestGeneric()
        {
            List<int> lst_int = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0};
        
            if(lst_int.Contains(3))
                Console.WriteLine("3 is int List");

            List<Persona> lst_persona = new List<Persona>();
            Persona mario = new Persona("Mario", "Rossi");
            Persona maria = new Persona("Maria", "Bianchi");
            Persona gianni = new Persona("Gianni", "Giallo");
            Persona p = new Persona("Mario", "Rossi"); 
            lst_persona.Add(mario);
            lst_persona.Add(maria);
            lst_persona.Add(gianni);

            if(lst_persona.Contains(mario))
                Console.WriteLine("Persona is in list");
            else
                Console.WriteLine("Persona is not in list");

            Console.WriteLine(p.Equals(mario)); // p e mario all'inizio sono puntatori, ma posso modificare Equals nella classe persona 
            Console.WriteLine(p.GetHashCode()); // GetHashCode fa hash del binario dell'istanza 
            Console.WriteLine(mario.GetHashCode()); //hash e' uguale per stessa istanza
       
            
        
        }



        /// <summary>
        /// TEST PROBLEMA: ESERCIZIO 30/10 (aprire un file di testo in scrittura e scriverci cento interi casuali, poi leggerli e stamparli)
        /// </summary>
        private static void TestProblema()
        {
            String dir = @"C:\Users\giulia.soresini\Desktop\Microsoft Academy for Girls\WEEK 1-3";
            String name_file = "randomfile.txt";
            string line;
            String path = dir + @"\" + name_file; // creo il percorso del file concatenando stringhe
            int c1 = 1001; // mi da' eccezione che solleva il metodo random number e quindi vado direttamente al catch saltando riga 75
            int c2 = 1000;
            System.IO.StreamWriter filerand = new System.IO.StreamWriter(System.IO.Path.Combine(dir, name_file));
            for (int i = 0; i < 100; i++)
            {
                try
                {
                    int n = Academy.Helper.RandomHelper.randomNumber(c1, c2);
                    filerand.WriteLine(n);
                }
                catch (Academy.Helper.RandomArgumentsException excp) //mi sono scritta io l'eccezione per gestire ordine errato dei parametri
                {
                    System.Console.WriteLine(excp.Message); //ho riscritto la proprieta' message dell'eccezione
                    break;
                }
            }
            filerand.Close();
            System.IO.StreamReader fileread = new System.IO.StreamReader(path);
            while ((line = fileread.ReadLine()) != null) // quella tra paresntesi si chiama guardia ed e' un espressione booleana
            {
                int randomInt = 0; ;

                try
                {
                    randomInt = Int32.Parse(line);
                }
                catch (FormatException excp) // mi aspetto eccezione di formato 
                {

                    Console.WriteLine(excp.Message);
                }
                Console.WriteLine(randomInt+1000);

            }
            fileread.Close();
            System.Console.ReadLine();
        }




        /// <summary>
        /// TEST LOOPS: 29/10 per liste, CICLI FOR E FOR EACH
        /// </summary>
        private static void TestLoops()
        {
            //declare string 
            string s = "Ciaonee";
            char[] c1 = s.ToCharArray(); //STRING TO ARRAY OF CHAR
            char[] new_Arr = new char[c1.Length];
            string s2 = "";
           
            for (int i = 0; i < c1.Length/2; i++) // ciclo per invertire array
            {

            //     new_Arr[i] = c1[c1.Length-i-1];
            char tmp = c1[i];
            c1[i] = c1[c1.Length - i - 1];
            c1[c1.Length - i - 1] = tmp;
                // per fare stringa concateno qui 
               

            }
            for (int i = 0; i < c1.Length; i++)
            {
                s2 += c1[i]; //CONCATENO I CARATTERI PER FORMARE UNA STRINGA CHE PRIMA HO DICHIARATO VUOTA

            }
            //System.Console.WriteLine(s2);
            //System.Console.ReadLine();

            List<char> charList = new List<char>();
            for (int i = 64; i < 74; i++) //codici ascii
            {
                char n = (char)(i + 1); // oppute ToChar
         
                charList.Add(n);
            }
            char[] characters = new char[charList.Count()]; //lunghezza lista .Count
            int len = characters.Length;
            int count = 0;

            foreach (char c in charList) //ciclo sul singolo elemento della collection

            {
                characters[len - count - 1] = c;
                count++;
            }
            List<char> charList2 = characters.ToList();

            foreach (char c in charList2)
            {

                System.Console.WriteLine(c);

            }

            System.Console.ReadLine();
        }



        /// <summary>
        /// TEST GEOMETRY ABSTRACT E PRINT FIGURE ABSTRACT: 29/10 per classi astratte
        /// uso Academy.GeometryAbstract
        /// </summary>
        private static void TestGeometryAbstract()
        {
            GeometryAbstract.Quadrato q1 = new GeometryAbstract.Quadrato(11.009); //questo quadrato per ora e' della libreria Academy.Geometry 
            GeometryAbstract.Cerchio c1 = new GeometryAbstract.Cerchio(9.25); //questo quadrato per ora e' della libreria Academy.Geometry 

            PrintFiguraAbstract(q1);
            PrintFiguraAbstract(c1);


        }
        private static void PrintFiguraAbstract(GeometryAbstract.FiguraGeometrica f) 
        {
            string s = f.GetDescription(); //metodo non astratto della classe astratta FiguraGeometrica che viene ereditato da quadrato e cerchio
            System.Console.WriteLine(s);
            System.Console.ReadLine();
           
        }



        /// <summary>
        ///  TEST GEOMETRY, PRINT FIGURA, PRINT CERHIO E PRINT QUADRATO: 28/10 per interfacce
        ///  uso Academy.Geometry
        /// </summary>
        private static void TestGeometry()
        {
            Academy.Geometry.Quadrato q11 = new Academy.Geometry.Quadrato(12.98); //al posto di usare using uso lo spazio dei nomi epr evitare confusione se chiamo quadrato la classe in un altro assebly
            Academy.Geometry.Cerchio c11 = new Academy.Geometry.Cerchio(11.75);
            Academy.Geometry.Rettangolo r11 = new Academy.Geometry.Rettangolo(11.77, 33.99);
            Academy.Geometry.Triangolo t11 = new Academy.Geometry.Triangolo(3, 4, 5);
            //System.Console.WriteLine("Quadrato: Area {0}, Perimetro {1}", q1.GetArea(), q1.GetPerimetro());
            //System.Console.WriteLine("Cerchio: Area {0}, Perimetro {1}", c1.GetArea(), c1.GetPerimetro());
            //System.Console.ReadLine();

           // PrintQuadrato(q1); //metodi per stamparli singolarmente senza interfaccia, se uso interfaccia uso PrintFigura
           // PrintCerchio(c1);
            
            PrintFigura(q11); //PASSO UN'ISTANZA CHE IMPLEMENTI L'INTERFACCIA IFiguraGeometrica che ho passato come parametro di input al metodo
            PrintFigura(c11);
            PrintFigura(r11);
            PrintFigura(t11);

            System.Console.ReadLine();
        }
        private static void PrintFigura(Academy.Geometry.IFiguraGeometrica f) //passo qualsiasi classe che implementi figura geometrica
        {
            System.Console.WriteLine(" Area {0}, Perimetro {1}", f.GetArea(), f.GetPerimetro());
            // cosi posso dare qualsiasi figura in input 
        }
        private static void PrintCerchio(Cerchio c1)
        {
            System.Console.WriteLine("Cerchio: Area {0}, Perimetro {1}", c1.GetArea(), c1.GetPerimetro());
            //uso lo stesso comportamento che hanno sia il cerchio che il quadrato per cui posso ridurre a un metodo 
        }
        private static void PrintQuadrato(Quadrato q1)
        {
            System.Console.WriteLine("Quadrato: Area {0}, Perimetro {1}", q1.GetArea(), q1.GetPerimetro());
        }



        /// <summary>
        /// TEST PERSONA: 28/10
        /// CREO PROGETTO HUMAN RESOURCES (ASSEMBLY) E CI AGGIUNGO LE CLASSI CHE MI SERVONO (CONCETTI DI PRIVATE, PUBLIC ECC E DOWNCAST)
        /// USO HUMAN RESOURCES
        /// </summary>
        private static void TestHR()
        {
            Persona Giulia = new Persona("Giulia", "Soresini"); //istanzio una persona
            
            Impiegato imp = new Impiegato(); // sta sempre dentro human resources

           
            System.Console.WriteLine(Giulia.ToString());// sono inaccessibili per protection level nome e congome, cosi' stampo l'istanza giulia (metodo concreto della classe object)
           //il metodo to string stampa il tipo dell'istanza di default, ma io volevo stampare nome cognome e indirizzo, quindi faccio override
            System.Console.ReadLine();

        }



        /// <summary>
        /// TEST SPLIT: 27/10
        /// testing how splitting a string in an array works (s.Split(chararray))
        /// </summary>
        private static void TestSplit()
        {
            // using String[] Split(char[] separator, StringSplitOptions options);
            // metodo split della classe string che vuole in input un array di caratteri e mi rida' un array di stringhe
            string s = "25.67\t998.41";
            char[] chararray = new char[1]; 
            chararray[0] = '\t';
            String[] resultarray = s.Split(chararray); // applico il metodo split alla stringa s
            string temperature = resultarray[0];
            string pressione = resultarray[1];
            float temp_float = float.Parse(temperature, CultureInfo.InvariantCulture);
            float press_float = float.Parse(pressione, CultureInfo.InvariantCulture);
            System.Console.WriteLine("Temperatura {0}, Pressione {1}", temp_float, press_float); //vwtabtab
            System.Console.ReadLine();
        }




        /// <summary>
        /// TEST READ FILE: 27/10
        /// READS A PRESSURE AND TEMPERATURE FILE, SPLITS EACH STRING IN AN ARRAY OF STRINGS AND CONVERTS EACH ELEMENT IN A FLOAT, THEN FINDS MAX AND MIN
        /// </summary>
        private static void TestReadFile()
        {
            // lettura file di testo (dati) 
            String dir = @"C:\Users\giulia.soresini\Desktop\Microsoft Academy for Girls\WEEK 1-3";
            // per stampare su due righe \r\n quindi ora sta interpretando come caratteri di escape
            // quindi o metto doppio backslash oppure metto chiocciola davanti ai doppi apici
            String filename = "pressione.txt";
            String path = dir + @"\" + filename; // creo il percorso del file concatenando stringhe

            String out_temp = "temperature.txt";
            String out_press = "press.txt";

            System.IO.StreamWriter tempoutputfile = new System.IO.StreamWriter(System.IO.Path.Combine(dir, out_temp));
            System.IO.StreamWriter pressoutputfile = new System.IO.StreamWriter(System.IO.Path.Combine( dir, out_press));

            // Path.combine costruisce lui il path
            int counter = 0;
            string line;
            // Read the file and display it line by line.  
            System.IO.StreamReader file = new System.IO.StreamReader(path); // istanza stream readerposizionata all'inizio del file pressione.txt nel path che gli do'
                                                                            // a sinistra del'uguale dichiaro una variabile oggetto chiamata file che e' un istanza di stream reader

            // classe e' StreamReader con spazio dei nomi System.IO l'assembly e' mscorlib.dll 

            // uno stream e' un oggetto che puo' leggere un flusso di byte da un percorso di rete o da una scheda di rete
            float max_float = float.MaxValue;
            float min_float = float.MinValue;

            float min_temp = max_float;
            float min_press = max_float;
            float max_temp = min_float;
            float max_press = min_float;

            float sum_press = 0;
            float sum_temp = 0;

            char[] chararray = new char[1]; // se scrivessi char[] ca starei dichiarando un puntatore vuoto
            chararray[0] = '\t';

            while ((line = file.ReadLine()) != null) // quella tra paresntesi si chiama guardia ed e' un espressione booleana
            {
                // ReadLine e' un metoso della classe StreamReader 
                // line contiene di volta in volta la riga corrente (fino a carriage return)
                if (counter>0) // non sono nella prima riga
                {
                    String[] resultArray = line.Split(chararray);
                    float temp_float =float.Parse(resultArray[0], CultureInfo.InvariantCulture);
                    float press_float = float.Parse(resultArray[1], CultureInfo.InvariantCulture);
                    tempoutputfile.WriteLine(temp_float); // scrivo su due file diversi 
                    pressoutputfile.WriteLine(press_float);

                    sum_press = sum_press + press_float;
                    sum_temp = sum_temp + temp_float;

                    if (temp_float < min_temp)
                    {
                        min_temp = temp_float;
                    }
                    if (temp_float > max_temp)
                    {
                        max_temp = temp_float;
                    }
                   
                    
                    if (press_float < min_press)
                    { // non servono con una sola istruzione
                        min_press = press_float; 
                    }
                    if (press_float > max_press)
                    {
                        max_press = press_float;
                    }
                   

                }
                
                
                counter++;
            }
          
           file.Close(); // chiudo stream di byte 
            tempoutputfile.Close();
            pressoutputfile.Close();
            float avg_press = sum_press / (counter - 1); 
            float avg_temp = (sum_temp) / (counter - 1);
          
            System.Console.WriteLine("Max press {0}, Min press {1}, Max temp {2}, Min temp{3}", max_press, min_press, max_temp, min_temp);
            System.Console.WriteLine("Avg press {0}, Avg press {1}", avg_press, avg_temp);
            System.Console.WriteLine("There were {0} lines.", counter); // parentesi graffa prende dentro la variagbile counter
            System.Console.ReadLine();                                                        // Suspend the screen.  
        }
    }
}
