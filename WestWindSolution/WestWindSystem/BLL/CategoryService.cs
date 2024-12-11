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
    public class CategoryService
    {
        private readonly WestWindContext _context;

        internal CategoryService(WestWindContext registeredContext)
        {
            _context = registeredContext;
        }

        #region Add, Update, and Delete methods
        public int AddCategory(Category newCategory)
        {
            // Throw an ArgumentNullException if newCategory has no value
            if (newCategory == null)
            {
                throw new ArgumentNullException("A Category instance must be supplied");
            }
            // Business rule: CategoryName must be unqiue
            bool categoryNameExists = _context.Categories.Any(c => c.CategoryName == newCategory.CategoryName);
            if (categoryNameExists)
            {
                throw new ArgumentException($"The category name {newCategory.CategoryName} already exists");
            }
           
            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return newCategory.CategoryID;
        }
        public int UpdateCategory(Category updatedCategory)
        {
            // https://learn.microsoft.com/en-us/ef/core/change-tracking/identity-resolution
            // Query then apply changes
            Category trackedCategory = GetById(updatedCategory.CategoryID);
            // Copy all the values from existingProduct to set them on the trackedProduct 
            _context.Entry(trackedCategory).CurrentValues.SetValues(updatedCategory);  

            int rowsUpdated = _context.SaveChanges();
            return rowsUpdated;
        }
        public int DeleteCategory(int categoryID)
        {
            // Find the Category entity with the matching categoryID value
            Category? existingCategory = _context.Categories.SingleOrDefault(c => c.CategoryID == categoryID);
            // Throw an ArgumentException if cateogryID does not exists
            if (existingCategory == null)
            {
                throw new ArgumentException($"CategoryID {categoryID} not found in the database.");
            }
            // Business Rule: a Category with existing Products cannot be deleted.
            if (existingCategory.Products.Count > 0)
            {
                throw new ArgumentException("This category has assoicated products and cannot be deleted.");
            }
            // Mark the existingCategory for deletion
            _context.Categories.Remove(existingCategory);
            int rowsDeleted = _context.SaveChanges();
            return rowsDeleted;
        }
        #endregion

        #region Query methods
        public Category? GetById(int CategoryID)
        {
            return _context.Categories.SingleOrDefault(c => c.CategoryID == CategoryID);
        }
        public List<Category> Category_GetList()
        {
            var query = _context
                        .Categories
                        .OrderBy(x => x.CategoryName)
                        .AsNoTracking();
            return query.ToList();
        }

        #endregion
    }
}
