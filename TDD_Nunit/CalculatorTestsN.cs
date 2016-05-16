using NUnit.Framework;
using TDD_BDD_Practice;

namespace TDD_Nunit
{
    [TestFixture]
    public class CalculatorTestsN
    {
        [Test]
        public void AddTwoIntegersNUnit()
        {
            int answer = Calculator<int>.Add(5, 5);
            int expected = 10;

            Assert.AreEqual(expected, answer);
        }
    }
}
