using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonQuestions
{
    public class Hiphen
    {
        private Trie _trie;

        public bool WordBreak(string s, IList<string> wordDict)
        {
            _trie = new Trie();

            foreach (string word in wordDict)
            {
                _trie.AddWord(word);
            }

            return _trie.CheckCanPlaceHiphen(s);
        }
    }

    public class Trie
    {
        public TrieNode _head;

        public Trie()
        {
            _head = new TrieNode();
        }

        public void AddWord(string word)
        {
            TrieNode root = _head;

            foreach (char c in word)
            {
                if (!root.children.ContainsKey(c))
                {
                    root.children.Add(c, new TrieNode());
                }

                root = root.children[c];
            }

            root.isWord = true;
        }

        public bool CheckCanPlaceHiphen(string words)
        {
            TrieNode root = _head;
            bool ans = false;

            foreach (char c in words)
            {
                if (!root.children.ContainsKey(c)) 
                return false;

                root = root.children[c];
                ans = root.isWord;

                if (root.isWord)
                    root = _head;
            }

            return ans;
        }
    }

    public class TrieNode
    {
        public Dictionary<char, TrieNode> children;
        public bool isWord;

        public TrieNode()
        {
            isWord = false;
            children = new Dictionary<char, TrieNode>();
        }
    }

    [TestFixture]
    public class TestHiphen
    {
        [Test]
        public void TestHiphenWithExample()
        {
            string s = "aaaaaaa";
            string[] wordDict = { "aaaa", "aaa" };

            Hiphen h = new Hiphen();
            h.WordBreak(s, wordDict);
        }
    }
}
