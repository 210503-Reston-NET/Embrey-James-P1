using System; 
using System.Collections.Generic; 
using PPDL;
using PPModels;
// using Serilog;

namespace PPBL
{
    public class CustomerBL : ICustomerBL
    {

    public IRepository _repo;

    public CustomerBL(IRepository repo)
    {
        _repo = repo;
    }

    public List<Customer> GetAllCustomers()
    {
        return _repo.GetAllCustomers();
    }



    public Customer AddCustomer(Customer customers)
    {
        if(_repo.GetCustomer(customers)!=null)
        {
            throw (new Exception ("Customer already exists!"));
        }
        return _repo.AddCustomer(customers);
    }

    public Customer GetCustomer(Customer customers)
    {
        return _repo.GetCustomer(customers);
    }
    public int GetCustomer1(Customer customers)
    {
        return _repo.GetCustomer1(customers);
    }

    public bool GetCustomer2(Customer customers)
    {
        return _repo.GetCustomer2(customers);
    }
}
}