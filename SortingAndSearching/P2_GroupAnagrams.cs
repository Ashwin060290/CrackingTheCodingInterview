using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    /* Group Anagrams: Write a method to sort an array of strings so that all the anagrams are next to
        each other. */

    public class P2_GroupAnagrams
    {
        public List<string> GetGroupAnagrams(List<string> wordList)
        {
            Dictionary<string, List<string>> anagramDictionary = new Dictionary<string, List<string>>();

            foreach (string word in wordList)
            {
                string sortedWord = String.Concat(word.OrderBy(c => c));

                if (anagramDictionary.ContainsKey(sortedWord))
                {
                    anagramDictionary[sortedWord].Add(word);
                }
                else
                {
                    anagramDictionary.Add(sortedWord, new List<string>() { word });
                }
            }

            List<string> anagramList = new List<string>();
            foreach (KeyValuePair<string, List<string>> pair in anagramDictionary)
            {
                foreach (string word in pair.Value)
                {
                    anagramList.Add(word);
                }
            }

            return anagramList;
        }
    }

    [TestFixture]
    public class TestGroupAnagrams
    {
        [Test]
        public void GetGroupAnagrams_WithListOfWords_ShouldReturnAnagramList()
        {
            List<string> wordList = new List<string>() { "race", "pat", "acre", "tap", "care", "apt" };
            List<string> expected = new List<string>() { "race", "acre", "care", "pat", "tap", "apt" };
            P2_GroupAnagrams groupAnagrams = new P2_GroupAnagrams();

            List<string> actual = groupAnagrams.GetGroupAnagrams(wordList);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
