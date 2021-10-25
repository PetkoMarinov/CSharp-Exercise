using CarManager;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {
        private Car car;
        private const string MAKE = "Ford";
        private const string MODEL = "Ford";
        private const double CONSUMPTION = 5.5;
        private const double CAPACITY = 45;

        [SetUp]
        public void Setup()
        {
            this.car = new Car(MAKE, MODEL, CONSUMPTION, CAPACITY);
        }

        [Test]
        public void CtorSetsPropertiesProperly()
        {
            bool success = car.FuelAmount == 0 && car.Make == MAKE && car.Model == MODEL
                && car.FuelConsumption == CONSUMPTION && car.FuelCapacity == CAPACITY;

            Assert.IsTrue(success);
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarMakeThrowExceptionIfNullOrEmpty(string make)
        {
            Assert.That(() => new Car(make, MODEL, CONSUMPTION, CAPACITY),
                Throws.ArgumentException.With.Message
                .EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void CarModelThrowExceptionIfNullOrEmpty(string model)
        {
            Assert.That(() => new Car(MAKE, model, CONSUMPTION, CAPACITY),
                Throws.ArgumentException.With.Message
                .EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CarConsumptionThrowExceptionIfZeroOrNegative(double consumption)
        {
            Assert.That(() => new Car(MAKE, MODEL, consumption, CAPACITY),
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel consumption cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void CarFuelCapacityThrowExceptionIfZeroOrNegative(double capacity)
        {
            Assert.That(() => new Car(MAKE, MODEL, CONSUMPTION, capacity),
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel capacity cannot be zero or negative!"));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelThrowExceptionIfZeroOrNegative(double fuelToRefuel)
        {
            Assert.That(() => car.Refuel(fuelToRefuel),
                Throws.ArgumentException.With.Message
                .EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelIncreasesFuelAmount()
        {
            double fuelToRefuel = 10;
            double fuelBeforeIncrease = car.FuelAmount;

            car.Refuel(fuelToRefuel);
            Assert.IsTrue(car.FuelAmount == (fuelBeforeIncrease + fuelToRefuel));
        }

        [Test]
        public void RefuelCannotExceedCapacity()
        {
            double fuelToRefuel = 46;
            car.Refuel(fuelToRefuel);
            Assert.IsTrue(car.FuelAmount == CAPACITY);
        }

        [Test]
        public void DriveThrowsExceptionIfFuelNeededIsLessThanFuelAmount()
        {
            double distance = 1500;
            Assert.That(() => car.Drive(distance), Throws.InvalidOperationException);
        }

        [Test]
        public void DriveDecreasesFuelAmount()
        {
            double distance = 150;
            car.Refuel(20);
            double fuelAmountBeforeDeparture = car.FuelAmount;
            double expectedFuelOnArrival =
                fuelAmountBeforeDeparture - (distance / 100) * CONSUMPTION;

            car.Drive(distance);
            Assert.IsTrue(car.FuelAmount == expectedFuelOnArrival);
        }
    }
}