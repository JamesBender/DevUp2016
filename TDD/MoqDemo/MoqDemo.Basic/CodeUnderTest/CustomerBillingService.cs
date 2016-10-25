using System;

namespace MoqDemo.Basic.CodeUnderTest
{
    public class CustomerBillingService
    {
        private readonly ICustomerDataService _customerDataService;

        public CustomerBillingService(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }

        public decimal GetCustomerCurrentAmountDue(Guid customerId)
        {
            var customer = _customerDataService.GetCustomerAccount(customerId);

            var mowingCharge = customer.GetMowingCharge();
            var weedingCharge = customer.GetWeedingCharge();
            var wateringCharge = customer.GetWateringCharge();         

            return mowingCharge + weedingCharge + wateringCharge;
        }

        public int GetPaymentDaysLate(Guid customerId, out string status)
        {
            var customer = _customerDataService.GetCustomerAccount(customerId);

            return customer.GetCustomerPaymentStatus(out status);
        }

        public Guid SetupNewCustomer(string customerName)
        {
            var customer = _customerDataService.GetCustomerAccount();
            customer.Name = customerName;
            return customer.CustomerId;
        }
    }
}