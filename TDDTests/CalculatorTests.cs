using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_BDD_Practice;

namespace TDDTests
{
    [TestClass]
    public class CalculatorTests
    {
        private TestContext _testContextInstance;
        public TestContext TestContext
        {
            get { return _testContextInstance; }
            set { _testContextInstance = value; }
        }

        /// <summary>
        /// Data-Driven Test
        /// WTH is up with the data-driven tests documentation? Ancient
        /// </summary>
        [TestMethod]
        [DataSource(@"Provider=Microsoft.SqlServerCe.Client.4.0; Data Source=C:\src\TDD\TddPractice\TDD_BDD_Practice\TDDTests\Data\CalcData.sdf;", "Numbers")]
        public void AddTwoIntegersDataDriven()
        {
            int add1 = Convert.ToInt32(TestContext.DataRow["FirstNumber"]);
            int add2 = Convert.ToInt32(TestContext.DataRow["SecondNumber"]);
            int expected = Convert.ToInt32(TestContext.DataRow["Sum"]);

            int result = Calculator<int>.Add(add1, add2);

            Assert.AreEqual(expected, result);
        }


        [TestMethod]
        public void AddTwoIntegers()
        {
            int add1 = 5;
            int add2 = 50;

            int expected = 55;
            int result = Calculator<int>.Add(add1, add2);

            Assert.AreEqual(expected, result);
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
