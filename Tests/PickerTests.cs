using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class PickerTests
    {
        private Picker _picker;
        private IList<Person> _people;

        [TestInitialize]
        public void Setup()
        {
            _people = new List<Person>
            {
                new Person { Name = "Alice", Partner = "Bob" },
                new Person { Name = "Bob", Partner = "Alice" },
                new Person { Name = "Charlie", Partner = "Dana" },
                new Person { Name = "Dana", Partner = "Charlie" }
            };
            _picker = new Picker(_people);
        }

        [TestMethod]
        public void TestPickNames()
        {
            // Act
            var result = _picker.PickNames();

            // Assert
            Assert.AreEqual(_people.Count, result.Count);
            foreach (var person in _people)
            {
                Assert.IsTrue(result.ContainsKey(person.Name));
                Assert.AreNotEqual(person.Name, result[person.Name]);
                Assert.AreNotEqual(person.Partner, result[person.Name]);
            }
        }

        [TestMethod]
        public void TestPickName()
        {
            // Arrange
            var person = _people[0];

            // Act
            var result = _picker.PickName(person);

            // Assert
            Assert.AreNotEqual(person.Name, result);
            Assert.AreNotEqual(person.Partner, result);
        }
    }
}