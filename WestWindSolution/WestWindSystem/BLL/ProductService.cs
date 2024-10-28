using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    public class ProductService
    {
        private readonly WestWindContext _context;

        internal ProductService(WestWindContext registeredContext)
        {
            _context = registeredContext;
        }
    }
}
