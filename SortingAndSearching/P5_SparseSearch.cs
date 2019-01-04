using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class P5_SparseSearch
    {
        public int IndexOfString(List<string> stringList, string searchString)
        {
            if (stringList == null || stringList.Count == 0 || string.IsNullOrEmpty(searchString))
                return -1;

            return Search(stringList, searchString, 0, stringList.Count - 1);
        }

        private int Search(List<string> stringList, string searchString, int low, int high)
        {
            if (low > high)
                return -1;

            int mid = (low + high) / 2;
            string midString = stringList[mid];

            if (string.IsNullOrEmpty(midString))
            {
                int left = mid - 1;
                int right = mid + 1;

                while (true)
                {
                    if (left < low && right > high)
                        return -1;

                    else if (left >= low && !string.IsNullOrEmpty(stringList[left]))
                    {
                        mid = left;
                        break;
                    }
                    else if (right <= high && !string.IsNullOrEmpty(stringList[right]))
                    {
                        mid = right;
                        break;
                    }

                    left--;
                    right++;
                }
            }

            if (stringList[mid] == searchString)
                return mid;

            else if (stringList[mid].CompareTo(searchString) < 0)
            {
                return Search(stringList, searchString, mid + 1, high);
            }

            else
            {
                return Search(stringList, searchString, low, mid - 1);
            }
        }
    }

    [TestFixture]
    public class TestSparseSearch
    {
        [Test]
        public void IndexOfString_WithStringAtIndex0_ShouldReturn0()
        {
            List<string> stringList = new List<string>() { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };
            string searchString = "at";
            int expected = 0;
            P5_SparseSearch sparseSearch = new P5_SparseSearch();

            int actual = sparseSearch.IndexOfString(stringList, searchString);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IndexOfString_WithStringAtIndex4_ShouldReturn4()
        {
            List<string> stringList = new List<string>() { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };
            string searchString = "ball";
            int expected = 4;
            P5_SparseSearch sparseSearch = new P5_SparseSearch();

            int actual = sparseSearch.IndexOfString(stringList, searchString);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IndexOfString_WithStringAtIndex7_ShouldReturn7()
        {
            List<string> stringList = new List<string>() { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };
            string searchString = "car";
            int expected = 7;
            P5_SparseSearch sparseSearch = new P5_SparseSearch();

            int actual = sparseSearch.IndexOfString(stringList, searchString);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IndexOfString_WithStringAtIndex10_ShouldReturn10()
        {
            List<string> stringList = new List<string>() { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };
            string searchString = "dad";
            int expected = 10;
            P5_SparseSearch sparseSearch = new P5_SparseSearch();

            int actual = sparseSearch.IndexOfString(stringList, searchString);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void IndexOfString_WithStringNotInList_ShouldReturnNegativeOne()
        {
            List<string> stringList = new List<string>() { "at", "", "", "", "ball", "", "", "car", "", "", "dad", "", "" };
            string searchString = "ashwin";
            int expected = -1;
            P5_SparseSearch sparseSearch = new P5_SparseSearch();

            int actual = sparseSearch.IndexOfString(stringList, searchString);

            Assert.AreEqual(expected, actual);
        }
    }
}
