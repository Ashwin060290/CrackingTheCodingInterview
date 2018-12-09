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
    public class P7andP8_Permutations
    {
        public List<string> GetPermutationWithoutDups(string unique)
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

                List<string> partialPermutation = GetPermutationWithoutDups(left + right);
                string charBetweenLeftAndRight = unique[i].ToString();
                foreach (string perm in partialPermutation)
                {
                    result.Add(charBetweenLeftAndRight + perm);
                }
            }

            return result;
        }

        public List<string> GetPermutationWithDups(string anyString)
        {
            if (string.IsNullOrEmpty(anyString))
                return null;

            Dictionary<char, int> characterMap = GetCharacterMap(anyString);
            List<string> result = new List<string>();
            GetPerms(characterMap, "", anyString.Length, result);
            return result;
        }

        private void GetPerms(Dictionary<char, int> characterMap, string prefix, int remaining, List<string> result)
        {
            if (remaining == 0)
            {
                result.Add(prefix);
                return;
            }

            foreach (KeyValuePair<char, int> entry in characterMap.ToList())
            {
                int count = characterMap[entry.Key];
                if (count > 0)
                {
                    characterMap[entry.Key] -= 1;
                    GetPerms(characterMap, prefix + entry.Key.ToString(), remaining -1, result);
                    characterMap[entry.Key] = count;
                }
            }
        }

        private Dictionary<char, int> GetCharacterMap(string anyString)
        {
            Dictionary<char, int> characterMap = new Dictionary<char, int>();

            foreach (char c in anyString)
            {
                if (characterMap.ContainsKey(c))
                {
                    characterMap[c] += 1;
                }
                else
                {
                    characterMap.Add(c,1);
                }
            }

            return characterMap;
        }

    }

    [TestFixture]
    public class TestPermutationsWithoutDups
    {
        [Test]
        public void GetPermutationWithoutDups_WithImputStringABC_ShouldReturn6Permutations()
        {
            string unique = "abc";
            int expectedCount = 6;
            P7andP8_Permutations permutations = new P7andP8_Permutations();

            List<string> actual = permutations.GetPermutationWithoutDups(unique);

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
        public void GetPermutationWithoutDups_WithImputStringABCD_ShouldReturn24Permutations()
        {
            string unique = "abcd";
            int expectedCount = 24;
            P7andP8_Permutations permutations = new P7andP8_Permutations();

            List<string> actual = permutations.GetPermutationWithoutDups(unique);

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
        public void GetPermutationWithoutDups_WithImputStringABCDE_ShouldReturn120Permutations()
        {
            string unique = "abcde";
            int expectedCount = 120;
            P7andP8_Permutations permutations = new P7andP8_Permutations();

            List<string> actual = permutations.GetPermutationWithoutDups(unique);

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }

    [TestFixture]
    public class TestPermutationsWithDups
    {
        [TestCase("aab",3)]
        [TestCase("aabb", 6)]
        public void GetPermutationWithDups_WithInPutStringAAB_ShouldReturnListOf3(string anyString, int expectedCount)
        {
            P7andP8_Permutations permutations = new P7andP8_Permutations();

            List<string> actual = permutations.GetPermutationWithDups(anyString);

            Assert.AreEqual(expectedCount,actual.Count);
        }
    }
}
