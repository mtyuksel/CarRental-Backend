
namespace CarRental.Business.Constants
{
    public static class Messages
    {
        #region Validation Message
        public static string CarPriceNotValid = "Car price is not valid!";
        public static string CarNameNotValid = "Car name is not valid!";
        public static string CarNameAndPriceNotValid = "Car name and price are not valid!";
        public static string PasswordNotStrongEnough  = "Your password has to contain at least one lowercase, one uppercase, one digit and one symbol!";
        #endregion

        #region Error Messages
        public static string CarAlreadyRented = "The Car Has Already Rented!";
        public static string CountOfCarForBrandError = "The Brand Has Too Many Cars!";
        public static string CarImageLimitExceeded = "Cars Can Have Maximum 5 Images!";
        public static string CarNotFound = "The Car Not Found!";
        public static string ImagePathNotUnique = "This image path has been registered before. Please use different image name!";
        public static string ImagePathNotFound = "There is no image for given image name!";
        public static string AuthorizationDenied = "Authorization Denied!";
        public static string UserRegistered = "Registered successfuly.";
        public static string UserNotFound = "User Not Found!";
        public static string PasswordError = "Password Error!";
        public static string SuccessfulLogin = "Logined successfuly.";
        public static string AccessTokenCreated = "Access token successfuly created.";
        #endregion

        #region Success Messages
        public static string SuccesfullyUpdated = "Successfully updated.";
        public static string SuccesfullyAdded = "Successfully added.";
        public static string SuccesfullyDeleted = "Successfully deleted.";
        #endregion

        public static string MaintenanceTime = "The service is under maintenance. Please try again in 1 hour.";

        #region Schemas
        private static string _schemaShouldGraterThan = "{0} has to be grater than {1}!";
        private static string _schemaAlreadyExist = "The {0} already exist!";
        private static string _schemaNotExist = "The {0} is not exist!";
        private static string _schemaNotFound = "The {0} not found!";
        #endregion

        public static string ShouldGraterThan(string shouldGraterItem, string minValue) 
        {
            return string.Format(_schemaShouldGraterThan, shouldGraterItem, minValue);
        }

        public static string AlreadyExist(string existItem)
        {
            return string.Format(_schemaAlreadyExist, existItem.ToLower());
        }
        
        public static string NotExist(string notExistItem)
        {
            return string.Format(_schemaNotExist, notExistItem.ToLower());
        }

        public static string NotFound(string notFoundItem)
        {
            return string.Format(_schemaNotFound, notFoundItem.ToLower());
        }
    }
}
