using ExtendedDatabase;
using NUnit.Framework;
using System;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private ExtendedDatabase.ExtendedDatabase data;
       // private int count;

        [SetUp]
        public void Setup()
        {
            this.data = new ExtendedDatabase.ExtendedDatabase();
        }

        [Test]
        public void CountReturnsArrayLength()
        {
            for (int i = 0; i < 16; i++)
            {
                data.Add(new Person(i, $"{i}"));
            }
            Assert.AreEqual(data.Count, 16);
        }

        [Test]
        public void AddMethodThrowsExceptionWhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                data.Add(new Person(i, $"{i}"));
            }

            Assert.That(() => data.Add(new Person(20, "Gosho")),
                Throws.InvalidOperationException.With.Message
                .EqualTo($"Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void AddThrowsExceptionWhenAddingPersonWithSameName()
        {
            string name = "Gosho";
            data.Add(new Person(1, name));
            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(2, name)));
        }

        [Test]
        public void AddThrowsExceptionWhenAddingPersonWithSameId()
        {
            long id = 5;
            data.Add(new Person(id, "Gosho"));
            Assert.Throws<InvalidOperationException>(() => data.Add(new Person(id, "Tosho")));
        }

        [Test]
        public void CtorThrowsAnExceptionWhenCapacityIsExceeded()
        {
            var people = new Person[17];
            Assert.Throws<ArgumentException>(() =>
                new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void RemoveThrowsExceptionIfEmpty()
        {
            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void RemoveDecreasesTheCount()
        {
            for (int i = 0; i < 5; i++)
            {
                data.Add(new Person(i, $"{i}"));
            }

            int length = data.Count;
            data.Remove();
            Assert.IsTrue(data.Count == length - 1);
        }
        
        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindByUsernameThrowsExceptionIfNullOrEmpty(string name)
        {
            Assert.That(() => data.FindByUsername(name), Throws.ArgumentNullException);
        }

        [Test]
        public void FindByUsernameThrowsExceptionIfNoSuchUser()
        {
            data.Add(new Person(25, "Pesho"));
            Assert.That(() => data.FindByUsername("Gosho"), Throws.InvalidOperationException);
        }

        [Test]
        [TestCase("Pesho")]
        public void FindByUsernameReturnsUser(string name)
        {
            long id = 25;
            Person person = new Person(id, name);
            data.Add(person);

            Assert.AreSame(person, data.FindByUsername(name));
        }

        [Test]
        public void FindByIdThrowsExceptionIfLessThanZero()
        {
            long id = -1;
            data.Add(new Person(id, "Gosho"));
            Assert.Throws<ArgumentOutOfRangeException>(() => data.FindById(id));
        }

        [Test]
        public void FindByIdThrowsExceptionIfNoSuchId()
        {
            long id = 25;
            data.Add(new Person(id, "Pesho"));
            Assert.That(() => data.FindById(26), Throws.InvalidOperationException);
        }

        [Test]
        public void FindByIdReturnsUser()
        {
            long id = 25;
            Person person = new Person(id, "Gosho");
            data.Add(person);

            Assert.AreSame(person, data.FindById(id));
        }
    }
}