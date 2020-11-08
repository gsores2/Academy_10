using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Entities
{
    public class Movimento
    {   
        public string NumConto { get; set; }
        public TipoMovimento Tipo { get; set; }
        public double Importo { get; set; }
        public DateTime Data { get; set; }
        public string Beneficiario { get; set; }
    }
}
