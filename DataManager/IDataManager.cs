using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Academy.Entities;
namespace Academy.DataManager
{
    public interface IDataManager
    {
         bool LoginIsOK(string username, string password);
        bool UserIsAnOwner(string username);
        DataOperationResult CreateNewCliente(Cliente newCliente);
        ContoCorrente GetContoCorrenteByUsername(string username);
        DataOperationResult AggiornaFileMovimenti(Movimento mov);
    }
}
