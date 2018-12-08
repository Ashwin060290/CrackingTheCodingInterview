using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecursionAndDP
{
    /* Permutations without Dups: Write a method to compute all permutations of a string of unique characters.  */
    public class P7_PermutationsWithoutDups
    {
        public List<string> GetPermutation(string unique)
        {
            List<string> result = new List<string>();

            if (string.IsNullOrEmpty(unique))
            {
                result.Add("");
                return result;
            }

            for (int i = 0; i < unique.Length; i++)
            {
                string left = unique.Substring(0, i);
                string right = unique.Substring(i + 1, unique.Length - i - 1);

                List<string> partialPermutation = GetPermutation(left + right);
                string charBetweenLeftAndRight = unique[i].ToString();
                foreach (string perm in partialPermutation)
                {
                    result.Add(charBetweenLeftAndRight + perm);
                }
            }

            return result;
        }

    }

    [TestFixture]
    public class TestPermutationsWithoutDups
    {
        [Test]
        public void GetPermutation_WithImputStringABC_ShouldReturn6Permutations()
        {
            string unique = "abc";
            int expectedCount = 6;
            P7_PermutationsWithoutDups permutationsWithoutDups = new P7_PermutationsWithoutDups();

            List<string> actual = permutationsWithoutDups.GetPermutation(unique);

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
        public void GetPermutation_WithImputStringABCD_ShouldReturn24Permutations()
        {
            string unique = "abcd";
            int expectedCount = 24;
            P7_PermutationsWithoutDups permutationsWithoutDups = new P7_PermutationsWithoutDups();

            List<string> actual = permutationsWithoutDups.GetPermutation(unique);

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
        public void GetPermutation_WithImputStringABCDE_ShouldReturn120Permutations()
        {
            string unique = "abcde";
            int expectedCount = 120;
            P7_PermutationsWithoutDups permutationsWithoutDups = new P7_PermutationsWithoutDups();

            List<string> actual = permutationsWithoutDups.GetPermutation(unique);

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}
