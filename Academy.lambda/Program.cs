using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.lambda
{
    public delegate bool FilterInt(int i); 
    class Program
    {
        static void Main(string[] args)
        {

            List<int> lst = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // costruisco lsita input
        
            //passaggio di un metodo x a un metodo y
            FilterInt filterOdd = new FilterInt(IsOdd); // costruisco il filtro che è un delegate di tipo FilterInt                               
            //1 List<int> result = FilterInts(lst, filterOdd); //passo il delegate

            //2  oppure List <int> result= FilterInts(lst, IsEven); // passo direttamente il metodo e lui fa il delegate

            // 3 oppure lambda expression (che è un delegate sintatticamente
            List<int> result = FilterInts(lst, i => (i % 2) == 1);
            // la stessa lambda expression posso scriverla cosi:  List<int> result = FilterInts(lst, i => (i & 2) == 1);
            // & bit a bit 


            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }



        public static bool IsOdd(int x) // è un metodo con la stessa firma del delegate
        {
            return (x % 2) == 1;
        }
        // creo un metodo che mi ritorna una lista di interi a partire da una lista di interi e u
        // e da un delegate (FilterInts non sa come impleenta il filreo FilterInt fitler)



        public static List<int> FilterInts(List<int> inputlst, FilterInt filter) //metodo y a cui voglio passare metodo x

        {
            List<int> resultList = new List<int>(); // creo lista vuota, va creata ma non inizializzata 
            foreach (var item in inputlst)
            {
                if (filter(item)) // filter è un delegate che contiene l'indirizzo di IsOdd, quindi sto invocando il metodo col putnatore
                    resultList.Add(item); 

            }
            return resultList;
        }
    }

    
}
