using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GeometryAbstract
{
    public class Quadrato : FiguraGeometrica //Quadrat:FiguraGeometrica non va bene quindi o class la metto abstract 
    {

        private double lato;


        public Quadrato(double lato) //passo solo qui il lato, non nei metodi comuni dell'nterfaccia 
        {
            this.lato = lato; //this. per evitare ambiguita, thi.lato e' la variabile alto di questa istanza

        }

        public override double GetArea() //lo sa gia' il suo lato 

        {
            return lato * lato; //non serve diambiguare ma se lo faccio no errore


        }
        public override double GetPerimetro() //lo sa gia' il suo lato 

        {
            return 4 * lato; //non serve diambiguare

        }
    }
}

