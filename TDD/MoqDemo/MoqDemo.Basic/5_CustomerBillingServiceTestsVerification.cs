using System;
using Moq;
using MoqDemo.Basic.CodeUnderTest;
using NUnit.Framework;

namespace MoqDemo.Basic
{
    [TestFixture]
    public class CustomerBillingServiceTestsVerification
    {
        [Test]
        public void ShouldBeAbleToGetTotalAmountDueForClient()
        {
            //Arrainge
            var customerDataServiceMock = new Mock<ICustomerDataService>();
            var customerMock = new Mock<ICustomerAccountService>();
            var customerId = Guid.NewGuid();
            var mowingCharge = 10;
            var wateringCharge = 15;
            var weedingCharge = 25;
            var customerName = "Bob";
            var expectedTotal = mowingCharge + wateringCharge + weedingCharge;

            customerMock.Setup(x => x.GetMowingCharge()).Returns(mowingCharge);
            customerMock.Setup(x => x.GetWateringCharge()).Returns(wateringCharge);
            customerMock.Setup(x => x.GetWeedingCharge()).Returns(weedingCharge);
            customerMock.Setup(x => x.Name).Returns(customerName);

            customerDataServiceMock.Setup(x => x.GetCustomerAccount(customerId))
                .Returns(customerMock.Object);

            var customerBillingService = new CustomerBillingService(customerDataServiceMock.Object);
            //Act 
            var result = customerBillingService.GetCustomerCurrentAmountDue(customerId);

            //Assert
            customerMock.Verify(x => x.WillNeverEverBeCalled(), Times.Never);
            customerDataServiceMock.Verify(x => x.GetCustomerAccount(customerId) , Times.Once);

            Assert.AreEqual(expectedTotal, result);
        }
    }
}