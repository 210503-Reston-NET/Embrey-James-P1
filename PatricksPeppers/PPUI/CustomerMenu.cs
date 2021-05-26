using System;
using PPDL;
using PPBL;
using PPModels;
//using PPDL = PPDL.Entities;

namespace PPUI
{
    public class CustomerMenu : IMenu
    {
        private ICustomerBL _customerBL;
        private IVerificationService _verify;

        public CustomerMenu(ICustomerBL customerBL, IVerificationService verify)
        {
            _customerBL = customerBL;
            _verify = verify;
        }
        public void Start()
        {
            bool repeat = true;
            do
            {

                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[0] Add Customer");
                Console.WriteLine("[1] Exit");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "0":
                    // AddCustomer();
                        Console.WriteLine("Customer added!");
                        break;
                    case "1":
                        repeat = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option");
                        break;
                }
            } while (repeat);
        }

        // public void AddCustomer()
        // {
        //         string names = _verify.VerifyString("Please enter your name:");
        //         string locales = _verify.VerifyString("Please enter your location:");
        //         Customers Harambe = new Customers(names, locales);
        //         Customers customerCreated = _customerBL.AddCustomer(Harambe);
        // }

    }
}