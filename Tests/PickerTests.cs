namespace Tests
{
    [TestClass]
    public class PickerTests
    {
        private Picker _picker = null!;
        private IList<Person> _people = null!;

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
        public void TestAllNamesArePicked()
        {
            // Act
            var result = _picker.PickNames();

            // Assert
            Assert.AreNotEqual(result.Count, 0, "No names were picked");
            Assert.AreEqual(_people.Count, result.Count);
            foreach (var person in _people)
            {
                Assert.IsTrue(result.Values.Contains(person.Name), $"Name {person.Name} was not picked");
            }
        }
    }


}