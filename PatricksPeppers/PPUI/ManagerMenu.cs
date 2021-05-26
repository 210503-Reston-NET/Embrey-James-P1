using System;
using PPDL;
using PPBL;

namespace PPUI
{
    public class ManagerMenu : IMenu
    {
        private IMenu submenu;
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome back Manager! What would you like to do?");
                Console.WriteLine("[0] View Inventory");
                Console.WriteLine("[1] View Customers");
                Console.WriteLine("[2] Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                    // int prods = FindProduct();
                        submenu = Intro.GetMenu("InventoryMenu");
                        submenu.Start();
                        break;
                    case "1":
                        submenu = Intro.GetMenu("CustomerMenu");
                        submenu.Start();
                        break;
                    case "2":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            } while (repeat);
        }

        // public LocateProduct()
        // {
        //     int productNum;
        //     bol repeats = true;
        //     do
        //     {
        //         productNum = _validate.ValidateInt("What is the product Number? Please use 1-15");
        //         repeats = !(_productBL.GetProduct(productNum);
        //     }
        // }
    }
}