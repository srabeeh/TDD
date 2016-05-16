using System;
using NUnit.Framework;
using TDD_BDD_Practice;

namespace TDD_Nunit
{
    [TestFixture]
    public class CalculatorTestsN
    {
        [SetUp]
        public void Setup()
        {
            
        }


        [Test]
        public void AddTwoIntegersNUnit()
        {
            int answer = Calculator<int>.Add(5, 5);
            int expected = 10;

            Assert.AreEqual(expected, answer);
        }

        [TestCase( 1, 1)]
        [TestCase(-1, -1)]
        [TestCase(1, -1)]
        [TestCase(-1, 1)]
        [TestCase(15, 61)]
        public void AddTwoIntegersTestCaseNUnit(int a, int b)
        {
            int answer = Calculator<int>.Add(a, b);
            int expected = a + b;

            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void AddTwoNonNumbersShouldFailNUnit()
        {
            var str1 = "Number";
            var str2 = "Number2";

            Assert.Throws<InvalidOperationException>(delegate
            {
                Calculator<string>.Add(str1, str2);
            });
        }

    }
}
