using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BitManipulation
{
    public class P7_Pairwise
    {
        /* Pairwise Swap: Write a program to swap odd and even bits in an integer with as few instructions as
            possible (e.g., bit 0 and bit 1 are swapped, bit 2 and bit 3 are swapped, and so on). */

        public uint Swap(uint number)
        {
            uint maskForOdd = 0xaaaaaaaa;
            uint odd =  (number & maskForOdd) >> 1;

            uint maskForEven = 0x55555555;
            uint even = (number & maskForEven) << 1;

            uint answer = odd | even;

            return answer;
        }
    }

    [TestFixture]
    public class TestPairwise
    {
        [Test]
        public void Swap_WithInputNumber682_ShouldReturn341()
        {
            uint number = 682;
            uint expected = 341;
            P7_Pairwise pairwise = new P7_Pairwise();

            uint actual = pairwise.Swap(number);

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Swap_WithInputNumber1_ShouldReturn2()
        {
            uint number = 1;
            uint expected = 2;
            P7_Pairwise pairwise = new P7_Pairwise();

            uint actual = pairwise.Swap(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Swap_WithInputNumber4_ShouldReturn8()
        {
            uint number = 4;
            uint expected = 8;
            P7_Pairwise pairwise = new P7_Pairwise();

            uint actual = pairwise.Swap(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Swap_WithInputNumber0_ShouldReturn0()
        {
            uint number = 0;
            uint expected = 0;
            P7_Pairwise pairwise = new P7_Pairwise();

            uint actual = pairwise.Swap(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
