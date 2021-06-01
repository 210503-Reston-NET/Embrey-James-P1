using PPModels;
using System.Collections.Generic;


namespace PPBL
{
    public interface ICustomerBL
    {
//         // List<Customer> GetAllCustomers();
        Customer AddCustomer(Customer customers);
        Customer GetCustomer(Customer customers);
        int GetCustomer1(Customer customers);

        bool GetCustomer2(Customer customers);
        List<Customer> GetAllCustomers();
        
        // //         Customer DeleteCustomer(Customer customer);
        // Customer AddCustomer(CustomerBL customer);

    }
}