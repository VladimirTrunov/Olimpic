namespace BiggerIsGreater_Tests
{
    using BiggerIsGreater_Solution;

    [TestClass]
    public class BiggerIsGreaterTests
    {
        [TestMethod]
        public void BiggerIsGreaterTests_1()
        {
            string initialValue = "1113";
            string expectedValue = "1131";

            string actualValue = BiggerIsGreaterAlgorithm.Run(initialValue);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void BiggerIsGreaterTests_2()
        {
            string initialValue = "1231";
            string expectedValue = "1312";

            string actualValue = BiggerIsGreaterAlgorithm.Run(initialValue);

            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void BiggerIsGreaterTests_3()
        {
            string initialValue = "147530";
            string expectedValue = "150347";

            string actualValue = BiggerIsGreaterAlgorithm.Run(initialValue);

            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}