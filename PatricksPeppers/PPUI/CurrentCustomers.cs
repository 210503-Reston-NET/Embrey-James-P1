// using System.Reflection;
// using System.ComponentModel.Design;
// using System;
// using PPDL;
// using PPBL;
// using Entity = PPDL.Entities;

// namespace PPUI
// {
//     public class CurrentCustomers : IMenu
//     {
//         public void Start()
//         {
//             bool repeat = true;
//             do
//             {

//                 Console.WriteLine("You have Customers! What would you like to do?");
//                 Console.WriteLine("[0] Add Customer");
//                 Console.WriteLine("[1] Exit");

//                 string input = Console.ReadLine();
//                 switch (input)
//                 {
//                     case "0":
//                         // (Entity.Customer.customerQuantity++);
//                         // AddCustomer();
//                         // menu = Intro.GetMenu();
//                         Console.WriteLine("Customer added!");
//                         // menu.Start();
//                         break;
//                     case "1":
//                         Console.WriteLine("Have a nice day!");
//                         repeat = false;
//                         break;
//                     default:
//                         Console.WriteLine("Please enter a valid option");
//                         break;
//                 }
//             } while (repeat);
//         }
//     }
// }