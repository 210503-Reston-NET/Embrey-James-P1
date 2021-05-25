using PPModels;
using System.Collections.Generic;


namespace PPBL
{
    public interface ICustomerBL
    {
//         // List<Customer> GetAllCustomers();
        Customers AddCustomer(Customers customers);
        Customers GetCustomer(Customers customers);
        int GetCustomer1(Customers customers);

        bool GetCustomer2(Customers customers);
// //         Customer DeleteCustomer(Customer customer);
        // Customer AddCustomer(CustomerBL customer);

    }
}