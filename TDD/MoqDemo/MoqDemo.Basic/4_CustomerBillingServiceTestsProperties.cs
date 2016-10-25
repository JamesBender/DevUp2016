using System;
using Moq;
using MoqDemo.Basic.CodeUnderTest;
using NUnit.Framework;

namespace MoqDemo.Basic
{
    [TestFixture]
    public class CustomerBillingServiceTestsProperties
    {
        [Test]
        public void ShouldBeAbleToSetupNewCustomer()
        {
            //Arr
            var customerDataServiceMock = new Mock<ICustomerDataService>();
            var customerAccountMock = new Mock<ICustomerAccountService>();
            var customerName = "Bob";
            var expectedCustomerId = Guid.NewGuid();

            customerAccountMock.Setup(x => x.CustomerId).Returns(expectedCustomerId);
            customerAccountMock.SetupProperty(x => x.Name);
            
            customerDataServiceMock.Setup(x => x.GetCustomerAccount())
                .Returns(customerAccountMock.Object);

            var customerBillingService = new CustomerBillingService(customerDataServiceMock.Object);

            //Act
            var result = customerBillingService.SetupNewCustomer(customerName);

            //Assert
            Assert.AreEqual(expectedCustomerId, result);
            customerAccountMock.VerifySet(x => x.Name = customerName);
            Assert.AreEqual(customerName, customerAccountMock.Object.Name);
        }
    }
}











