using System;
using System.Collections.Generic;
using Model = PPModels;
using Entity = PPDL.Entities;
using System.Linq;


namespace PPDL
{
    public class RepoDB : IRepository
    {
        private Entity.PPDBContext _context;
        
        public RepoDB(Entity.PPDBContext context) 
        {
            _context = context;
        }

        public List<Model.Location> GetAllLocations()
        {
            return _context.Locations
            .Select(
                location => new Model.Location(location.LocationName, location.LocationCity, location.LocationState)
            ).ToList();
        }
        
        public Model.Customers AddCustomer(Model.Customers customers)
        {
            
            _context.Customers.Add(
                new Entity.Customer{
                CustomerName = customers.Name,
                CustomerLocale = customers.Locale,
                }
            );
            _context.SaveChanges();
            return customers;
        }

        public List<Model.Products> GetAllProducts()
        {
            return _context.Products
            .Select(
                product => new Model.Products(product.ProductName, product.ProductPrice)
            ).ToList();
        }
        

        // public List<Model.Customers> GetAllCustomers()
        // {
        //     return _context.Customers
        //     .Select(
        //         customers => new Model.Customers(customers.Name, customer.Locale, customer.Quantity)
        //     ).ToList();
        // }


        public Model.Customers GetCustomer(Model.Customers customers)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(custo => custo.CustomerName == customers.Name && custo.CustomerLocale == customers.Locale);
            if(found == null) return null;
            return new Model.Customers(found.CustomerName, found.CustomerLocale);
        }

        public int GetCustomer1(Model.Customers customers)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(custo => custo.CustomerName == customers.Name && custo.CustomerLocale == customers.Locale);
            if(found == null)
            {
                Console.WriteLine("Could not find customer");
            };
            return found.CustomerId;
        }

        public bool GetCustomer2(Model.Customers customers)
        {
            Entity.Customer found = _context.Customers.FirstOrDefault(custo => custo.CustomerName == customers.Name && custo.CustomerLocale == customers.Locale);
            if(found == null) return false;
            return true;
        }

        // public Model.Products GetProducts(Model.Products products)
        // {
        //     Entity.Product found = _context.Products.FirstOrDefault(prod => prod.ProductId == products.ProductId);
        //     if(found == null) return null;
        //     return new Model.Products(found.ProductId, found.ProductName, found.ProductQuantity, found.ProductPrice);
        // }

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

        public Model.Orders AddOrder(Model.Orders orders)
            {
                _context.Orders.Add(
                new Entity.Order{
                OrderId = orders.OrderId,
                OrderQuantity = orders.OrderQuantity,
                OrderNumber= orders.OrderNumber,
                OrderTotal = orders.OrderTotal,
                OrderLocation = orders.OrderLocation,
                OrderDate = DateTime.Now
                }
            );
            _context.SaveChanges();
            return orders;
        }

        public Model.Orders GetOrders(Model.Orders orders)
        {
            Entity.Order found = _context.Orders.FirstOrDefault(ord => ord.OrderId == orders.OrderId);
            if(found == null) return null;
            return new Model.Orders(found.OrderId, found.OrderQuantity, found.OrderNumber, found.OrderTotal, found.OrderLocation);
        }

        public void UpdateOrder(Model.Orders order2BeUpdated)
        {

            Entity.Order oldOrder = _context.Orders.Find(order2BeUpdated.OrderId);

            _context.Entry(oldOrder).CurrentValues.SetValues(order2BeUpdated);


            Entity.Order oldOrder1 = _context.Orders.Find(order2BeUpdated.OrderId);


            oldOrder1.OrderQuantity = order2BeUpdated.OrderQuantity;

            oldOrder1.OrderTotal = order2BeUpdated.OrderTotal;

            _context.Entry(oldOrder).CurrentValues.SetValues((order2BeUpdated));


            _context.SaveChanges();

            // _context.ChangeTracker.Clear();

        }

        

        public void UpdateInventory(Model.Inventory inventory2BeUpdated)
        {
            

            Entity.Inventory oldInventory = _context.Inventories.Find(inventory2BeUpdated.InventoryId);

            _context.Entry(oldInventory).CurrentValues.SetValues(inventory2BeUpdated);


            Entity.Inventory oldInventory1 = _context.Inventories.Find(inventory2BeUpdated.InventoryId);


            oldInventory1.InventoryQuantity = inventory2BeUpdated.InventoryQuantity;

            // oldInventory1.InventoryQuantity = inventory2BeUpdated.InventoryTotal;

            _context.Entry(oldInventory).CurrentValues.SetValues((inventory2BeUpdated));


            _context.SaveChanges();

        //     // _context.ChangeTracker.Clear();

        }

        public Model.Inventory GetInventory(int prod, int loc)
        {
            Entity.Inventory found = _context.Inventories.FirstOrDefault(inv => inv.InventoryNumber == prod && inv.InventoryCode == loc);
            if(found == null) return null;
            return new Model.Inventory(found.InventoryId, found.InventoryNumber, found.InventoryQuantity, found.InventoryCode);

        //     // _context.ChangeTracker.Clear();

        }

        public void DecrementInventory(Model.Inventory inventory2BeUpdated)
        {
            

            Entity.Inventory oldInventory = _context.Inventories.Find(inventory2BeUpdated.InventoryId);
            
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
            Entity.Location found = _context.Locations.FirstOrDefault(loc => loc.LocationState == location);
            if(found == null)
            Console.WriteLine("Could not find location!");
            return found.LocationId;
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


    // {
    //     private Entity.PPDBContext _context;


    //     public RepoDB(Entity.PPDBContext context)
    //     {
    //         _context = context;
    //     }
    //     public PPModels.Customers AddCustomer(PPModels.Customers customers)
    //         {
    //         //This records a change in the context change tracker that we want to add this particular entity to the 
    //         // db
    //                 Entity.Customer tobeAdded = _context.Customers.First(custo => custo.Id == customers.Id);
    //                 _context.Customers.Add(toBeAdded);
    //                 _context.SaveChanges();
    //                 return customers;
    //                 _context.Customers.Add(
    //                 new Entity.Customer
    //                 {
    //                     CustomerName = customers.Name
    //                 }
    //                 );
    // // //         //This persists the change to the db
    // // //         // Note: you can create a separate method that persists the changes so that you can execute repo commands in
    // // //         //the BL and save changes only when all the operations return no exceptions
    //                 _context.SaveChanges(customers);
    //                 return customers;
    //         }

        
        
    // // //     public PPModels.Location AddLocation(Location location)
    // // //     {
    // // //         _context.Locations.Add(
    // // //             new Entity.Location
    // // //             {
    // // //                 LocationName = location.Name,
    // // //                 LocationCity = location.City,
    // // //                 LocationState = location.State,
    // // //             }
    // // //         );
    // // //         _context.SaveChanges();
    // // //         return location;
    // // //     }

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
