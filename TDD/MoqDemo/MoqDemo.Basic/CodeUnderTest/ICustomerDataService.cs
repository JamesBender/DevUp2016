using System;

namespace MoqDemo.Basic.CodeUnderTest
{
    public interface ICustomerDataService
    {
        ICustomerAccountService GetCustomerAccount(Guid customerId);
        ICustomerAccountService GetCustomerAccount();
    }
}