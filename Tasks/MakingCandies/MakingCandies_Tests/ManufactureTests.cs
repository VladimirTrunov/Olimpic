using MakingCandies;
using System.Numerics;

namespace MakingCandies_Tests
{
    [TestClass]
    public class ManufactureTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            int initialManPower = 3;
            int initialMachines = 5;

            Manufacture manufacture = new Manufacture(initialManPower, initialMachines);

            Assert.AreEqual(initialManPower, manufacture.ManPower);
            Assert.AreEqual(initialMachines, manufacture.Machines);
        }

        [TestMethod]
        public void GetCandiesTest()
        {
            int initialManPower = 3;
            int initialMachines = 5;

            Manufacture manufacture = new Manufacture(initialManPower, initialMachines);

            Assert.AreEqual(15, manufacture.GetCandies());
        }

        [TestMethod]
        public void AddResourcesTest()
        {
            int initialManPower = 3;
            int initialMachines = 5;

            Manufacture manufacture = new Manufacture(initialManPower, initialMachines);
            manufacture.AddResources(4);

            Assert.AreEqual(6, manufacture.ManPower);
            Assert.AreEqual(6, manufacture.Machines);
        }

        [TestMethod]
        public void PredictResourcesTest_1()
        {
            BigInteger manpower = 1;
            BigInteger machines = 5;
            BigInteger add = 3;

            Manufacture.PredictResources(ref manpower, ref machines, add);

            Assert.AreEqual(4, manpower);
            Assert.AreEqual(5, machines);
        }

        [TestMethod]
        public void PredictResourcesTest_2()
        {
            BigInteger manpower = 1;
            BigInteger machines = 5;
            BigInteger add = 7;

            Manufacture.PredictResources(ref manpower, ref machines, add);

            Assert.AreEqual(6, manpower);
            Assert.AreEqual(7, machines);
        }
    }
}