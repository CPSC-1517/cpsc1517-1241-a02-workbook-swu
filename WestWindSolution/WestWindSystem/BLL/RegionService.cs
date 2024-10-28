using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;

namespace WestWindSystem.BLL
{
    public class RegionService
    {
        private readonly WestWindContext _context;

        internal RegionService(WestWindContext registeredContext)
        {
            _context = registeredContext;
        }
    }
}
