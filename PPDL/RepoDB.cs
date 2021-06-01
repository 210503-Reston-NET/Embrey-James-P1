using System;
using System.Collections.Generic;
using Model = PPModels;
using System.Linq;
using PPModels;

namespace PPDL
{
    public class RepoDB : IRepository
    {
        private Entities.PPDBContext _context;

        public RepoDB(Entities.PPDBContext context)
        {
            _context = context;
        }

        public List<Location> GetAllLocations()
        {
            return _context.Location
            .Select(
                location => new Location(location.Name, location.City, location.State)
            ).ToList();
        }

        public Customer AddCustomer(Customer customers)
        {

            _context.Customers.Add(
                new Customer
                {
                    Name = customers.Name,
                    Locale = customers.Locale
                }
            );
            _context.SaveChanges();
            return customers;
        }

        public List<Products> GetAllProducts()
        {
            return _context.Products
            .Select(
                product => new Products(product.ProductId, product.ProductName, product.ProductQuantity, product.ProductPrice)
            ).ToList();
        }


        public List<Customer> GetAllCustomers()
        {
            return _context.Customers
            .Select(
            customers => new Customer(customers.CustomerId, customers.Name, customers.Locale)
            ).ToList();
        }


        public Customer GetCustomer(Customer customers)
        {
            Customer found = _context.Customers.FirstOrDefault(custo => custo.Name == customers.Name && custo.Locale == customers.Locale);
            if (found == null) return null;
            return new Customer(found.CustomerId, found.Name, found.Locale);
        }

        public int GetCustomer1(Model.Customer customers)
        {
            Model.Customer found = _context.Customers.FirstOrDefault(custo => custo.Name == customers.Name && custo.Locale == customers.Locale);
            if (found == null)
            {
                Console.WriteLine("Could not find customer");
            };
            return found.CustomerId;
        }

        public bool GetCustomer2(Model.Customer customers)
        {
            Model.Customer found = _context.Customers.FirstOrDefault(custo => custo.Name == customers.Name && custo.Locale == customers.Locale);
            if (found == null) return false;
            return true;
        }


            // public void UpdateProduct(Product product2BUpdated)
            // {
            //     Entity.Product oldProduct = _context.Products.Find(product2BUpdated.Id);
            //     _context.Entry(oldProduct).CurrentValues.SetValues(product2BUpdated);

            //     //Because I am not mapping the hero property in my mapper, i am unable to use the method
            //     //_context.Entry(oldSuperPower).CurrentValues.SetValues(_mapper.ParseSuperPower(hero2BUpdated.SuperPower))
            //     // this would throw an error because i have established a 1:1 relationship between my heroes and superpower
            //     //tables. Instead, I take advantage of the change tracker and use it to update the superpower
            //     Entity.Product oldProducts = _context.Productz.Find(product2BUpdated.Product.Id);
            //     oldProduct.productQuantity = product2BUpdated.productQuantity;

            //     _context.SaveChanges();

            //     //This method clears the change tracker to drop all tracked entities
            //     _context.ChangeTracker.Clear();
            // }
            // }

            public Model.Order AddOrder(Model.Order orders)
        {
            _context.Orders.Add(
            new Model.Order
            {
                OrderId = orders.OrderId,
                OrderQuantity = orders.OrderQuantity,
                OrderNumber = orders.OrderNumber,
                OrderTotal = orders.OrderTotal,
                OrderLocation = orders.OrderLocation,
                OrderDate = orders.OrderDate
            });
            _context.SaveChanges();
            return orders;
        }

        public Model.Order GetOrders(Model.Order orders)
        {
            Model.Order found = _context.Orders.FirstOrDefault(ord => ord.OrderId == orders.OrderId);
            if (found == null) return null;
            return new Model.Order(found.OrderId, found.OrderQuantity, found.OrderNumber, found.OrderTotal, found.OrderLocation, found.OrderDate);
        }

        public void UpdateOrder(Model.Order order2BeUpdated)
        {

            Model.Order oldOrder = _context.Orders.Find(order2BeUpdated.OrderId);

            _context.Entry(oldOrder).CurrentValues.SetValues(order2BeUpdated);


            Model.Order oldOrder1 = _context.Orders.Find(order2BeUpdated.OrderId);


            oldOrder1.OrderQuantity = order2BeUpdated.OrderQuantity;

            oldOrder1.OrderTotal = order2BeUpdated.OrderTotal;

            _context.Entry(oldOrder).CurrentValues.SetValues((order2BeUpdated));


            _context.SaveChanges();

            // _context.ChangeTracker.Clear();

        }



        public void UpdateInventory(Model.Inventory inventory2BeUpdated)
        {


            Model.Inventory oldInventory = _context.Inventories.Find(inventory2BeUpdated.InventoryId);

            _context.Entry(oldInventory).CurrentValues.SetValues(inventory2BeUpdated);


            Model.Inventory oldInventory1 = _context.Inventories.Find(inventory2BeUpdated.InventoryId);


            oldInventory1.InventoryQuantity = inventory2BeUpdated.InventoryQuantity;

            // oldInventory1.InventoryQuantity = inventory2BeUpdated.InventoryTotal;

            _context.Entry(oldInventory).CurrentValues.SetValues((inventory2BeUpdated));


            _context.SaveChanges();

            //     // _context.ChangeTracker.Clear();

        }

        public Model.Inventory GetInventory(int prod, int loc)
        {
            Model.Inventory found = _context.Inventories.FirstOrDefault(inv => inv.InventoryNumber == prod && inv.InventoryCode == loc);
            if (found == null) return null;
            return new Model.Inventory(found.InventoryId, found.InventoryNumber, found.InventoryQuantity, found.InventoryCode);

            //*DO NOT UNCOMMENT!!!*     // _context.ChangeTracker.Clear();

        }

        public void DecrementInventory(Model.Inventory inventory2BeUpdated)
        {


            Model.Inventory oldInventory = _context.Inventories.Find(inventory2BeUpdated.InventoryId);

            // Console.WriteLine(oldInventory.ToString());
            // Console.WriteLine(oldInventory.ToString());

            // _context.Entry(oldInventory).CurrentValues.SetValues(inventory2BeUpdated);





            // Entity.Inventory oldInventory1 = _context.Inventories.Find(inventory2BeUpdated.InventoryId);


            oldInventory.InventoryQuantity = inventory2BeUpdated.InventoryQuantity - 1;


            // oldInventory1.InventoryQuantity = inventory2BeUpdated.InventoryTotal;

            // _context.Entry(oldInventory).CurrentValues.SetValues((inventory2BeUpdated));


            _context.SaveChanges();

            //     // _context.ChangeTracker.Clear();

        }

        public int GetLocation(string location)
        {
            Model.Location found = _context.Location.FirstOrDefault(loc => loc.State == location);
            if (found == null)
                Console.WriteLine("Could not find location!");
            return found.LocationId;
        }

        public Products GetProducts(Products products)
        {
            Model.Products found = _context.Products.FirstOrDefault(prod => prod.ProductId == products.ProductId);
            if (found == null)
                return null;
            return new Products(found.ProductId, found.ProductName, found.ProductQuantity, found.ProductPrice);
        }

        public Model.Products AddProducts(Model.Products products)
        {
            _context.Products.Add(
                new Products
                {
                    ProductId = products.ProductId,
                    ProductName = products.ProductName,
                    ProductQuantity = products.ProductQuantity,
                    ProductPrice = products.ProductPrice
                }
            );
            _context.SaveChanges();
            return products;
        }

        

        // public string GetOrdersL(Model.Orders orders)
        // {
        //     Entity.Order found = _context.Orders.FirstOrDefault(ord => ord.OrderId == orders.OrderId);
        //     if(found == null);
        //     return found.OrderLocation;
        // }

        // public int DeleteProduct(Model.Products products)
        // {

        // }

        public Location AddLocation(Location location)
        {
                 _context.Location.Add(
                     new Location
                     {
                         LocationId = location.LocationId,
                         Name = location.Name,
                         City = location.City,
                         State = location.State,
                     }
                 );
                 _context.SaveChanges();
                 return location;
             }

        public Location GetLocation(Location location)
        {
            Model.Location found = _context.Location.FirstOrDefault(loc => loc.LocationId == location.LocationId);
            if (found == null)
                return null;
            return new Location(found.Name, found.City, found.State);
        }

        // // //     // public Customers DeleteCustomer(Customers customers)
        // // //     // {
        // // //     //     Entity.Customer toBeDeleted = _context.Customers.First(custo => custo.Id == customers.Id);
        // // //     //     _context.Customers.Remove(toBeDeleted);
        // // //     //     _context.SaveChanges();
        // // //     //     return customers;
        // // //     // }

        // // //     // public List<PPModels.Customers> GetAllCustomers()
        // // //     // {
        // // //     //     return _context.Customers
        // // //     //     .Select(
        // // //     //         customers => new PPModels.Customers(customers.CustomerName, customers.CustomerLocale)
        // // //     //     ).ToList();
        // // //     // }

        // // //     // public PPModels.Customers GetCustomer(PPModels.Customers customers)
        // // //     // {
        // // //     //     Entity.Customer found = _context.Customers.FirstOrDefault(custo => custo.Name == customers.Name);
        // // //     //     if (found == null) return null;
        // // //     //     return new Customer(found.CustomerId, found.CustomerName, found.CustomerLocale);
        // // //     // }

        // // //     public List<Customers> GetCustomers(Customers customers)
        // // //     {
        // // //         return _context.Customers.Where(
        // // //             customers => name.CustomerId == GetCustomer(customer).Id
        // // //             ).Select(
        // // //                 customers=> new PPModels.Customers
        // // //                 {
        // // //                     customerId = customer.Id,
        // // //                 }
        // // //             ).ToList();
        // // //     }



        //         public Orders GetOrders(Orders orders)
        //         {
        //             Entity.Order;
        //         }
    }
}
