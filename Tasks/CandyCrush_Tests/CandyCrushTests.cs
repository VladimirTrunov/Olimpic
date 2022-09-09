namespace CandyCrush_Tests
{
    using CandyCrush_Solution;

    [TestClass]
    public class CandyCrushTests
    {
        [TestMethod]
        public void CandyConstructorTest()
        {
            char name = 'n';
            int length = 4;

            Candy candy = new Candy(name, length);

            Assert.AreEqual(name, candy.Name);
            Assert.AreEqual(length, candy.Length);
        }

        [TestMethod]
        public void GetCandiesTest_1()
        {
            string line = "ABBCCC";

            List<Candy> candies = CandyCrush.GetCandies(line);

            Assert.AreEqual(3, candies.Count);

            Assert.AreEqual('A', candies[0].Name);
            Assert.AreEqual('B', candies[1].Name);
            Assert.AreEqual('C', candies[2].Name);

            Assert.AreEqual(1, candies[0].Length);
            Assert.AreEqual(2, candies[1].Length);
            Assert.AreEqual(3, candies[2].Length);
        }

        [TestMethod]
        public void GetCandiesTest_2()
        {
            string line = "AAAAAA";

            List<Candy> candies = CandyCrush.GetCandies(line);

            Assert.AreEqual(1, candies.Count);

            Assert.AreEqual('A', candies[0].Name);
            Assert.AreEqual(6, candies[0].Length);
        }

        [TestMethod]
        public void GetCandiesTest_3()
        {
            string line = "A";

            List<Candy> candies = CandyCrush.GetCandies(line);

            Assert.AreEqual(1, candies.Count);

            Assert.AreEqual('A', candies[0].Name);
            Assert.AreEqual(1, candies[0].Length);
        }

        [TestMethod]
        public void GetLineFromCandiesTest()
        {
            List<Candy> candies = new List<Candy>
            {
                new Candy('A', 1),
                new Candy('B', 2),
                new Candy('C', 3)
            };

            string expectedResult = "ABBCCC";
            string actualResult = CandyCrush.GetLineFromCandies(candies);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void RemoveFullCandiesTest()
        {
            List<Candy> candies = new List<Candy>
            {
                new Candy('A', 1),
                new Candy('B', 4),
                new Candy('A', 2)
            };

            List<Candy> remainedCandies = CandyCrush.RemoveFullCandies(candies);

            Assert.AreEqual(2, remainedCandies.Count);
            Assert.AreEqual('A', remainedCandies[0].Name);
            Assert.AreEqual('A', remainedCandies[1].Name);
            
            Assert.AreEqual(1, remainedCandies[0].Length);
            Assert.AreEqual(2, remainedCandies[1].Length);
        }

        [TestMethod]
        public void CrushCandiesTest_1()
        {
            string line = "ABBBCC";
            string expectedResult = "ACC";
            string actualResult = CandyCrush.CrushCandies(line);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CrushCandiesTest_2()
        {
            string line = "ABCCCBB";
            string expectedResult = "A";
            string actualResult = CandyCrush.CrushCandies(line);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CrushCandiesTest_3()
        {
            string line = "ABCCCBBAAC";
            string expectedResult = "C";
            string actualResult = CandyCrush.CrushCandies(line);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}