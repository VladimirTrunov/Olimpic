using MakingCandies;

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
    }
}