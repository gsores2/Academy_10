using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Geometry
{
    public interface IFiguraGeometrica //LA CREO COME INTERFACCIA DIRETTAMENTE (ADD NEW ITEM, CODE, INTERFACE)
    {
        double GetArea(); // firma del metodo getarea (chi implementa quest'interfaccia dovrà avere il suo metodo get area)
        double GetPerimetro();

        // se volessi mettere diagonale poi in quadrato e cerchio mi darebbe errore IFiguraGemetrica quando la implemento
        // in quadrato la posso aggiugnere senza peoblemi mentre in cerchio metto GetDiagonale e restituisco 0

    }
}
