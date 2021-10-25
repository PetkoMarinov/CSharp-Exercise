using NUnit.Framework;
using System.Linq;

namespace Tests
{
    //[TestFixture]
    public class DatabaseTests
    {
        private Database.Database data;

        [SetUp]
        public void Setup()
        {
            data = new Database.Database();
        }

        [Test]
        public void AddThrowExceptionWhenCapacityIsExceeded()
        {
            for (int i = 0; i < 16; i++)
            {
                data.Add(i);
            }

            Assert.That(() => data.Add(1),
                Throws.InvalidOperationException.With.Message
                .EqualTo("Array's capacity must be exactly 16 integers!"));
        }

        [Test]
        public void Remove_ThrowExceptionWhenDatabaseIsEmpty()
        {
            Assert.That(() => data.Remove(),
                Throws.InvalidOperationException);
        }

        [Test]
        public void Remove_RemovesOnlyLastIndex()
        {
            for (int i = 0; i <= 5; i++)
            {
                data.Add(i);
            }

            data.Remove();
            var copy = data.Fetch();
            
            Assert.IsTrue(!copy.Contains(5));
        }

        [Test]
        public void CountReturnsRightValue()
        {
            for (int i = 0; i <= 5; i++)
            {
                data.Add(i);
            }

            Assert.IsTrue(data.Count==6);
        }
    }
}