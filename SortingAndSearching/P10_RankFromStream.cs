using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class P10_RankFromStream
    {
        RankNode root = null;

        public void Track(int d)
        {
            if (root == null)
                root = new RankNode(d);
            else
                root.Insert(d);
        }

        public int GetRank(int number)
        {
            if (root == null)
                return -1;
            else
                return root.GetRank(number);
        }
    }

    public class RankNode
    {
        public int Data;
        public RankNode Left, Right;
        public int LeftSize;

        public RankNode(int d)
        {
            Data = d;
        }

        public void Insert(int d)
        {
            if (d <= Data)
            {
                if (Left != null)
                {
                    Left.Insert(d);
                }
                else
                {
                    Left = new RankNode(d);                   
                }
                LeftSize++;
            }
            else
            {
                if (Right != null)
                {
                    Right.Insert(d);
                }
                else
                {
                    Right = new RankNode(d);
                }
            }
        }

        public int GetRank(int d)
        {
            if (Data == d)
                return LeftSize;

            if (d < Data)
            {
                if (Left == null)
                    return -1;
                else
                    return Left.GetRank(d);
            }
            else
            {
                int rightRank = (Right == null) ? -1 : Right.GetRank(d);

                if (rightRank == -1)
                    return -1;
                else
                    return rightRank + 1 + LeftSize;
            }
        }
    }

    [TestFixture]
    public class RankFromStreamTests
    {
        private P10_RankFromStream _rankFromStream;
        
        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _rankFromStream = new P10_RankFromStream();
            _rankFromStream.Track(20);
            _rankFromStream.Track(15);
            _rankFromStream.Track(25);
            _rankFromStream.Track(10);
            _rankFromStream.Track(23);
            _rankFromStream.Track(5);
            _rankFromStream.Track(13);
            _rankFromStream.Track(24);
        }

        [TestCase(20,4)]
        [TestCase(5, 0)]
        [TestCase(13, 2)]
        [TestCase(23, 5)]
        [TestCase(25, 7)]
        public void GetRank_WithValidExistingNumber_ShouldReturnCorrectRank(int number, int rank)
        {
            int numberToGetRankFor = number;
            int expectedRank = rank;

            int actualRank = _rankFromStream.GetRank(numberToGetRankFor);

            Assert.AreEqual(expectedRank, actualRank);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _rankFromStream = null;
        }

    }
}
