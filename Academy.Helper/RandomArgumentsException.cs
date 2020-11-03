using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Helper
{
    public class RandomArgumentsException : Exception //ogni eccezione eredita dalla classe exception
    {
        
        public override string Message //proprieta' message e' virtual, epr cui posso fare override e dare i mio messaggio 

        {
            get //modirico il getter
            {
                return " Min is greater than max"; // faccio override del metodo

            }
        }
    }

}
