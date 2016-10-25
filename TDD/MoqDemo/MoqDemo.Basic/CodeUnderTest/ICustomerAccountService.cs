using System;

namespace MoqDemo.Basic.CodeUnderTest
{
    public interface ICustomerAccountService
    {
        decimal GetWateringCharge();

        decimal GetWeedingCharge();

        decimal GetMowingCharge();

        string Name { get; set; }
        Guid CustomerId { get; }

        int GetCustomerPaymentStatus(out string status);
        void WillNeverEverBeCalled();
    }
}
