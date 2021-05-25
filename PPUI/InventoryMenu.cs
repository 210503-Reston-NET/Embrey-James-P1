using System;
using PPDL;
using PPBL;

namespace PPUI
{
    public class InventoryMenu : IMenu
    {
        // private IMenu submenu;

        // IInventoryBL _inventoryBL;
        public void Start()
        {

            
            bool repeat = true;
            do
            {
                Console.WriteLine("Welcome back Manager! What would you like to do?");
                Console.WriteLine("[0] Replenish Inventory");
                Console.WriteLine("[1] Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                        Console.WriteLine("Inventory Replenished");
                        break;
                    case "1":
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