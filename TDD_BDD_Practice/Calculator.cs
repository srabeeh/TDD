using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_BDD_Practice
{
    public static class Calculator<T>
    {
        public static T Add(T a, T b)
        {
            if (!IsNumber(a) || !IsNumber(b))
            {
                throw new InvalidOperationException("Value is not a number!");
            }

            dynamic val1 = a;
            dynamic val2 = b;
            return val1 + val2;
        }

        public static T Subtract(T a, T b)
        {
            dynamic val1 = a;
            dynamic val2 = b;
            return val1 - val2;
        }

        public static bool IsNumber(T number)
        {
            return number is sbyte
                   || number is byte
                   || number is short
                   || number is long
                   || number is ulong
                   || number is int
                   || number is uint
                   || number is float
                   || number is double
                   || number is decimal;
        }
    }
}
