using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Geometry
{
    public class Quadrato : IFiguraGeometrica  // implementa interfaccia 
    {
        private double lato;



        public Quadrato(double lato) //passo solo qui il lato, non nei metodi comuni dell'nterfaccia 
        {
            this.lato = lato; //this. per evitare ambiguita, thi.lato e' la variabile alto di questa istanza

        }

        public double GetArea() //lo sa gia' il suo lato 

        {
            return lato * lato; //non serve diambiguare ma se lo faccio no errore


        }
        public double GetPerimetro() //lo sa gia' il suo lato 

        {
            return 4*lato; //non serve diambiguare

        }
    }
}
