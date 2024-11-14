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
    public class ShipperService
    {
        private readonly WestWindContext _context;

        internal ShipperService(WestWindContext context)
        {
            _context = context;
        }

        #region Create, Update, Delete methods
        public int AddShipper(Shipper newShipper)
        {
            // Add the newShipper entity to the Shippers DbSet
            _context.Shippers.Add(newShipper);
            // Save the changes to the database
            _context.SaveChanges();
            // Return the generated ShipperID value
            return newShipper.ShipperID;
        }
        public int UpdateShipper(Shipper existingShipper)
        {
            // https://learn.microsoft.com/en-us/ef/core/change-tracking/identity-resolution
            // Query then apply changes
            //var trackedShipper = _context.Shippers.Find(existingShipper.ShipperID);
            // Copy all the values from existingShipper to set them on the trackedShipper
            //_context.Entry(trackedShipper).CurrentValues.SetValues(existingShipper);

            _context.Shippers.Update(existingShipper);
            // Save changes and return the number of rows update
            return _context.SaveChanges();
        }
        public int DeleteShipper(int shipperID)
        {
            // Find the Shipper that matches the shipperID value
            Shipper? existingShipper = _context
                .Shippers
                .Where(x => x.ShipperID == shipperID)
                .FirstOrDefault();
            if (existingShipper == null)
            {
                throw new ArgumentException($"The shipper {shipperID} does not exists");
            }
            // Remove the existingShipper from the database
            _context.Shippers.Remove(existingShipper);
            // Return the number of rows deleted
            return _context.SaveChanges();
        }
        #endregion

        #region Query methods
        public List<Shipper> GetShippers()
        {
            return _context.Shippers.ToList();
        }
        public Shipper? GetShipper(int shipperID)
        {
            return _context.Shippers.Find(shipperID);
        }
        #endregion
    }
}
