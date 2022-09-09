namespace MatrixRotation_Tests
{
    using MatrixRotation_Solution;

    [TestClass]
    public class ChainTests
    {
        [TestMethod]
        public void ChainRotationTest()
        {
            List<Item> items = new List<Item>
            {
                new Item(0,0,1),
                new Item(1,0,2),
                new Item(2,0,3),
            };
            Chain chain = new Chain(items);
            chain.MoveForward();

            Assert.AreEqual(3, chain.Items[0].Value);
            Assert.AreEqual(1, chain.Items[1].Value);
            Assert.AreEqual(2, chain.Items[2].Value);
        }
    }
}