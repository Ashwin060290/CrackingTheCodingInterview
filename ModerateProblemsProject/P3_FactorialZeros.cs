using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerateProblemsProject
{
    public class P3_FactorialZeros
    {
        /* Factorial zeros: Write an algorithm which computes the number of trailing zeros in n factorial. */

        public int GetNumberOfZerosInFactorial(int number)
        {
            int countOf5 = 0;

            for (int i = 1; i <= number; i++)
            {
                countOf5 += PowerOf5(i);
            }

            return countOf5;
        }

        private int PowerOf5(int num)
        {
            int count = 0;
            while (num % 5 == 0)
            {
                count++;
                num = num / 5;
            }

            return count;
        }
    }

    [TestFixture]
    public class FactorialZerosTests
    {
        [TestCase(4, 0)]
        [TestCase(5, 1)]
        [TestCase(10, 2)]
        [TestCase(19, 3)]
        public void GetNumberOfZerosInFactorial_WithGivenInputNumber_ShouldReturnCorrectNumberOfZerosInNumbersFactorial(int number, int expected)
        {
            P3_FactorialZeros factorialZeros = new P3_FactorialZeros();

            int actual = factorialZeros.GetNumberOfZerosInFactorial(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
