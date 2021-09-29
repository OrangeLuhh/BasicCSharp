using System;
using Xunit;
using TestDouble.Entity;

namespace TestDouble
{
    public class DummyObject
    {
        [Fact]
        public void TestWithDummy()
        {
            People people = new People();
            people.addPerson(new DummyPerson());
            people.addPerson(new DummyPerson());
            Assert.Equal(2, people.getNumberOfPerson());
        }
    }

    public class DummyPerson : Person
    {
        public DummyPerson() { }
    }
}
