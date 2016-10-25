using System;
using Moq;
using MoqDemo.Basic.CodeUnderTest;
using NUnit.Framework;

namespace MoqDemo.Basic
{
    [TestFixture]
    public class CustomerBillingServiceTestsOutParams
    {
        [Test]
        public void ShouldBeAbleToGetDaysPaymentLateAndStatusForCustomer()
        {
            //Arr
            var customerDataServiceMock = new Mock<ICustomerDataService>();
            var customerAccountMock = new Mock<ICustomerAccountService>();
            var customerId = Guid.NewGuid();
            const int expectedDaysLate = 100;
            var expectedStatus = "Cancelled";

            customerAccountMock.Setup(x => x.GetCustomerPaymentStatus(out expectedStatus))
                .Returns(expectedDaysLate);

            customerDataServiceMock.Setup(x => x.GetCustomerAccount(customerId))
                .Returns(customerAccountMock.Object);
            var customerBillingService = new CustomerBillingService(customerDataServiceMock.Object);


            //Act
            string statusResult;
            var result = customerBillingService.GetPaymentDaysLate(customerId, out statusResult);

            //Assert
            Assert.AreEqual(result, expectedDaysLate);
            Assert.AreEqual(expectedStatus, statusResult);
        }
    }
}