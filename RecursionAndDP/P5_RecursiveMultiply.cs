using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecursionAndDP
{

    /* Recursive Multiply: Write a recursive function to multiply two positive integers without using the
       * operator.You can use addition, subtraction, and bit shifting, but you should minimize the number
        of those operations */


    public class P5_RecursiveMultiply
    {
        public int GetProduct(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            if (a == 1)
                return b;
            if (b == 1)
                return a;

            int small, big;
            if (a <= b)
            {
                small = a; big = b;
            }
            else
            {
                small = b; big = a;
            }

            return Multiply(small, big);

        }

        private int Multiply(int small, int big)
        {
            if (small == 1)
                return big;

            if (small % 2 == 0)
            {
                int total = Multiply(small >> 1, big);
                return (total + total);
            }
            else
            {
                int total = Multiply(small >> 1 , big);
                return (total + total + big);
            }
        }

    }

    [TestFixture]
    public class TestRecursiveMultiply
    {
        [TestCase(2, 4, 8)]
        [TestCase(1, 4, 4)]
        [TestCase(0, 4, 0)]
        [TestCase(5, 5, 25)]
        [TestCase(4, 6, 24)]
        [TestCase(15, 15, 225)]
        [TestCase(0, 5, 0)]
        public void GetProduct_WithTwosInputs_ShouldReturnAnswer(int a, int b, int answer)
        {
            int expected = answer;
            P5_RecursiveMultiply recursiveMultiply = new P5_RecursiveMultiply();

            int actual = recursiveMultiply.GetProduct(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
