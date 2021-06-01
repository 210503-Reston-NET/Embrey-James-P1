using System.Collections.Generic;
using PPModels;
using Entity = PPDL.Entities;
using System.Linq;


namespace PPDL
{
    public interface IRepository
    {  
        Products GetProducts(Products products);
        Products AddProducts(Products products);
        Order AddOrder(Order orders);
        Order GetOrders(Order orders);
        List<Products> GetAllProducts();

        void UpdateOrder(Order order2BeUpdated);

        int GetCustomer1(Customer customers);

        bool GetCustomer2(Customer customers);

        Customer AddCustomer(Customer customers);
        Customer GetCustomer(Customer customers);
        List<Customer> GetAllCustomers();


        // string GetOrdersL(Orders orders);

        void UpdateInventory(Inventory inventory2BeUpdated);

        Inventory GetInventory(int prod, int loc);

        void DecrementInventory(Inventory inventory);

        int GetLocation(string location);

        Location AddLocation(Location location);

        Location GetLocation(Location location);

        List<Location> GetAllLocations();

        


        // int DeleteProduct(Products products);

    }
}