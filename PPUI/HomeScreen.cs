using PPModels;
using System;
using PPDL;
using PPBL;

namespace PPUI
{
    public class HomeScreen : IMenu
    {
        private IMenu submenu;
        public void Start()
        {
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome to Patrick's Peppers Application! We sell an assortment of sauces to spice up your life!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] View Products");
                Console.WriteLine("[1] View as Manager");
                Console.WriteLine("[2] Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        submenu = Intro.GetMenu("ProductMenu");
                        submenu.Start();
                        break;
                    case "1":
                        submenu = Intro.GetMenu("InventoryMenu");
                        submenu.Start();
                        break;
                    case "2":
                        Console.WriteLine("Have a nice day!");
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            } while (repeat);
        }
    }
}