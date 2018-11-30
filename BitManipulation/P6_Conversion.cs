using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BitManipulation
{
    public class P6_Conversion
    {
        /* Conversion: Write a function to determine the number of bits you would need to flip to convert
            integer A to integer B.
            EXAMPLE
            Input: 29 (or: 11101), 15 (or: 01111)  
            Outpu : 2*/


        public int Difference(uint number1, uint number2)
        {
            int counter = 0;

            uint xorBetweenTwoNumbers = number1 ^ number2;

            while (xorBetweenTwoNumbers != 0)
            {
                if ((xorBetweenTwoNumbers & 1) == 1)
                {
                    counter++;
                }

                xorBetweenTwoNumbers = xorBetweenTwoNumbers >> 1;
            }
            return counter;
        }
    }

    [TestFixture]
    public class TestConversion
    {
        [Test]
        public void Difference_WithInputNumbers29And15_ShouldReturn2()
        {
            uint a = 29;
            uint b = 15;
            int expected = 2;
            P6_Conversion conversion = new P6_Conversion();

            int actual = conversion.Difference(a, b);

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Difference_WithInputNumbers3And4_ShouldReturn3()
        {
            uint a = 3;
            uint b = 4;
            int expected = 3;
            P6_Conversion conversion = new P6_Conversion();

            int actual = conversion.Difference(a, b);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Difference_WithInputNumbers30And30_ShouldReturn0()
        {
            uint a = 30;
            uint b = 30;
            int expected = 0;
            P6_Conversion conversion = new P6_Conversion();

            int actual = conversion.Difference(a, b);

            Assert.AreEqual(expected, actual);
        }
    }
}
