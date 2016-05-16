using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_BDD_Practice
{
    class Program
    {
        static void Main(string[] args)
        {
            var num = Calculator<int>.Add(5, 10);
            Console.WriteLine(num);
            Console.ReadLine();
        }
    }
}
