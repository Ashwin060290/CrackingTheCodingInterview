using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    /* Sorted Merge: You are given two sorted arrays, A and B, where A has a large enough buffer at the
        end to hold B. Write a method to merge B into A in sorted order.  */

    public class P1_SortedMerge
    {
        public int[] MergedSortedArray(int[] a, int[] b, int totalCountInA, int totalCountInB)
        {
            int lastIndexA = totalCountInA - 1;
            int lastIndexB = totalCountInB - 1;

            int mergedCount = a.Length - 1;

            while (lastIndexB >= 0)
            {
                if (lastIndexA >= 0 && a[lastIndexA] > b[lastIndexB])
                {
                    a[mergedCount] = a[lastIndexA];
                    lastIndexA--;
                }
                else
                {
                    a[mergedCount] = b[lastIndexB];
                    lastIndexB--;
                }
                mergedCount--;
            }

            return a;
        }
    }

    [TestFixture]
    public class TestSortedMerge
    {
        [Test]
        public void SortedMerge_WithSortedArrayAAndB_ShouldReturnAContainingMergedAAndBSortedArray()
        {
            int[] A = new int[] { 1, 4, 5, 0, 0, 0 };
            int[] B = new int[] { 2, 3, 6 };
            int sizeA = 3, sizeB = 3;
            int[] expected = new int[] { 1, 2, 3, 4, 5, 6 };
            P1_SortedMerge sortedMerge = new P1_SortedMerge();

            int[] actual = sortedMerge.MergedSortedArray(A, B, sizeA, sizeB);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
