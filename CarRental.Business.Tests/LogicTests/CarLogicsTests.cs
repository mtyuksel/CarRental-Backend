using CarRental.Business.Constants;
using CarRental.Business.Logics;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entity.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CarRental.Business.Tests.LogicTests
{
    [TestClass]
    public class CarLogicsTests
    {
        Mock<ICarDal> _carDalMock;

        [TestInitialize]
        public void TestInitialize()
        {
            _carDalMock = new Mock<ICarDal>();
        }

        [TestMethod]
        public void CheckIfCarNotExists_Returns_ErrorResult_With_Right_Error_Message_When_Car_Exist()
        {
            SetCarDalMockGetReturnValue(false);

            var result = CarLogics.CheckIfCarNotExists(_carDalMock.Object, new Car());

            Assert.IsInstanceOfType(result, typeof(ErrorResult));
            Assert.AreEqual(result.Message, Messages.AlreadyExist("car"));
        }

        [TestMethod]
        public void CheckIfCarNotExists_Returns_SuccessResult_When_Car_Not_Exist()
        {
            SetCarDalMockGetReturnValue(true);

            var result = CarLogics.CheckIfCarNotExists(_carDalMock.Object, new Car());

            Assert.IsInstanceOfType(result, typeof(SuccessResult));
        }

        [TestMethod]
        public void CheckIfCarExists_Returns_SuccessResult_When_Car_Exist()
        {
            SetCarDalMockGetReturnValue(true);

            var result = CarLogics.CheckIfCarExists(_carDalMock.Object, new Car());

            Assert.IsInstanceOfType(result, typeof(ErrorResult));
            Assert.AreEqual(result.Message, Messages.NotExist("car"));
        }

        [TestMethod]
        public void CheckIfCarExists_Returns_ErrorResult_With_Right_Error_Message_When_Car_Not_Exist()
        {
            SetCarDalMockGetReturnValue(false);

            var result = CarLogics.CheckIfCarExists(_carDalMock.Object, new Car());

            Assert.IsInstanceOfType(result, typeof(SuccessResult));
        }

        [TestMethod]
        public void CheckIfCarCountOfBrandCorrect_Returns_ErrorResult_With_Right_Error_Message_When_Car_Brand_Is_Older_Than_3()
        {
            SetCarDalMockGetReturnValue(false);

            _carDalMock.Setup(x => x.GetAll(It.IsAny<Expression<Func<Car, bool>>>())).Returns(new List<Car>() { new Car(), new Car(), new Car(), new Car() });
            var result = CarLogics.CheckIfCarCountOfBrandCorrect(_carDalMock.Object, 1);

            Assert.IsInstanceOfType(result, typeof(ErrorResult));
            Assert.AreEqual(result.Message, Messages.CountOfCarForBrandError);
        }

        private void SetCarDalMockGetReturnValue(bool isnull)
        {
            if (isnull)
            {
                _carDalMock.Setup(x => x.Get(It.IsAny<Expression<Func<Car, bool>>>())).Returns((Car)null);
            }
            else
            {
                _carDalMock.Setup(x => x.Get(It.IsAny<Expression<Func<Car, bool>>>())).Returns(new Car());
            }
        }
    }
}
