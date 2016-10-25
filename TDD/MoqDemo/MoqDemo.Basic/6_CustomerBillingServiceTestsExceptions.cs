using System;
using Moq;
using MoqDemo.Basic.CodeUnderTest;
using NUnit.Framework;

namespace MoqDemo.Basic
{
    [TestFixture]
    public class CustomerBillingServiceTestsExceptions
    {
        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldGetAnExceptionTryingToLookupClient()
        {
            //Arrainge
            var customerDataServiceMock = new Mock<ICustomerDataService>();
            var customerMock = new Mock<ICustomerAccountService>();
            var customerId = Guid.NewGuid();
            var mowingCharge = 10;
            var wateringCharge = 15;
            var weedingCharge = 25;
            var customerName = "Bob";

            customerMock.Setup(x => x.GetMowingCharge()).Returns(mowingCharge);
            customerMock.Setup(x => x.GetWateringCharge()).Returns(wateringCharge);
            customerMock.Setup(x => x.GetWeedingCharge()).Returns(weedingCharge);
            customerMock.Setup(x => x.Name).Returns(customerName);

            //customerDataServiceMock.Setup(x => x.GetCustomerAccount(customerId))
            //    .Returns(customerMock.Object);

            customerDataServiceMock.Setup(x => x.GetCustomerAccount(It.IsAny<Guid>()))
                .Throws<ArgumentException>();

            var customerBillingService = new CustomerBillingService(customerDataServiceMock.Object);

            var result = customerBillingService.GetCustomerCurrentAmountDue(Guid.NewGuid());

            Assert.AreEqual(25, result);
        }
    }
}