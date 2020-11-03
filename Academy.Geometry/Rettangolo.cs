using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Geometry
{
    public class Rettangolo : IFiguraGeometrica
    {
        private double l1;
        private double l2;

        public Rettangolo ( double l1, double l2)
        {
            this.l1 = l1;
            this.l2 = l2; 
        }
        public double GetArea()
        {
            return l1 * l2;
        }

        public double GetPerimetro()
        {
            return (l1 * 2) + (l2 * 2);
        }
    }
}
