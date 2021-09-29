using System;
using Xunit;
using TestDouble.Entity;
using System.Linq;
using System.Collections.Generic;

namespace TestDouble
{
    public class TestStub
    {
        [Fact]
        public void TestWithStub()
        {
            WebServer webserver = new WebServer(new DatabaseStub());
            Assert.Equal(42, webserver.getSecretNumber("BoYu", "jyt"));
        }

        [Fact]
        public void Test_Charge_Customer_Count()
        {
            //Arrange
            ICheckInFee stubCheckInFee = new CheckInFeeStubs();
            var target = new Pub(stubCheckInFee);
            var customers = new List<Customer>
            {
                new Customer {IsMale = true},
                new Customer {IsMale = false},
                new Customer {IsMale = false},
            };
            decimal expected = 1;
            //Act
            var actual = target.CheckIn(customers);
            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test_Income()
        {
            //Arrange
            ICheckInFee stubCheckInFee = new CheckInFeeStubs();
            var target = new Pub(stubCheckInFee);
            var customers = new List<Customer>
            {
                new Customer {IsMale = true},
                new Customer {IsMale = false},
                new Customer {IsMale = false},
            };
             //Act
            decimal inComeBeforeCheckIn = target.GetInCome();
            //Assert
            Assert.Equal(0, inComeBeforeCheckIn);
            decimal expectedIncome = 100;
            //Act
            int chargeCustomerCount = target.CheckIn(customers);
            var actualIncome = target.GetInCome();
            //Assert
            Assert.Equal(expectedIncome, actualIncome);
        }
    }

    public class DatabaseStub : Database
    {
        public bool authorize(String username, String password)
        {
            return true;
        }
    }

    public class CheckInFeeStubs : ICheckInFee
    {
        public decimal GetFee(Customer customer)
        {
            return 100;
        }
    }
}