using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonQuestions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace AmazonQuestions
{
    public class MedianFinder
    {
        /** initialize your data structure here. */
        SortedSet<int[]> _lSet;
        SortedSet<int[]> _hSet;
        int _c;

        public MedianFinder()
        {
            _lSet = new SortedSet<int[]>(new IntComparer());
            _hSet = new SortedSet<int[]>(new IntComparer());
            _c = 0;
        }

        public void AddNum(int num)
        {
            int[] n = new int[] { num, _c++ };
            if (_lSet.Count == 0)
            {
                _lSet.Add(n);
                return;
            }

            if (_lSet.Count == _hSet.Count)
            {
                if (num <= _lSet.Max[0])
                {
                    _lSet.Add(n);
                }
                else
                {
                    _hSet.Add(n);
                    _lSet.Add(_hSet.Min);
                    _hSet.Remove(_hSet.Min);
                }
            }
            else
            {
                if (num <= _lSet.Max[0])
                {
                    _lSet.Add(n);
                    int[] r = _lSet.Max;
                    _hSet.Add(r);
                    _lSet.Remove(r);
                }
                else
                {
                    _hSet.Add(n);
                }
            }

        }

        public double FindMedian()
        {

            if (_lSet.Count == _hSet.Count)
            {
                return (_lSet.Max[0] + _hSet.Min[0]) / 2d;
            }
            else
            {
                return _lSet.Max[0] * 1d;
            }

        }
    }
    
}

[TestFixture]
public class TestMedianFinder
{
    [Test]
    public void GetMedianTest()
    {
        MedianFinder mf = new MedianFinder();
        double m;
        mf.AddNum(-1);
        m = mf.FindMedian();

        mf.AddNum(-2);
        m = mf.FindMedian();

        mf.AddNum(-3);
        m = mf.FindMedian();

        mf.AddNum(-4);
        m = mf.FindMedian();

        mf.AddNum(-5);
        m = mf.FindMedian();
    }
}


internal class IntComparer : IComparer<int[]>
{
    public int Compare(int[] a, int[] b)
    {
        int result = a[0].CompareTo(b[0]);


        if (result == 0)
            result = a[1].CompareTo(b[1]);

        return result;
    }
}
