using System;
using System.Collections.Generic;

namespace TestDouble
{
    public class Pub
    {
        private readonly ICheckInFee _checkInFee;
        private decimal _inCome;

        public Pub(ICheckInFee checkInFee)
        {
            this._checkInFee = checkInFee;
        }

        /// <summary>
        /// 入场
        /// </summary>
        /// <param name="customers"></param>
        /// <returns>收费的人数</returns>
        public int CheckIn(List<Customer> customers)
        {
            var result = 0;
 
            foreach (var customer in customers)
            {
                var isFemale = !customer.IsMale;
 
                //女生免费入场
                if (isFemale)
                {
                    continue;
                }
                else
                {
                    //for stub, validate status: income value
                    //for mock, validate only male
                    this._inCome += this._checkInFee.GetFee(customer);
 
                    result++;
                }
            }
 
            //for stub, validate return value
            return result;
        }

        public decimal GetInCome()
        {
            return this._inCome;
        }
    }

    public interface ICheckInFee
    {
        decimal GetFee(Customer customer);
    }

    public class Customer
    {
        public bool IsMale { get; set; }

        public int Seq { get; set; }
    }
}
