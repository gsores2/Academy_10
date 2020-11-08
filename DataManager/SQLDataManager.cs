using Academy.Entities;
using DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.DataManager
{
    public class SQLDataManager : IDataManager

    {
         public DataOperationResult AggiornaFileMovimenti(Movimento mov)
        {
            throw new NotImplementedException();
        }

        public DataOperationResult CreateNewCliente(Cliente newCliente)
        {
            throw new NotImplementedException();
        }

        public ContoCorrente GetContoCorrentByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public ContoCorrente GetContoCorrenteByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public bool LoginIsOK(string username, string password)
        {
            throw new NotImplementedException();
        }
        public bool UserIsAnOwner(string username)
        {

            throw new NotImplementedException();
        }
    }
}
