using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bogus;
using CarRental.Core.Entity.Concrete;
using CarRental.Core.CrossCuttingConcerns.Validation.FluentValidation;
using CarRental.Business.ValidationRules.FluentValidation;

namespace CarRental.Business.Tests.ValidationRulesTests
{
    [TestClass]
    public class ValidationRulesTests
    {        
        [TestMethod]
        public void UserValidator_Is_User_Valid()
        {
            User user = GenerateRandomUser();
            ValidationTool.Validate(new UserValidator(), user); 
        }

        private User GenerateRandomUser()
        {
            var userFaker = new Faker<User>("tr")
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.FirstName, x => x.Person.FirstName)
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.PasswordHash, x => x.Random.Bytes(16))
                .RuleFor(x => x.PasswordSalt, x => x.Random.Bytes(16))
                .RuleFor(x => x.LastName, x => x.Person.LastName)
                .RuleFor(x => x.Status, x => x.Random.Bool())
                .RuleFor(x => x.ID, x => x.Random.Int(1, 100));

            return userFaker.Generate();
        }
    }
}
