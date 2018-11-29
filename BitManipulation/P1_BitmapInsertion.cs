using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitManipulation
{
    public class Insertion
    {
        /* Insertion: You are given two 32-bit numbers, N and M, and two bit positions, i and
            j. Write a method to insert M into N such that M starts at bit j and ends at bit i. You
            can assume that the bits j through i have enough space to fit all of M. That is, if
            M = 10011, you can assume that there are at least 5 bits between j and i. You would not, for
            example, have j = 3 and i = 2, because M could not fully fit between bit 3 and bit 2.
            EXAMPLE
            Input: N = 10000000000, M = 10011, i = 2, j = 6
            Output: N = 10001001100 
        */

        public int Insert(int n, int m, int i, int j)
        {
            int allOnes = ~0;

            int left = allOnes  << (j +1);
            int right = ~(allOnes << i);

            int mask = left | right;

            n = n & mask;

            m = m << i;

            return n | m;
        }           
    }

    [TestFixture]
    public class TestInsertion
    {
        #region Insert

        [Test]
        public void Insert_WithGivenValues_ShouldReturnRightValue()
        {
            int n = 1024, m = 19;
            int i = 2, j = 6;
            int expected = 1100;

            Insertion insertion = new Insertion();
            int actual = insertion.Insert(n, m, i, j);

            Assert.AreEqual(actual, expected);
        }
        #endregion
    }
}
