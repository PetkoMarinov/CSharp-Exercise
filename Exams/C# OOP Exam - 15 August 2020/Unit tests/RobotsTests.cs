namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private Robot robot;
        private const string NAME = "Gosho";
        private const int MAX_BATTERY = 100;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot(NAME, MAX_BATTERY);
        }

        [Test]
        public void RobotCtorSetsValuesProperly()
        {
            Assert.IsTrue(robot.Name == NAME && robot.MaximumBattery == MAX_BATTERY
                && robot.Battery == MAX_BATTERY);
        }

        [Test]
        public void RobotManagerCapacityThrowsExeptionIfNegative()
        {
            int capacity = -1;
            Assert.That(() => new RobotManager(capacity), Throws.ArgumentException);
        }

        [Test]
        public void RobotManagerCountReturnsProperValues()
        {
            RobotManager robotManager = new RobotManager(20);
            robotManager.Add(robot);
            Assert.IsTrue(robotManager.Count == 1);
        }

        [Test]
        public void RobotManagerAddMethodThrowsExceptionIfRobotExists()
        {
            RobotManager robotManager = new RobotManager(20);
            robotManager.Add(robot);

            string name = "Gosho";
            Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(new Robot(name, 35)));
        }

        [Test]
        public void RobotManagerAddMethodThrowsExceptionIfCapacityIsFull()
        {
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(robot);
            robotManager.Add(new Robot("Pesho", 36));

            string name = "Ivan";
            int age = 28;

            Assert.Throws<InvalidOperationException>(()
                => robotManager.Add(new Robot(name, age)));
        }

        [Test]
        public void RobotManagerRemoveMethodThrowsExceptionIfRobotToRemoveIsNull()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);
            robotManager.Add(new Robot("Ivan", 26));
            string robotToRemove = "Pesho";

            Assert.Throws<InvalidOperationException>(()
                 => robotManager.Remove(robotToRemove));
        }

        [Test]
        public void RobotManagerRemoveMethodRemoveRobot()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);
            robotManager.Add(new Robot("Ivan", 26));
            string robotToRemove = "Gosho";

            robotManager.Remove(robotToRemove);
            Assert.IsTrue(robotManager.Count == 1);
        }

        [Test]
        public void RobotManagerWorkMethodThrowsExceptionIfRobotToWorkIsNull()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);
            robotManager.Add(new Robot("Ivan", 26));
            string robotToWork = "Pesho";
            string job = "dance";
            int batteryUsage = 50;

            Assert.Throws<InvalidOperationException>(()
                 => robotManager.Work(robotToWork, job, batteryUsage));
        }

        [Test]
        public void RobotManagerWorkMethodThrowsExceptionIfRobotBatteryIsNotEnough()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);
            robotManager.Add(new Robot("Ivan", 26));
            string robotToWork = "Gosho";
            string job = "dance";
            int batteryUsage = 105;

            Assert.Throws<InvalidOperationException>(()
                 => robotManager.Work(robotToWork, job, batteryUsage));
        }

        [Test]
        public void RobotManagerBatteryDecreasesWithUsage()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);

            int startingBattery = robot.Battery;
            int batteryUsage = 65;
            robotManager.Work(NAME, "clean", batteryUsage);

            int restBattery = startingBattery - batteryUsage;
            Assert.IsTrue(robot.Battery == restBattery);
        }

        [Test]
        public void RobotManagerChargeMethodThrowsExceptionIfRobotToChargeIsNull()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);
            robotManager.Add(new Robot("Ivan", 26));
            string robotToCharge = "Pesho";

            Assert.Throws<InvalidOperationException>(()
                 => robotManager.Charge(robotToCharge));
        }

        [Test]
        public void RobotManagerChargeIncreasesBatteryToMax()
        {
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);
            
            int batteryUsage = 65;
            robotManager.Work(NAME, "clean", batteryUsage);

            int restBatteryOfUsedRobot = robot.Battery - batteryUsage;
            robotManager.Charge(NAME);

            Assert.IsTrue(robot.Battery == MAX_BATTERY);
        }
    }
}
