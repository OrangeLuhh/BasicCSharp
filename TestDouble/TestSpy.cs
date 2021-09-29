using System;
using Xunit;

namespace TestDouble
{
    public class TestSpy
    {
        [Fact]
        public void Test1()
        {
            var userStore = new SpyUserStore();
            Assert.Equal("administrator", userStore.GetUserRole("admin"));
        }
    }

    public class SpyUserStore : IUserStore
    {
        private static int Counter { get; set; }

        public SpyUserStore()
        {
            Counter = 0;
        }

        public string GetUserRole(string username)
        {

            if (Counter >= 1)
                throw new Exception("Function called more than once");

            Counter++;

            if (username == "admin")
                return "administrator";
            else
                return "contributor";
        }
    }
}