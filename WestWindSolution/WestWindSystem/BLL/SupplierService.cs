using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class SupplierService
    {
        private readonly WestWindContext _context;

        internal SupplierService(WestWindContext registerContext)
        {
            _context = registerContext;
        }

        public List<Supplier> GetAll()
        {
            var query = _context
                .Suppliers
                .OrderBy(s => s.CompanyName);
            return query.ToList();
        }
    }
}
