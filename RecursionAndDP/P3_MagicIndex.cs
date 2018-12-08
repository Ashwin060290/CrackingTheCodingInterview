using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace RecursionAndDP
{

    /* Magic Index: A magic index in an array A [ 0 ••• n -1] is defined to be an index such that A[ i] =
        i. Given a sorted array of distinct integers, write a method to find a magic index, if one exists, in
        array A.
        FOLLOW UP
        What if the values are not distinct? */

    public class P3_MagicIndex
    {
        public int GetIndex(int[] magicArray)
        {
            if (magicArray == null || magicArray.Length == 0)
                return -1;

            return magicFast(magicArray, 0, magicArray.Length - 1);
        }

        private int magicFast(int[] magicArray, int start, int end)
        {
            if (end < start)
                return -1;

            int mid = (start + end) / 2;

            if (magicArray[mid] == mid)
                return mid;

            else if (magicArray[mid] < mid)
            {
                return magicFast(magicArray, mid + 1, end);
            }
            else
            {
                return magicFast(magicArray, start, mid - 1);
            }
        }

        public int GetIndexWithNonDistinct(int[] magicArray)
        {
            if (magicArray == null || magicArray.Length == 0)
                return -1;

            return magicFastNonDistinct(magicArray, 0, magicArray.Length - 1);
        }

        private int magicFastNonDistinct(int[] magicArray, int start, int end)
        {
            if (end < start)
                return -1;

            int midIndex = (start + end) / 2;
            int midValue = magicArray[midIndex];

            if (midValue == midIndex)
                return midIndex;

            int leftIndex = Math.Min(midValue, midIndex - 1);
            int left = magicFastNonDistinct(magicArray, start, leftIndex);
            if (left >= 0)
                return left;

            int rightIndex = Math.Max(midValue, midIndex + 1);
            int right = magicFastNonDistinct(magicArray, rightIndex, end);

            return right;
        }
    }

    [TestFixture]
    public class TestMagicIndex
    {
        [Test]
        public void GetIndex_WithNullMagicArray_ShouldReturnsNegative1()
        {
            int[] magicArray = null;
            int expected = -1;
            P3_MagicIndex magicIndex = new P3_MagicIndex();

            int actual = magicIndex.GetIndex(magicArray);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndex_WithEmptyMagicArray_ShouldReturnsNegative1()
        {
            int[] magicArray = new int[] { };
            int expected = -1;
            P3_MagicIndex magicIndex = new P3_MagicIndex();

            int actual = magicIndex.GetIndex(magicArray);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndex_WithValidMagicArrayHavingMagicIndex_ShouldReturnMagicIndex()
        {
            int[] magicArray = new int[] { -40, -20, -1, 1, 2, 3, 5, 7, 9, 12, 13 };
            int expected = 7;
            P3_MagicIndex magicIndex = new P3_MagicIndex();

            int actual = magicIndex.GetIndex(magicArray);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndex_WithValidMagicArrayNotHavingMagicIndex_ShouldReturnNegativeOne()
        {
            int[] magicArray = new int[] { -40, -20, -1, 1, 2, 3, 5, 6, 9, 12, 13 };
            int expected = -1;
            P3_MagicIndex magicIndex = new P3_MagicIndex();

            int actual = magicIndex.GetIndex(magicArray);

            Assert.AreEqual(expected, actual);
        }


        [Test]
        public void GetIndexNonDistinct_WithValidMagicArrayHavingMagicIndex_ShouldReturnMagicIndex()
        {
            int[] magicArray = new int[] { -10, -5, 2, 2, 2, 3, 4, 7, 9, 12, 13 };
            int expected = 2;
            P3_MagicIndex magicIndex = new P3_MagicIndex();

            int actual = magicIndex.GetIndexWithNonDistinct(magicArray);

            Assert.AreEqual(expected, actual);
        }
    }
}
