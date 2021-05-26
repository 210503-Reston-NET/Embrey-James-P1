using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PPBL;
using PPDL;
using PPDL.Entities;

namespace PPUI
{
    /// <summary>
    /// Class to bring up with homescreen
    /// </summary>
    public class Intro
    {
    public static IMenu GetMenu(string menuType)
        {
            //getting configurations from a config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //setting up DB connection
            string connectionString = configuration.GetConnectionString("PPDB");
            //we're building the dbcontext using the constructor that takes in options, we're setting the
            // connection string outside the context definition definition
            DbContextOptions<PPDBContext> options = new DbContextOptionsBuilder<PPDBContext>()
            .UseSqlServer(connectionString)
            .Options;
            // //passes the options we built
            var context = new PPDBContext(options);

            switch (menuType.ToLower())
            {
                case "homescreen":
                    return new HomeScreen();
                case "customermenu":
                    return new CustomerMenu(new CustomerBL(new RepoDB(context)), new VerificationService());
                case "productmenu":
                    return new ProductMenu(new OrderBL(new RepoDB(context)), new CustomerBL(new RepoDB(context)), new VerificationService(), new InventoryBL(new RepoDB(context)), new LocationBL(new RepoDB(context)), new ProductBL(new RepoDB(context)));
                case "managermenu":
                    // return new ManagerMenu();
                case "inventorymenu":
                    return new InventoryMenu();
                    // (new InventoryBL(new RepoDB(context)), new VerificationService());
                // case "currentcustomers":
                //     return new CurrentCustomers();
                default:
                    return null;
            }
        }
    }
}