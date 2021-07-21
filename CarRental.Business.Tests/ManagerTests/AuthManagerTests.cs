using CarRental.Business.Abstract;
using CarRental.Business.Concrete;
using CarRental.Business.Constants;
using CarRental.Core.Entity.Concrete;
using CarRental.Core.Utilities.Results;
using CarRental.Core.Utilities.Security.JWT;
using CarRental.Entity.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CarRental.Business.Tests.ManagerTests
{
    [TestClass]
    public class AuthManagerTests
    {
        UserForLoginDTO _userForLoginDTO;
        Mock<IUserService> _userServiceMock;
        Mock<ITokenHelper> _tokenHelperMock;
        IAuthService _authService;

        [TestInitialize]
        public void TestInitialize()
        {
            _userForLoginDTO = new UserForLoginDTO();
            _userForLoginDTO.Email = "a";

            _userServiceMock = new Mock<IUserService>();
            _tokenHelperMock = new Mock<ITokenHelper>();

            _authService = new AuthManager(_userServiceMock.Object, _tokenHelperMock.Object);
        }


        [TestMethod]
        public void Login_Check_If_Given_InValid_UserForLoginDTO_Comes_With_ErrorDataResult()
        {
            var result = _authService.Login(_userForLoginDTO);

            Assert.IsInstanceOfType(result, typeof(ErrorDataResult<User>));
        }

        [TestMethod]
        public void Login_Check_If_Given_InValid_UserForLoginDTO_Comes_With_UserNotFoundMessage()
        {
            var result = _authService.Login(_userForLoginDTO);

            Assert.AreEqual(result.Message, Messages.UserNotFound);
        }
    }
}
