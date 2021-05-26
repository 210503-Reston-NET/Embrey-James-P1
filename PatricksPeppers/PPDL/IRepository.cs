using System.Collections.Generic;
using PPModels;
using Entity = PPDL.Entities;
using System.Linq;


namespace PPDL
{
    public interface IRepository
    {
        // List<Customer> GetAllCustomers();
        Customers AddCustomer(Customers customers);
        Customers GetCustomer(Customers customers);
        // Products GetProducts(Products products);
        Orders AddOrder(Orders orders);
        Orders GetOrders(Orders orders);

        void UpdateOrder(Orders order2BeUpdated);

        int GetCustomer1(Customers customers);

        bool GetCustomer2(Customers customers);

        // string GetOrdersL(Orders orders);

        void UpdateInventory(Inventory inventory2BeUpdated);

        Inventory GetInventory(int prod, int loc);

        void DecrementInventory(Inventory inventory);

        int GetLocation(string location);

        List<Location> GetAllLocations();

        List<Products> GetAllProducts();
    

        // int DeleteProduct(Products products);

    }
}