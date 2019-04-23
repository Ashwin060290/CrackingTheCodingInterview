using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AmazonQuestions
{
    public class QuickSelect
    {

        public int GetKSmallestNumber(int[] numbers, int k)
        {
            if (numbers.Length == 0 || numbers.Length < k)
                return 0;

            return Select(ref numbers, 0, numbers.Length -1, k);

        }

        private int Select(ref int[] numbers, int left, int right, int k)
        {
            if (left == right)
                return numbers[left];

            int split = Partition(ref numbers, left, right);

            int len = split - left + 1;

            if (k == len)
                return numbers[split];

            else if (k < split)
            {
                return Select(ref numbers, left, split - 1, k);
            }
            else
            {
                return Select(ref numbers, split + 1, right, k - len);
            }
        }

        private int Partition(ref int[] numbers, int left, int right)
        {
            int pivot = numbers[left];
            int l = left + 1;
            int r = right;

            while (true)
            {
                while (l < right && numbers[l] < pivot)
                    l+=1;

                while (r > left && numbers[r] > pivot)
                    r-=1;

                if (l >= r)
                    break;

                int temp = numbers[l];
                numbers[l] = numbers[r];
                numbers[r] = temp;
            }

            int temp1 = numbers[r];
            numbers[r] = numbers[left];
            numbers[left] = temp1;

            return r;
        }
    }

    [TestFixture]
    public class TestQuickSelect
    {
        [Test]
        public void GetKSmallestNumber()
        {
            int[] numbers = new int[]{1,2,3,4};
            int k = 2;

            QuickSelect qs = new QuickSelect();
            int ans = qs.GetKSmallestNumber(numbers, k);

            Assert.AreEqual(2,ans);
        }
    }
}
