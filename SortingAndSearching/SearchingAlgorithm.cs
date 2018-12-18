using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class SearchingAlgorithm
    {
        public int BinarySearch(int[] sortedArray, int numberToSearch)
        {
            return Search(sortedArray, 0, sortedArray.Length-1, numberToSearch);
        }

        private int Search(int[] numbers, int low, int high, int search)
        {
            if (low > high) return -1;

            int mid = (low + high) / 2;
            int midValue = numbers[mid];

            if (search < midValue)
                return Search(numbers, low, mid - 1, search);

            else if (search > midValue)
                return Search(numbers, mid + 1, high, search);

            else
                return mid;                
        }
    }

    [TestFixture]
    public class TestSearchingAlgorithm
    {
        [Test]
        public void BinarySearch_NumberPresentInArray_ShouldReturnNumber()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int expected = 4;
            int numberToSearch = 5;
            SearchingAlgorithm searchingAlgorithm = new SearchingAlgorithm();

            int actual = searchingAlgorithm.BinarySearch(numbers, numberToSearch);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BinarySearch_NumberNotPresentInArray_ShouldReturnNegativeOne()
        {
            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int expected = -1;
            int numberToSearch = 9;
            SearchingAlgorithm searchingAlgorithm = new SearchingAlgorithm();

            int actual = searchingAlgorithm.BinarySearch(numbers, numberToSearch);

            Assert.AreEqual(expected, actual);
        }
    }
}
