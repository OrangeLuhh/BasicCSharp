using System;
using Xunit;

namespace TestDouble
{
    public class FakeObject
    {
        [Fact]
        public void Test1()
        {
            var userStore = new FakeUserStore();
            Assert.Equal("administrator", userStore.GetUserRole("admin"));
        }
    }

    public class FakeUserStore : IUserStore
    {
        public string GetUserRole(string username)
        {
            if (username == "admin")
                return "administrator";
            else
                return "contributor";
        }
    }
    public interface IUserStore
    {
        string GetUserRole(string username);
    }
}