namespace RadioTransmitters_Tests
{
    using RadioTransmitters_Solution;

    [TestClass]
    public class RadioTransmittersTests
    {
        [TestMethod]
        public void RadioTransmittersTest_1()
        {
            List<int> houses = new List<int> { 1, 2, 3, 7 };

            Town town = new Town(houses);
            town.SetTransmitters(1);

            Assert.AreEqual(2, town.Transmitters.Count);
        }

        [TestMethod]
        public void RadioTransmittersTest_2()
        {
            List<int> houses = new List<int> { 1, 2, 3, 7 };

            Town town = new Town(houses);
            town.SetTransmitters(4);

            Assert.AreEqual(1, town.Transmitters.Count);
        }
    }
}
