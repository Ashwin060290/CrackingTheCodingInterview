using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitManipulation
{
    /* Next Number: Given a positive integer, print the next smallest and the next largest number that
        have the same number of 1 bits in their binary representation.  */


    public class P4_Number
    {
        public uint GetNextLong(uint number)
        {
            uint temp = number;
            int count0 = 0, count1 = 0;

            while ((temp & 1) == 0 && temp != 0)
            {
                count0++;
                temp = temp >> 1;
            }

            while ((temp & 1) == 1)
            {
                count1++;
                temp = temp >> 1;
            }

            int positionToFlip = count0 + count1;

            uint mask1 = (uint)(1 << positionToFlip);
            number = number | mask1;

            uint mask2 = (uint)~((1 << positionToFlip) - 1);
            number = number & mask2;

            uint mask3 = (uint)((1 << (count1 - 1)) - 1);
            number = number | mask3;

            return number;
        }

        public uint GetNextEasy(uint number)
        {
            uint temp = number;
            int count0 = 0, count1 = 0;

            while ((temp & 1) == 0 && temp != 0)
            {
                count0++;
                temp = temp >> 1;
            }

            while ((temp & 1) == 1)
            {
                count1++;
                temp = temp >> 1;
            }

            number = (uint)(number + (Math.Pow(2,count0) - 1));
            number = number + 1;
            number = (uint)(number + (Math.Pow(2,count1-1) -1));

            return number;
        }

        public uint GetPreviousLong(uint number)
        {
            uint temp = number;
            int count0 = 0, count1 = 0;

            while ((temp & 1) == 1 && temp != 0)
            {
                count1++;
                temp = temp >> 1;
            }

            while ((temp & 1) == 0 )
            {
                count0++;
                temp = temp >> 1;
            }

            int positionToFlip = count0 + count1;

            uint mask1 = (uint) ~(1 << positionToFlip);
            number = number & mask1;

            uint mask2 = (uint)~((1 << positionToFlip) - 1);
            number = number & mask2;

            uint mask3 = (uint)((1 << (count1 + 1)) - 1);
            mask3 = (mask3 << (count0 - 1));
            number = number | mask3;

            return number;
        }

        public uint GetPreviousEasy(uint number)
        {
            uint temp = number;
            int count0 = 0, count1 = 0;

            while ((temp & 1) == 1 && temp != 0)
            {
                count1++;
                temp = temp >> 1;
            }

            while ((temp & 1) == 0)
            {
                count0++;
                temp = temp >> 1;
            }

            number = (uint)(number - (Math.Pow(2, count1) - 1));
            number = number - 1;
            number = (uint)(number - (Math.Pow(2, count0 - 1) - 1));

            return number;
        }
    }

    [TestFixture]
    public class TestNumber
    {
        [Test]
        public void GetNextLong_WithNumberAs5_ShouldReturn6()
        {
            uint number = 5;
            uint expected = 6;
            P4_Number numbers = new P4_Number();

            uint actual = numbers.GetNextLong(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetNextEasy_WithNumberAs5_ShouldReturn6()
        {
            uint number = 5;
            uint expected = 6;
            P4_Number numbers = new P4_Number();

            uint actual = numbers.GetNextEasy(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPreviousLong_WithNumberAs5_ShouldReturn3()
        {
            uint number = 5;
            uint expected = 3;
            P4_Number numbers = new P4_Number();

            uint actual = numbers.GetPreviousLong(number);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPreviousEasy_WithNumberAs5_ShouldReturn3()
        {
            uint number = 5;
            uint expected = 3;
            P4_Number numbers = new P4_Number();

            uint actual = numbers.GetPreviousEasy(number);

            Assert.AreEqual(expected, actual);
        }
    }
}
