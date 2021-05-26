using System.Collections.Generic;
using PPBL;
using PPDL;
using System;
using PPModels;
using Serilog;

namespace PPUI
{
public class ProductMenu : IMenu
    {
        private IMenu submenu;

        private IOrderBL _orderBL;
        private ICustomerBL _customerBL;

        private IInventoryBL _inventoryBL;

        private ILocationBL _locationBL;

        private IProductBL _productBL;
        private IVerificationService _verify;

        public ProductMenu(IOrderBL orderBL, ICustomerBL customerBL, IVerificationService verify, IInventoryBL inventoryBL, ILocationBL locationBL, IProductBL productBL)
        {
            _orderBL = orderBL;
            _customerBL = customerBL;
            _verify = verify;
            _inventoryBL = inventoryBL;
            _locationBL = locationBL;
            _productBL = productBL;
        }
        public void Start()
        {
            int GetCustomerId = AddCustomer();
            Random nums = new Random();
            int ID = nums.Next(1111,9999);

        string FoundLocation = LocationFind();
        


            Orders newOrder = new Orders(ID, 0, GetCustomerId, 0, FoundLocation);
            Orders createdOrder = _orderBL.AddOrder(newOrder);

            // int ProductQuantity = DeleteProduct();
            // Product orderProduct = new Product(ProductQuantity);
            // Product orderedProduct = _productBL.DeleteProduct(orderProduct);

        // async Task Invoke(HttpContext ctx, IDataService svc2)
        // {
        //     ILogger<EventSourceLoggerProvider> loggerEvent = 
        //     ctx.RequestServices.GetService<ILogger<EventSourceLoggerProvider>>();
        // }

            // DateTime localDate = DateTime.Now();

            


            bool repeat = true;
            do
            {
                Console.WriteLine("Which product do you wish to purchase? (Mango Twango = 0, Hickory Dickory = 1, Hollapeno = 2, Heat Wave = 3, Scorpion Sting = 4, Pepper Plague = 5) Press 6 to Exit.");
                List<Products>products = _productBL.GetAllProducts();
                foreach (Products product in products)
                {
                    Console.WriteLine(product.ToString());
                };
                
                string input = Console.ReadLine();
                
                switch (input)
                {
                    case "0":
                    int Quant = 1;
                    newOrder.OrderQuantity = newOrder.OrderQuantity + Quant;
                    double Price = 9.00;
                    newOrder.OrderTotal = newOrder.OrderTotal + Price;
                    _orderBL.UpdateOrder(newOrder);
                    DecrementInventory(1, FoundLocation);
                    // orderProduct.OrderQuantity = orderedProduct.OrderQuantity - 1;
                        Console.WriteLine("Purchased!");
                        // logger.LogInformation("Purchase Log");
                        break;
                    case "1":
                    int Quant1 = 1;
                    newOrder.OrderQuantity = newOrder.OrderQuantity + Quant1;
                    double Price1 = 9.00;
                    newOrder.OrderTotal = newOrder.OrderTotal + Price1;
                    _orderBL.UpdateOrder(newOrder);
                    DecrementInventory(2, FoundLocation);
                        Console.WriteLine("Purchased!");
                        break;
                    case "2":
                    int Quant2 = 1;
                    newOrder.OrderQuantity = newOrder.OrderQuantity + Quant2;
                    double Price2 = 10.00;
                    newOrder.OrderTotal = newOrder.OrderTotal + Price2;
                    _orderBL.UpdateOrder(newOrder);
                    DecrementInventory(3, FoundLocation);
                        Console.WriteLine("Purchased!");
                        break;
                    case "3":
                    int Quant3 = 1;
                    newOrder.OrderQuantity = newOrder.OrderQuantity + Quant3;
                    double Price3 = 10.00;
                    newOrder.OrderTotal = newOrder.OrderTotal + Price3;
                    _orderBL.UpdateOrder(newOrder);
                    DecrementInventory(4, FoundLocation);
                        Console.WriteLine("Purchased!");
                        break;
                    case "4":
                    int Quant4 = 1;
                    newOrder.OrderQuantity = newOrder.OrderQuantity + Quant4;
                    double Price4 = 12.00;
                    newOrder.OrderTotal = newOrder.OrderTotal + Price4;
                    _orderBL.UpdateOrder(newOrder);
                    DecrementInventory(5, FoundLocation);
                        Console.WriteLine("Purchased!");
                        break;
                    case "5":
                    int Quant5 = 1;
                    newOrder.OrderQuantity = newOrder.OrderQuantity + Quant5;
                    double Price5 = 12.00;
                    newOrder.OrderTotal = newOrder.OrderTotal + Price5;
                    _orderBL.UpdateOrder(newOrder);
                    DecrementInventory(6, FoundLocation);
                        Console.WriteLine("Purchased!");
                        break;
                    case "6":
                        Console.WriteLine("Have a nice day!");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        submenu.Start();
                        break;
                }
            } while (repeat);
        }

        public int VerifyInt(string prompt)
        {
            int response = 0;
            bool repeat = true;
            do
            {
                List<Products>products = _productBL.GetAllProducts();
                foreach (Products product in products)
                {
                    // Console.WriteLine(product.ToString());
                };
                try{
                    // response = Int32.Parse(Console.ReadLine());
                    // if (response > -1)
                    // {
                    //     repeat = false;
                    // }

                    // else
                    // {
                    //     Console.WriteLine("Must be a non-negative input");
                    // }
                }
                catch(Exception)
                {
                    Console.WriteLine("Invalid input. Please enter and integer value.");
                }
                } while (repeat);
                return response;
        }


        public int AddCustomer()
        {
                string names = _verify.VerifyString("Please enter your name:");
                string locales = _verify.VerifyString("Please enter your location:");
                Customers Harambe = new Customers(names, locales);
                bool customerExist = _customerBL.GetCustomer2(Harambe);
                if(!customerExist)
                {
                    Customers customerCreated = _customerBL.AddCustomer(Harambe);
                    Log.Information("New customer created!");
                    return _customerBL.GetCustomer1(Harambe);
                }

                Console.WriteLine($"Welcome back {names}");

                return _customerBL.GetCustomer1(Harambe);
        }

        public void DecrementInventory(int pcode, string lcode)
        {
            
            int lctn = _locationBL.GetLocation(lcode);
            
            Inventory newInventory = _inventoryBL.GetInventory(pcode, lctn);
            
            _inventoryBL.DecrementInventory(newInventory);
        }

        public string LocationFind()
        {
            bool iterate = true;
            do
            {
                Console.WriteLine("Which store do you wish to purchase it from?");
                List<Location>locations = _locationBL.GetAllLocations();
                foreach (Location location in locations)
                {
                    Console.WriteLine(location.ToString());
                };
                int code = _verify.VerifyInt("Please select a number (0 is PA, 1 is TX, 2 is CA)");
                switch(code)
                {
                    case 0:
                        return "PA";
                    break;
                    case 1:
                        return "TX";
                    break;
                    case 2:
                        return "CA";
                    break;
                    default:
                    Console.WriteLine("Please enter a valid number");
                    break;
                }
            } while (iterate);
            return "random";
        }
    }
}