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
        #region Database Queries
        // Return all Product sorted by ProductName then sorted descending by UnitPrice
        public List<Product> GetAllProducts()
        {
            var query = _context.Products
                .OrderBy(p => p.ProductName)
                .ThenByDescending(p => p.UnitPrice);
            return query.ToList();
        }
        // Return all Products filtered by Discountinued sorted by ProductName
        public List<Product> FindProductsByDiscountinued(bool discontinued)
        {
            var query = _context.Products
                .Where(p => p.Discontinued == discontinued)
                .Include(p => p.Supplier)
                .OrderBy(p => p.ProductName);
            return query.ToList();
        }
      
        // Return all Product filtered a partial ProductName 
        public List<Product> FindProductsByProductName(string partialProductName)
        {
            var query = _context.Products
                            .Where(p => p.ProductName.Contains(partialProductName))
                            .Include(p => p.Supplier)
                            .OrderBy(p => p.ProductName);
            return query.ToList();
        }

        // Return all Product filtered by CategoryID sorted by ProductName
        public List<Product> FindProductsByCategoryID(int categoryID)
        {
            var query = _context.Products
                            .Where(p => p.CategoryID == categoryID)
                            .OrderBy(p => p.ProductName);
            return query.ToList();
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

        public Product? FindProductById(int productID)
        {
            return _context.Products.First(p => p.ProductID == productID);
        }

        #endregion Database Queries

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
                if (existingProduct.Discontinued)
                {
                    throw new ArgumentException($"ProductID is already discontinued.");
                }
                existingProduct.Discontinued = true;
                _context.Products.Update(existingProduct);
            }
            else
            {
                throw new ArgumentException($"ProductID {productID} does not exists in the database.");
            }
            return _context.SaveChanges();
        }


        #endregion
    }
}
