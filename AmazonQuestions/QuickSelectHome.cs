using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonQuestions
{
    public class QuickSelectHome
    {
        public int[] GetKSorted(int[] numbers, int k)
        {
            return QuickSelectEasy(numbers, k);
        }

        private int[] QuickSelectEasy(int[] numbers, int k)
        {
            int left = 0, right = numbers.Length - 1;

            while(left <= right)
            {
                int mid = SelectEasy(numbers, left, right);

                if (mid == k)
                    return numbers.Take(k).ToArray();

                else if (mid < k)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return numbers.Take(k).ToArray();
            
        }

        private int SelectEasy(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];

            while(left < right)
            {
                while (left < right && numbers[right] > pivot)
                    right--;

                numbers[left] = numbers[right];

                while (left < right && numbers[left] < pivot)
                    left++;

                numbers[right] = numbers[left];
            }

            numbers[left] = pivot;

            return left;
        }

        private int[] QuickSelect(int[] numbers, int left, int right, int k)
        {
            if (left == right)
                return numbers.Take(k).ToArray();

            int pivot = Select(numbers, left, right);
            int len = pivot - left + 1;

            if (len == k)
                return numbers.Take(k).ToArray();
            else if (len > k)
                return QuickSelect(numbers, left, pivot - 1, k);
            else
                return QuickSelect(numbers, pivot + 1, right, k - len);
        }

        private int Select(int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            int l = left +1;
            int r = right;


            while(true)
            {

                while (l < r && numbers[l] < pivot)
                    l++;

                while (l < r && numbers[r] > pivot)
                    r--;

                if (l >= r)
                    break;

                int temp = numbers[l];
                numbers[l] = numbers[r];
                numbers[r] = temp;
            }

            int t = numbers[left];
            numbers[left] = numbers[r];
            numbers[r] = t;

            return r;
        }
    }

    [TestFixture]
    public class TestQuickSelectHome
    {
        [Test]
        public void TestQuicjSelectHome()
        {
            int[] numbers = new int[] {7,4,2,1,8,6,5,3 };
            int k = 3;
            int[] expected = new int[] { 1, 2, 3 };

            QuickSelectHome qsh = new QuickSelectHome();
            int[] actual = qsh.GetKSorted(numbers, k);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
