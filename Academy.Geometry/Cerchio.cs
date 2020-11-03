using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Geometry
{
    public class Cerchio : IFiguraGeometrica 
    {
        private double raggio;

        public Cerchio(double raggio) //costruttore
        {
            this.raggio = raggio;

        }
        public double GetArea() //lo sa gia' il suo lato 

        {
            return raggio*raggio*Math.PI; //non serve diambiguare
            //di Math o Console non ho creato un istanza prima di usare un suo metodo

        }
        public double GetPerimetro() //lo sa gia' il suo lato 

        {
            return 2 * this.raggio*Math.PI; //non serve diambiguare

        }
    }

}
