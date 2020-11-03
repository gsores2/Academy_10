using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.GeometryAbstract
{
    public abstract class FiguraGeometrica //classe astratta, la aggiungo come classe 
    {
        //deve avere due metodi astratti, getarea e get perimetro di cui dichiaro solo la firma
        public abstract double GetArea(); //dichairo due metodi abstract ma non sono in una classe abstract 
        public abstract double GetPerimetro();

        public string GetDescription() //metodo non astratto ereditato dalle classse che ereditano 
        { 
            Type t = this.GetType(); //ereditato da object, da' il tipo dell'istanza in ui mi trovo
            string mytype = t.ToString();
            string description = "I am a: " + mytype + "with Area:" + GetArea() + "Perimetro:" + GetPerimetro();
            //sto concatenando stringhe con risultati di invocazioni emtodo
            return description;
        }
    }
}
