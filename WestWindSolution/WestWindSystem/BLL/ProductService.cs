using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class ProductService
    {
        private readonly WestWindContext _context;

        internal ProductService(WestWindContext registeredContext)
        {
            _context = registeredContext;
        }

        public List<Product> Products_GetByCategory(int categoryID)
        {
            var query = _context
                .Products
                .Where(x => x.CategoryID == categoryID)
                .OrderBy(x => x.ProductName);
            return query.ToList();
        }
    }
}
