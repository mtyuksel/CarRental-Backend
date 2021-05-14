using CarRental.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Constants
{
    public static class Messages
    {
        #region Error Messages
        public static string CarPriceNotValid = "Car price is not valid!";
        public static string CarNameNotValid = "Car name is not valid!";
        public static string CarNameAndPriceNotValid = "Car name and price are not valid!";
        public static string CarHasNotYetBeenReturned = "The car has not yet been returned!";
        #endregion

        #region Success Messages
        public static string SuccesfullyUpdated = "Successfully updated.";
        public static string SuccesfullyAdded = "Successfully added.";
        public static string SuccesfullyDeleted = "Successfully deleted.";
        #endregion

        public static string MaintenanceTime = "The service is under maintenance. Please try again in 1 hour.";

        #region Schemas
        private static string _schemaShouldGraterThan = "{0} has to be grater than {1}!";
        #endregion

        public static string ShouldGraterThan(string property, string minValue) 
        {
            return string.Format(_schemaShouldGraterThan, property, minValue);
        }
    }
}
