using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Helper;
namespace Academy.Termometro
{
    public class Program
    {
        static void Main(string[] args)
        {

            Termometro term = new Termometro();
            S1 sub1 = new S1(term);
            S2 sub2 = new S2(term);
            S3 sub3 = new S3(term);
            for (int i = 0; i < 50; i++)
            {
                term.SimulateTemp(RandomHelper.randomdouble(20, 30));
            }
            
        }
    }
}
