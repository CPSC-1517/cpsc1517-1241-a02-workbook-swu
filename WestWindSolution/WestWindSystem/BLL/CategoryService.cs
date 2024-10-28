using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{
    public class CategoryService
    {
        private readonly WestWindContext _context;

        internal CategoryService(WestWindContext registeredContext)
        {
            _context = registeredContext;
        }

        #region Query methods
        public List<Category> Category_GetList()
        {
            var query = _context
                        .Categories
                        .OrderBy(x => x.CategoryName);
            return query.ToList();
        }

        #endregion
    }
}
