using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GeometryAbstract
{
    public class Cerchio :FiguraGeometrica
    {
        private double raggio;

        public Cerchio(double raggio) //costruttore
        {
            this.raggio = raggio;

        }
        public override double GetArea() //lo sa gia' il suo lato 

        {
            return raggio * raggio * Math.PI; //non serve diambiguare
            //di Math o Console non ho creato un istanza prima di usare un suo metodo

        }
        public override double GetPerimetro() //lo sa gia' il suo lato 

        {
            return 2 * this.raggio * Math.PI; //non serve diambiguare

        }
    }

}
