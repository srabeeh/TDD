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

        [TestMethod]
        [DataSource("System.Data.SqlClient", @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=ShoppingCart;Integrated Security = True;", "AddIntegers", DataAccessMethod.Sequential)]
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
