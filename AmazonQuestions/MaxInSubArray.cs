using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonQuestions
{
    public class MaxInSubArray
    {
        public int[] GetMaxSubArray(int[] numbers)
        {
            int left = 0;
            int right = 0;
            int min = numbers[0];
            int totalMin = numbers[0];
            int actualLeft = 0, actualRight = 0;

            for(int i = 1; i<numbers.Length; i++)
            {
                if(numbers[i] > numbers[i]+min)
                {
                    left = i;
                    right = i;
                    min = numbers[i];
                }
                else
                {
                    right = i;
                    min = numbers[i] + min;
                }
                //min = Math.Min(numbers[i], min + numbers[i]);

                if(min > totalMin)
                {
                    totalMin = min;
                    actualLeft = left;
                    actualRight = right;
                }
            }

            return new int[] { actualLeft, actualRight, totalMin };
        }
    }

    [TestFixture]
    public class TestMaxInSubArray
    {
        [Test]
        public void GetMaxSubArray_WithValidArray_ShouldReturnAnswer()
        {
            int[] numbers = new int[] { -1, 2, -2, 3, 4, -5, 1 };
            int[] expected = new int[] { 1,4,7};
            MaxInSubArray ms = new MaxInSubArray();

            int[] actual = ms.GetMaxSubArray(numbers);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
