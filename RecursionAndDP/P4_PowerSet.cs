using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace RecursionAndDP
{
    /* Power Set: Write a method to return all subsets of a set.  */

    public class P4_PowerSet
    {
        public List<List<int>> GetSubSet(List<int> set)
        {
            if (set == null || set.Count == 0)
                return null;


            return RecurseSubSet(set, 0);
        }

        private List<List<int>> RecurseSubSet(List<int> set, int index)
        {
            List<List<int>> allSubSets;

            if (set.Count == index)
            {
                allSubSets = new List<List<int>>();
                allSubSets.Add(new List<int>());
            }
            else
            {
                allSubSets = RecurseSubSet(set, index + 1);
                int itemAtCurrentIndex = set[index];

                List<List<int>> moreSubSets = new List<List<int>>();

                foreach (List<int> subSet in allSubSets)
                {
                    List<int> newSubSet = new List<int>();
                    newSubSet.Add(itemAtCurrentIndex);
                    newSubSet.AddRange(subSet);
                    moreSubSets.Add(newSubSet);
                }

                allSubSets.AddRange(moreSubSets);
            }
            return allSubSets;
        }
    }

    [TestFixture]
    public class TestPowerSet
    {
        [Test]
        public void GetSubSet_WithNullSet_ShouldReturnNull()
        {
            List<int> set = null;
            P4_PowerSet powerSet = new P4_PowerSet();

            List<List<int>> actual = powerSet.GetSubSet(set);

            Assert.IsNull(actual);
        }

        [Test]
        public void GetSubSet_WithEmptySet_ShouldReturnNull()
        {
            List<int> set = new List<int>();
            P4_PowerSet powerSet = new P4_PowerSet();

            List<List<int>> actual = powerSet.GetSubSet(set);

            Assert.IsNull(actual);
        }

        [Test]
        public void GetSubSet_With1ElementInSet_ShouldReturnListOfSize2()
        {
            List<int> set = new List<int>() { 1 };
            int expectedCount = 2;
            P4_PowerSet powerSet = new P4_PowerSet();

            List<List<int>> actual = powerSet.GetSubSet(set);

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
        public void GetSubSet_With2ElementInSet_ShouldReturnListOfSize4()
        {
            List<int> set = new List<int>() { 1, 2 };
            int expectedCount = 4;
            P4_PowerSet powerSet = new P4_PowerSet();

            List<List<int>> actual = powerSet.GetSubSet(set);

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
        public void GetSubSet_With3ElementInSet_ShouldReturnListOfSize8()
        {
            List<int> set = new List<int>() { 1, 2, 3 };
            int expectedCount = 8;
            P4_PowerSet powerSet = new P4_PowerSet();

            List<List<int>> actual = powerSet.GetSubSet(set);

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}
