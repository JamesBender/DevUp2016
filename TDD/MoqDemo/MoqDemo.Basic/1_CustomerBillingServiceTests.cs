using System;
using Moq;
using MoqDemo.Basic.CodeUnderTest;
using NUnit.Framework;

namespace MoqDemo.Basic
{
    [TestFixture]
    public class CustomerBillingServiceTests
    {
        [Test]
        public void ShouldBeAbleToGetTotalAmountDueForClient()
        {
            //Arr
            var customerDataServiceMock = new Mock<ICustomerDataService>();
            var customerAccountMock = new Mock<ICustomerAccountService>();

            var customerId = Guid.NewGuid();
            var mowingCharge = 10;
            var wateringCharge = 15;
            var weedingCharge = 25;
            var customerName = "Bob";
            var expectedTotal = mowingCharge + wateringCharge + weedingCharge;

            customerAccountMock.Setup(x => x.GetMowingCharge()).Returns(mowingCharge);
            customerAccountMock.Setup(x => x.GetWateringCharge()).Returns(wateringCharge);
            customerAccountMock.Setup(x => x.GetWeedingCharge()).Returns(weedingCharge);
            customerAccountMock.Setup(x => x.Name).Returns(customerName);

            customerDataServiceMock.Setup(x => x.GetCustomerAccount(customerId))
                .Returns(customerAccountMock.Object);
            
            var customerBillingService = new CustomerBillingService(customerDataServiceMock.Object);
           
            //Act 
            var result = customerBillingService.GetCustomerCurrentAmountDue(customerId);

            //Assert
            Assert.AreEqual(expectedTotal, result);
        }
    }
}