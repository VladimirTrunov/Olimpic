namespace MakingCandies_Tests
{
    using MakingCandies;
    using System.Numerics;

    [TestClass]
    public class MakingCandiesTests
    {
        [TestMethod]
        public void GetRemainedIterationsTest()
        {
            int aim = 10;
            int manpower = 2;
            int machines = 2;
            int exisitngItems = 3;

            BigInteger remainedIterations = MakingCandies.GetRemainedIterations(
                aim,
                manpower,
                machines,
                exisitngItems);

            Assert.AreEqual(2, remainedIterations);
        }

        [TestMethod]
        public void MainTest()
        {
            int manpower = 3;
            int machines = 1;
            int price = 2;
            int aim = 12;

            MakingCandies makingCandies = new MakingCandies(manpower, machines, price, aim);

            long minimalIterations = makingCandies.GetMinimalIterationsForAim();

            Assert.AreEqual(3, minimalIterations);
        }

        [TestMethod]
        public void MainTest_2()
        {
            int manpower = 1;
            int machines = 2;
            int price = 1;
            int aim = 60;

            MakingCandies makingCandies = new MakingCandies(manpower, machines, price, aim);

            long minimalIterations = makingCandies.GetMinimalIterationsForAim();

            Assert.AreEqual(4, minimalIterations);
        }

        [TestMethod]
        public void MainTest_3()
        {
            long manpower = 5184889632;
            long machines = 5184889632;
            int price = 20;
            int aim = 10000;

            MakingCandies makingCandies = new MakingCandies(manpower, machines, price, aim);

            long minimalIterations = makingCandies.GetMinimalIterationsForAim();

            Assert.AreEqual(1, minimalIterations);
        }

        [TestMethod]
        public void MainTest_4()
        {
            long manpower = 1;
            long machines = 1;
            int price = 6;
            int aim = 45;

            MakingCandies makingCandies = new MakingCandies(manpower, machines, price, aim);

            long minimalIterations = makingCandies.GetMinimalIterationsForAim();

            Assert.AreEqual(16, minimalIterations);
        }

        [TestMethod]
        public void MainTest_5()
        {
            long manpower = 4294967297;
            long machines = 4294967297;
            long price = 1000000000000;
            long aim = 1000000000000;

            MakingCandies makingCandies = new MakingCandies(manpower, machines, price, aim);

            long minimalIterations = makingCandies.GetMinimalIterationsForAim();

            Assert.AreEqual(1, minimalIterations);
        }
    }
}
