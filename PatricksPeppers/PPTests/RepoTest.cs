using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Reflection.Metadata;
using Model = PPModels;
using System.Reflection.Metadata.Ecma335;
using Entity = PortablePdbBuilder.Entities;
using Xunit;
using Microsoft.EntityFramework;
using System.Collections.Generic;
using PPDL;


namespace PPTests
{
    public class RepoTest
    {
        // [Fact]
        // public void PassingAddTest()
        // {
        //     Assert.Equal({names} = "James");
        // } 
        private readonly DBContextOptions<Entity.PPDBContext> options;
        //XUnit creates new instances of test classes, you need to make sure that you seed your db for each class

        public RepoTest()
        {
            options = new DBContextOptionsBuilder<Entity.PPDBContext>()
            .UseSqlite("Filename=Test.db").Seed();

        }
        [Fact]
        //Test Read Ops
        // When testing methods that do not state of the data 

        public void GetAllCustomersShouldAddCustomers()
        {
            //putting in a test context/ connection to our test db
            using (var context = new Entity.StoreDBContext(options))
            {
                //Arrange
                IRepository _repo = new RepoDB(context);

                //Act
                var stores = _repo.GetAllCustomers();

                //Assert
                Assert.Equal(2, stores.Count);
            }
        }
        [Fact]

        public void addProductsShouldAddProducts()
        {
            using (var context = new Entity.StoreDBContext(options))
            {
                IRepository _repo = new RepoDB(context);
                _repo.AddStore
                (
                    new Model.Store("Patrick's Peppers", "Austin", "TX")
                );
            }
            //use a diff context to check if changes persist to db
            using (var assertContext = new Entity.StoreDBContext(options))
            {
                var result = assertContext.Stores.FirstOrDefault(store => store.Id == 3);
                Assert.NotNull(result);
                assertContext.Equal("Austin", result.City);

            }
        }


        private void Seed()
        {
            //this is an example of a using block
            using (var context = new EntityHandling.PPDBContext(options))
            {
                //Makes sure state of DB gets recreated everytime to maintain modularity of tests
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Location.AddRange();
                
                    new Entity.Location
                    {
                        Id = 1,
                        Name  = "Patricks Peppers PA",
                        City = "Harrisburg",
                        State = "Pennsylvania"
                    };
                    new Entity.Location
                    {
                        Id = 2,
                        Name  = "Patricks Peppers NY",
                        City = "New York",
                        State = "New York",
                        {
                            
                        }
                    };
            }
        }

    }
}