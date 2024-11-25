using Microsoft.EntityFrameworkCore;
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
                //.Where(p => p.Discontinued == false)
                //.Where(x => x.CategoryID == categoryID)
                .Where(p => p.Discontinued == false && p.CategoryID == categoryID)
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .AsNoTracking()
                .OrderBy(x => x.ProductName);
            return query.ToList();
        }

        #region CRUD methods
        private void ValidateProduct(Product existingProduct)
        {
            if (existingProduct == null)
            {
                throw new ArgumentNullException(nameof(existingProduct),"A product is required");
            }
        }
        public int AddProduct(Product newProduct)
        {
            ValidateProduct(newProduct);
            newProduct.Discontinued = false;
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct.ProductID;
        }
        public int UpdateProduct(Product existingProduct)
        {
            ValidateProduct(existingProduct);
            _context.Products.Update(existingProduct);
            return _context.SaveChanges();
        }
        public int DiscontinueProduct(int productID)
        {
            Product? existingProduct = _context.Products.FirstOrDefault(p => p.ProductID == productID);
            if (existingProduct != null)
            {
                existingProduct.Discontinued = true;
                _context.Products.Update(existingProduct);
            }
            return _context.SaveChanges();
        }


        #endregion
    }
}
