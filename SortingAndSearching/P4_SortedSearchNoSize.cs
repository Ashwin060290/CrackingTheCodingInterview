using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    /* Sorted Search, No Size: You are given an array like data structure Listy which lacks a size
        method. It does, however, have an elementAt ( i) method that returns the element at index i in
        0( 1) time. If i is beyond the bounds of the data structure, it returns -1. (For this reason, the data
        structure only supports positive integers.) Given a Li sty which contains sorted, positive integers,
        find the index at which an element x occurs. If x occurs multiple times, you may return any index. */

    public class P4_SortedSearchNoSize
    {
        public int GetIndexInNoSizeSortedList(int number, NoSizeSortedList list)
        {
            int index = 1;

            while (list.GetElementAt(index) != -1 && list.GetElementAt(index) <= number)
                index *= 2;

            return BinarySearch(list, number, index / 2, index);
        }

        private int BinarySearch(NoSizeSortedList list, int number, int low, int high)
        {
            if(low <= high)
            {
                int mid = (low + high) / 2;

                if (list.GetElementAt(mid) == number)
                    return mid;

                if (list.GetElementAt(mid) == -1 || list.GetElementAt(mid) > number)
                {
                    return BinarySearch(list, number, low, mid - 1);
                }

                else
                {
                    return BinarySearch(list, number, mid + 1, high);
                }
            }
            else
            {
                return -1;
            }
            
        }
    }

    public class NoSizeSortedList
    {
        private int _size;
        public int[] _array;

        public NoSizeSortedList(int size)
        {
            _size = size;
            _array = new int[size];
        }

        public int GetElementAt(int index)
        {
            if (index < 0 || index >= _size)
                return -1;

            return _array[index];
        }
    }

    [TestFixture]
    public class TestSortedSearchNoSize
    {
        [Test]
        public void GetIndexInNoSizeSortedList_WithNumberExistingInListThatIs0_ShouldReturnindex0()
        {
            NoSizeSortedList list = new NoSizeSortedList(5);
            list._array[0] = 0; list._array[1] = 1; list._array[2] = 2; list._array[3] = 3; list._array[4] = 4;
            P4_SortedSearchNoSize sortedSearchNoSize = new P4_SortedSearchNoSize();
            int expected = 0;

            int actual = sortedSearchNoSize.GetIndexInNoSizeSortedList(0,list);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndexInNoSizeSortedList_WithNumberExistingInListThatIs4_ShouldReturnindex4()
        {
            NoSizeSortedList list = new NoSizeSortedList(5);
            list._array[0] = 0; list._array[1] = 1; list._array[2] = 2; list._array[3] = 3; list._array[4] = 4;
            P4_SortedSearchNoSize sortedSearchNoSize = new P4_SortedSearchNoSize();
            int expected = 4;

            int actual = sortedSearchNoSize.GetIndexInNoSizeSortedList(4, list);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndexInNoSizeSortedList_WithNumberExistingInListThatIs2_ShouldReturnindex2()
        {
            NoSizeSortedList list = new NoSizeSortedList(5);
            list._array[0] = 0; list._array[1] = 1; list._array[2] = 2; list._array[3] = 3; list._array[4] = 4;
            P4_SortedSearchNoSize sortedSearchNoSize = new P4_SortedSearchNoSize();
            int expected = 2;

            int actual = sortedSearchNoSize.GetIndexInNoSizeSortedList(2, list);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndexInNoSizeSortedList_WithNumberExistingInListThatIs3_ShouldReturnindex3()
        {
            NoSizeSortedList list = new NoSizeSortedList(5);
            list._array[0] = 0; list._array[1] = 1; list._array[2] = 2; list._array[3] = 3; list._array[4] = 4;
            P4_SortedSearchNoSize sortedSearchNoSize = new P4_SortedSearchNoSize();
            int expected = 3;

            int actual = sortedSearchNoSize.GetIndexInNoSizeSortedList(3, list);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetIndexInNoSizeSortedList_WithNumberNotExistingInListThatIs5_ShouldReturnNegativeOne()
        {
            NoSizeSortedList list = new NoSizeSortedList(5);
            list._array[0] = 0; list._array[1] = 1; list._array[2] = 2; list._array[3] = 3; list._array[4] = 4;
            P4_SortedSearchNoSize sortedSearchNoSize = new P4_SortedSearchNoSize();
            int expected = -1;

            int actual = sortedSearchNoSize.GetIndexInNoSizeSortedList(5, list);

            Assert.AreEqual(expected, actual);
        }
    }
}
