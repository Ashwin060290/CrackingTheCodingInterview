using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class SortingAlgorithms
    {
        public int[] MergeSort(int[] numbers)
        {
            int[] temp = new int[numbers.Length];
            MergeSort(numbers, temp, 0, numbers.Length - 1);
            return numbers;
        }

        private void MergeSort(int[] numbers, int[] temp, int low, int high)
        {
            if (low < high)
            {
                int middle = (low + high) / 2;
                MergeSort(numbers, temp, low, middle);
                MergeSort(numbers, temp, middle + 1, high);
                Merge(numbers, temp, low, middle, high);
            }
        }

        private void Merge(int[] numbers, int[] temp, int low, int middle, int high)
        {
            for (int i = low; i <= high; i++)
                temp[i] = numbers[i];

            int tempLeft = low;
            int tempRight = middle + 1;
            int current = low;

            while (tempLeft <= middle && tempRight <= high)
            {
                if (temp[tempLeft] <= temp[tempRight])
                {
                    numbers[current] = temp[tempLeft];
                    tempLeft++;
                }
                else
                {
                    numbers[current] = temp[tempRight];
                    tempRight++;
                }
                current++;
            }

            int remaining = middle - tempLeft;
            for (int i = 0; i <= remaining; i++)
            {
                numbers[current + i] = temp[tempLeft + i];
            }
        }

        public int[] QuickSort(int[] numbers)
        {
            QuickSort(numbers, 0, numbers.Length - 1);
            return numbers;
        }

        private void QuickSort(int[] numbers, int left, int right)
        {
            int index = Partition(numbers, left, right);

            if(left < index-1)
            {
                QuickSort(numbers, left, index - 1);
            }
            if(index < right)
            {
                QuickSort(numbers, index, right);
            }
        }

        private int Partition(int[] numbers, int left, int right)
        {
            int pivot = numbers[(left + right) / 2];

            while(left <= right)
            {
                while (numbers[left] < pivot)
                    left++;

                while (numbers[right] > pivot)
                    right--;

                if(left<= right)
                {
                    Swap(numbers, left, right);
                    left++;
                    right--;
                }
            }

            return left;
        }

        private void Swap(int[] numbers, int left, int right)
        {
            int temp = numbers[left];
            numbers[left] = numbers[right];
            numbers[right] = temp;
        }
    }

    [TestFixture]
    public class TestSortingAlgorithms
    {
        [Test]
        public void MergeSort_WithArrayOfintegers_ShouldReturnSortedArray()
        {
            int[] numbers = new int[] { 2,5,3,4,1};
            int[] expected = new int[] { 1,2,3,4,5};
            SortingAlgorithms sortingAlgorithms = new SortingAlgorithms();

            int[] actual = sortingAlgorithms.MergeSort(numbers);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void QuickSort_WithArrayOfintegers_ShouldReturnSortedArray()
        {
            int[] numbers = new int[] { 2, 5, 3, 4, 1 };
            int[] expected = new int[] { 1, 2, 3, 4, 5 };
            SortingAlgorithms sortingAlgorithms = new SortingAlgorithms();

            int[] actual = sortingAlgorithms.QuickSort(numbers);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
