using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Academy.Helper
{
    public class RandomHelper
    { 
        public static int BinaryConversion(string binarystring)
        {
            
           // char[] binaryCharArray = binarystring.ToCharArray(); 
            int[] binary_Array = new int[binarystring.Length];
            int int_decimale = 0;
            bool error = false;
            int len = binarystring.Length;
            // controllo che contenga solo 0 e 1
            for (int i = binarystring.Length-1; i >= 0; i--)
            {
                if (binarystring[i] == '0' || binarystring[i] == '1') // posso indicizzare la stringa
                {
                    string bit_string = binarystring.Substring(i, 1); //substring (il bit che sto considerando in quel momento)

                    binary_Array[i] = Int32.Parse(bit_string); // riempio il mio array di 1 e 0
                }
                else error = true; // controllo di aver inserito solo 0 e 1

              }
            // trasfromo l'array di char in array di int (non mi serve se uso substring )

            //for (int i = 0; i < len; i++)
            //{
            //    binary_Array[i] = Convert.ToInt32(binaryCharArray[i]);
            //}

            int tot = 0;
            for (int i = 0; i < binary_Array.Length; i++)
            {
                int_decimale =  binary_Array[len-i-1];
                tot += int_decimale * (int)Math.Pow(2, i);
            }
            return tot;

        }  
    
           
        public static int randomNumber (int a, int b)
        {
            /// metodo GIULIA 1 
            // Thread.Sleep(100); //sta fermo 100 ms
            //Random rand = new Random(DateTime.Now.Millisecond);
            //if (a > b) // altrimenti sollevo un eccezione come sotTo
            //{
            //    return 0;
            //}

            //return rand.Next(a, b);


           
            if (a > b)
            {
                throw new RandomArgumentsException(); //solleva eccezioen che ho scritto io
            }
            else
            {
                Guid newguid = Guid.NewGuid();
                int hash = newguid.GetHashCode();
                int seed = hash;
                Random rnd = new Random(seed);
                return rnd.Next(a, b);
            }




        }

        public static double randomdouble(double a, double b)
        {
           



            if (a > b)
            {
                throw new RandomArgumentsException(); //solleva eccezioen che ho scritto io
            }
            else
            {
                Guid newguid = Guid.NewGuid();
                int hash = newguid.GetHashCode();
                int seed = hash;
                Random rnd = new Random(seed);
                return rnd.NextDouble() *(b - a) + a;
            }




        }
        public static string randomitem(List<String> lst_descrizione)
        {

                Random rnd = new Random();
                 int r = rnd.Next(lst_descrizione.Count);
                  return lst_descrizione[r];
            




        }
        public static int GetSameInt(int sameint)
        {
            return sameint;
        }

        public static string GetNumConto(int numChars)
        {
            string cc = "";
            if (numChars <= 36 )
            {
                Guid newGuid = Guid.NewGuid();
                string s_newGuid = newGuid.ToString();
                cc = s_newGuid.Substring(0, numChars);
            }
            
            
            return cc;

        }
    }
}
