using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class P11_PeaksAndValley
    {
        /* Peaks and Valleys: In an array of integers, a "peak" is an element which is greater than or equal to
            the adjacent integers and a "valley" is an element which is less than or equal to the adjacent integers. For example, in the array {5, 8, 6, 2, 3, 4, 6}, {8, 6} are peaks and {5, 2} are valleys. Given an array
            of integers, sort the array into an alternating sequence of peaks and valleys.
            EXAMPLE
            Input: {5, 3, 1, 2, 3}
            Output: {5, 1, 3, 2, 3} */

        public int[] GetPeakAndValley(int[] array)
        {
            for(int i = 1; i < array.Length; i+=2)
            {
                int biggestNumberIndex = GetBiggestNumber(array, i);
                if(biggestNumberIndex != i)
                {
                    Swap(ref array, i, biggestNumberIndex);
                }

            }

            return array;
        }

        private int GetBiggestNumber(int[] array, int middleIndex)
        {
            int arraySize = array.Length;
            int leftIndex = middleIndex - 1;
            int rightIndex = middleIndex + 1;

            int leftValue = (leftIndex >= 0 && leftIndex < arraySize) ? array[leftIndex] : int.MinValue;
            int middleValue = array[middleIndex];
            int rightValue = (rightIndex >= 0 && rightIndex < arraySize) ? array[rightIndex] : int.MinValue;

            int biggestValue = Math.Max(leftValue, Math.Max(middleValue, rightValue));

            if (biggestValue == leftValue)
                return leftIndex;
            else if (biggestValue == rightValue)
                return rightIndex;
            else
                return middleIndex;
        }

        private void Swap(ref int[] array, int left, int right)
        {
            int temp = array[left];
            array[left] = array[right];
            array[right] = temp;            
        }
    }

    [TestFixture]
    public class PeaksAndValleyTests
    {
        private bool CheckPeakAndValley(int[] array)
        {
            for (int i = 1; i < array.Length; i += 2)
            {
                int arraySize = array.Length;
                int leftIndex = i - 1;
                int rightIndex = i + 1;

                int leftValue = (leftIndex >= 0 && leftIndex < arraySize) ? array[leftIndex] : int.MinValue;
                int middleValue = array[i];
                int rightValue = (rightIndex >= 0 && rightIndex < arraySize) ? array[rightIndex] : int.MinValue;

                if (middleValue < leftValue || middleValue < rightValue)
                {
                    return false;
                }
            }
            return true;
        }

        [Test]
        public void GetPeakAndValley_WithInputArray1_ShouldReturnCorrectArrayWithPeaksAndValleys()
        {
            int[] array = new int[] { 5, 3, 1, 2, 3 };
            P11_PeaksAndValley peaksAndValley = new P11_PeaksAndValley();

            int[] answer = peaksAndValley.GetPeakAndValley(array);

            bool isPeakAndValley = CheckPeakAndValley(answer);
            Assert.IsTrue(isPeakAndValley);
        }

        [Test]
        public void GetPeakAndValley_WithInputArray2_ShouldReturnCorrectArrayWithPeaksAndValleys()
        {
            int[] array = new int[] { 0,1,4,7,8,9};
            P11_PeaksAndValley peaksAndValley = new P11_PeaksAndValley();

            int[] answer = peaksAndValley.GetPeakAndValley(array);

            bool isPeakAndValley = CheckPeakAndValley(answer);
            Assert.IsTrue(isPeakAndValley);
        }
    }
}
