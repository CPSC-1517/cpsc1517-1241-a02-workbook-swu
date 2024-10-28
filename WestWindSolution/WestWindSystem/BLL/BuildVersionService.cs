using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    public class BuildVersionService
    {
        #region setup of the context connection variable and class constructor
        //any method(aka service) will probably need access to the database
        //this will be done via the context class (WestWindContext)
        //when this service class is instantiated there will be a reference call
        //  by the extension class registration method which call supply the
        //  registered content connection
        private readonly WestWindContext _context;

        internal BuildVersionService(WestWindContext registeredContext)
        {
            _context = registeredContext;
        }
        #endregion

    }
}
