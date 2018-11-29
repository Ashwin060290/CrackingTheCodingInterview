using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitManipulation
{
    public class P3_FlipBit
    {

        /* Flip Bit to Win: You have an integer and you can flip exactly one bit from a 0 to a 1. Write code to
            find the length of the longest sequence of ls you could create.
            EXAMPLE
            Input: 1775 (or: 11011101111)
            Output: 8 */

        public int GetMaxLengthOfOnes(uint number)
        {
            
            if (~number == 0)
                return 32;

            int previousSize = 0;
            int currentSize = 0;
            int maxLength = 1;

            while (number != 0)
            {
                if((number & 1) == 1)
                {
                    currentSize += 1;
                }

                else
                {
                    uint nextNumber = number >> 1;
                     if((nextNumber & 1) == 1)
                    {
                        previousSize = currentSize;                        
                    }
                    else
                    {
                        previousSize = 0;
                    }
                    currentSize = 0;
                }

                maxLength = Math.Max((previousSize + 1 + currentSize), maxLength);

                number = number >> 1;
            }

            return maxLength;
        }
    }

    [TestFixture]
    public class TestFlipBit
    {
        private const uint V = 4294967295;

        [Test]
        public void GetMaxLengthOfOnes_WithAll0s_ShouldReturn1()
        {
            uint number = 0;
            int expected = 1;
            P3_FlipBit flipBit = new P3_FlipBit();

            int actual = flipBit.GetMaxLengthOfOnes(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMaxLengthOfOnes_WithAll1s_ShouldReturn32()
        {
            uint number = 4294967295;
            int expected = 32;
            P3_FlipBit flipBit = new P3_FlipBit();

            int actual = flipBit.GetMaxLengthOfOnes(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMaxLengthOfOnes_WithNumberAs1775_ShouldReturn8()
        {
            uint number = 1775;
            int expected = 8;
            P3_FlipBit flipBit = new P3_FlipBit();

            int actual = flipBit.GetMaxLengthOfOnes(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMaxLengthOfOnes_WithNumberAs4_ShouldReturn2()
        {
            uint number = 4;
            int expected = 2;
            P3_FlipBit flipBit = new P3_FlipBit();

            int actual = flipBit.GetMaxLengthOfOnes(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMaxLengthOfOnes_WithNumberAs3_ShouldReturn3()
        {
            uint number = 3;
            int expected = 3;
            P3_FlipBit flipBit = new P3_FlipBit();

            int actual = flipBit.GetMaxLengthOfOnes(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetMaxLengthOfOnes_WithNumberAs5_ShouldReturn3()
        {
            uint number = 5;
            int expected = 3;
            P3_FlipBit flipBit = new P3_FlipBit();

            int actual = flipBit.GetMaxLengthOfOnes(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
