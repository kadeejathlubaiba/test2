using MainProject.Models;
using MainProject.Repositories;
using MainProject.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestProject.Testmethods
{
    public  class CustomerBLTest
    {
        //declaration
        private Mock<IEntityRepository<Customer>> customerRepository;
        private List<Customer> customers;

        [SetUp]
        public void Setup()
        {
            //initialise instance
            customerRepository = new Mock<IEntityRepository<Customer>>();
            customers = new List<Customer>();

            //dummy data-setup the mock data
            customers.Add(new Customer(){
                CustomerId=101,
                FirstName="Kadeejath",
                LastName="Lubaiba",
                Customercode = "C001",
                IsDeleted=false
            });
            customers.Add(new Customer()
            {
                CustomerId = 102,
                FirstName = "Hafsa",
                LastName = "K.A",
                Customercode = "C002",
                IsDeleted = false
            });
            customers.Add(new Customer()
            {
                CustomerId = 103,
                FirstName = "Abdul",
                LastName = "Rahiman",
                Customercode = "C003",
                IsDeleted = false
            });
        }

        [Test]
        public void Test_Get_All_Active_customers_If_Deleted_is_False()
        {

            //act
            customerRepository.Setup(c => c.GetAllQueryable()).Returns(customers.AsQueryable);

            //arrange
            var customerBL = new CustomerBL(customerRepository.Object);
            var customerList = customerBL.GetAllActiveCustomer();

            
            //assert

            Assert.IsTrue(customerList.Count==3);
            Assert.IsTrue(customerList.All(c => c.IsDeleted == false));

        }
    }
}
