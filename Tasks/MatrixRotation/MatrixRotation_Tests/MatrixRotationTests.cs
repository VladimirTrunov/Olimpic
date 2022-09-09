namespace MatrixRotation_Tests
{
    using MatrixRotation_Solution;

    [TestClass]
    public class MatrixRotationTests
    {
        [TestMethod]
        public void GetChainsCountTest_1()
        {
            int row = 4;
            int col = 5;

            Assert.AreEqual(2, MatrixRotation.GetChainsCount(row, col));
        }

        [TestMethod]
        public void GetChainsCountTest_2()
        {
            int row = 8;
            int col = 2;

            Assert.AreEqual(1, MatrixRotation.GetChainsCount(row, col));
        }

        [TestMethod]
        public void GetChainsFromArrayTest_1Chain()
        {
            int[,] items = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            List<Chain> chains = MatrixRotation.GetChainsFromArray(items);

            List<int> result = (from g in chains[0].Items
                                select g.Value).ToList();

            CollectionAssert.AreEquivalent(new List<int> { 1, 4, 7, 8, 9, 6, 3, 2 }, result);
        }

        [TestMethod]
        public void GetChainsFromArrayTest_2Chains()
        {
            int[,] items = new int[4, 4]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };

            List<Chain> chains = MatrixRotation.GetChainsFromArray(items);
            List<int> result1 = (from g in chains[0].Items
                                 select g.Value).ToList();
            List<int> result2 = (from g in chains[1].Items
                                 select g.Value).ToList();

            CollectionAssert.AreEquivalent(new List<int> { 1, 5, 9, 13, 14, 15, 16, 12, 8, 4, 3, 2 }, result1);
            CollectionAssert.AreEquivalent(new List<int> { 6, 10, 11, 7 }, result2);
        }

        [TestMethod]
        public void GetChainsFromArrayTest_3Chains()
        {
            int[,] items = new int[6, 6]
            {
                { 1, 2, 3, 4, 5, 6 },
                { 7, 8, 9, 10, 11, 12 },
                { 13, 14, 15, 16, 17, 18 },
                { 19, 20, 21, 22, 23, 24 },
                { 25, 26, 27, 28, 29, 30 },
                { 31, 32, 33, 34, 35, 36 }
            };

            List<Chain> chains = MatrixRotation.GetChainsFromArray(items);

            List<int> result1 = (from g in chains[0].Items
                                 select g.Value).ToList();
            List<int> result2 = (from g in chains[1].Items
                                 select g.Value).ToList();
            List<int> result3 = (from g in chains[2].Items
                                 select g.Value).ToList();

            CollectionAssert.AreEquivalent(new List<int> { 1, 7, 13, 19, 25, 31, 32, 33, 34, 35, 36, 30, 24, 18, 12, 6, 5, 4, 3, 2 }, result1);
            CollectionAssert.AreEquivalent(new List<int> { 8, 14, 20, 26, 27, 28, 29, 23, 17, 11, 10, 9 }, result2);
            CollectionAssert.AreEquivalent(new List<int> { 15, 21, 22, 16 }, result3);
        }

        [TestMethod]
        public void GetChainsFromArrayTest_4Chain()
        {
            int[,] items = new int[4, 5]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
            };

            List<Chain> chains = MatrixRotation.GetChainsFromArray(items);

            List<int> result = (from g in chains[0].Items
                                select g.Value).ToList();

            List<int> result2 = (from g in chains[1].Items
                                 select g.Value).ToList();

            CollectionAssert.AreEquivalent(new List<int> { 1, 6, 11, 16, 17, 18, 19, 20, 15, 10, 5, 4, 3, 2 }, result);
            CollectionAssert.AreEquivalent(new List<int> { 7, 12, 13, 14, 9, 8 }, result2);
        }

        [TestMethod]
        public void GetUpdatedArrayWithChainsTest()
        {
            int[,] initialArray = new int[,] {
            { 0, 0, 0 },
            { 0, 5, 0 },
            { 0, 0, 0 },
            };

            Chain item = new Chain(new List<Item>
            {
                new Item(0, 0, 1),
                new Item(1, 0, 4),
                new Item(2, 0, 7),
                new Item(2, 1, 8),
                new Item(2, 2, 9),
                new Item(1, 2, 6),
                new Item(0, 2, 3),
                new Item(0, 1, 2)
            });

            int[,] expectedArray = new int[,] {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
            };

            int[,] actualArray = MatrixRotation.GetUpdatedArrayWithChains(initialArray, new List<Chain> { item });

            CollectionAssert.AreEquivalent(actualArray, expectedArray);
        }

        [TestMethod]
        public void MainTest1()
        {
            int[,] initialItems = new int[,]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            int[,] expectedResult = new int[,]
            {
                { 2, 3, 6 },
                { 1, 5, 9 },
                { 4, 7, 8 }
            };

            MatrixRotation matrixRotation = new MatrixRotation(initialItems);
            matrixRotation.Rotate(1);

            CollectionAssert.AreEquivalent(expectedResult, matrixRotation.Matrix);
        }

        [TestMethod]
        public void MainTest2()
        {
            int[,] initialItems = new int[,]
            {
                { 1, 2, 3, 4 },
                { 5, 6, 7, 8 },
                { 9, 10, 11, 12 },
                { 13, 14, 15, 16 }
            };

            int[,] expectedResult = new int[,]
            {
                { 2, 3, 4, 8 },
                { 1, 7, 11, 12 },
                { 5, 6, 10, 16 },
                { 9, 13, 14, 15 }
            };

            MatrixRotation matrixRotation = new MatrixRotation(initialItems);
            matrixRotation.Rotate(1);

            CollectionAssert.AreEquivalent(expectedResult, matrixRotation.Matrix);
        }

        [TestMethod]
        public void MainTest3()
        {
            int[,] initialItems = new int[,]
            {
                { 1, 2, 3, 4, 5 },
                { 6, 7, 8, 9, 10 },
                { 11, 12, 13, 14, 15 },
                { 16, 17, 18, 19, 20 },
            };

            int[,] expectedResult = new int[,]
            {
                { 2, 3, 4, 5, 10 },
                { 1, 8, 9, 14, 15 },
                { 6, 7, 12, 13, 20 },
                { 11, 16, 17, 18, 19 }
            };

            MatrixRotation matrixRotation = new MatrixRotation(initialItems);
            matrixRotation.Rotate(1);

            CollectionAssert.AreEquivalent(expectedResult, matrixRotation.Matrix);
        }

        [TestMethod]
        public void MainTest4()
        {
            int[,] initialItems = new int[,]
            {
                { 1, 2, 3, 4, 5, 6 },
                { 7, 8, 9, 10, 11, 12 },
                { 13, 14, 15, 16, 17, 18 },
                { 19, 20, 21, 22, 23, 24 },
                { 25, 26, 27, 28, 29, 30 },
                { 31, 32, 33, 34, 35, 36 }
            };

            int[,] expectedResult = new int[,]
            {
                { 2, 3, 4, 5, 6, 12 },
                { 1, 9, 10, 11, 17, 18 },
                { 7, 8, 16, 22, 23, 24 },
                { 13, 14, 15, 21, 29, 30 },
                { 19, 20, 26, 27, 28, 36 },
                { 25, 31, 32, 33, 34, 35 }
            };

            MatrixRotation matrixRotation = new MatrixRotation(initialItems);
            matrixRotation.Rotate(1);

            CollectionAssert.AreEquivalent(expectedResult, matrixRotation.Matrix);
        }
    }
}
