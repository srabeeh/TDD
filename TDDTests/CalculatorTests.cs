using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_BDD_Practice;

namespace TDDTests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void AddTwoIntegers()
        {
            int answer = Calculator<int>.Add(5, 5);
            int expected = 10;

            Assert.AreEqual(expected,answer);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "String values not allowed in addition operations.")]
        public void AddTwoNonNumbersShouldFail()
        {
            var str1 = "Number";
            var str2 = "Number2";

            var answer = Calculator<string>.Add(str1, str2);

        }
    }
}
