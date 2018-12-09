using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecursionAndDP
{
    /* Parens: Implement an algorithm to print all valid (i.e., properly opened and closed) combinations
        of n pairs of parentheses.
        EXAMPLE
        Input: 3
        Output: (( () ) ) , ( () () ) , ( () ) () , () ( () ) , () () ()  */

    public class P9_Parens
    {
        public List<string> ValidPairsOfParanthesis(int pairCount)
        {
            if (pairCount <= 0)
                return null;

            return parens(pairCount);
        }

        private List<string> parens(int count)
        {
            List<string> set = new List<string>();

            if (count == 0)
            {
                set.Add("");
                return set;
            }

            List<string> prevSet = parens(count - 1);
            foreach (string s in prevSet)
            {
                for(int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '(')
                    {
                        string newString = InsertParensAt(s,i+1);
                        
                        if(!set.Contains(newString))
                            set.Add(newString);
                    }
                }

                string s2 = "()" + s;
                if(!set.Contains(s2))
                    set.Add(s2);
            }

            return set;
        }

        private string InsertParensAt(string str, int index)
        {
            return (str.Substring(0, index) + "()" + str.Substring(index, str.Length - index));
        }

        public List<string> ValidPairsOfParanthesisOptimized(int pairCount)
        {
            if (pairCount <= 0)
                return null;

            List<string> result = new List<string>();
            char[] str = new char[pairCount*2];

            ParensOptimized(result,pairCount,pairCount,str,0);

            return result;
        }

        private void ParensOptimized(List<string> result, int openParem, int closedParem, char[] str, int index)
        {
            if (openParem < 0 || closedParem < openParem)
                return;

            if (openParem == 0 && closedParem == 0)
            {
                result.Add(str.ToString());
            }

            else
            {
                str[index] = '(';
                ParensOptimized(result, openParem - 1, closedParem, str, index + 1);

                str[index] = ')';
                ParensOptimized(result, openParem, closedParem - 1, str, index + 1);
            }
        }
    }

    [TestFixture]
    public class TestParensNotOptimized
    {
        [TestCase(2, 2)]
        [TestCase(3, 5)]
        public void ValidPairsOfParanthesis_WithGivenCount_ShouldReturnListOfStringOfExpectedCount(int givenParenCount,int expectedCount)
        {
            P9_Parens parens = new P9_Parens();

            List<string> actual = parens.ValidPairsOfParanthesis(givenParenCount);

            Assert.AreEqual(expectedCount,actual.Count);
        }
    }

    [TestFixture]
    public class TestParensOptimized
    {
        [TestCase(2, 2)]
        [TestCase(3, 5)]
        public void ValidPairsOfParanthesisOptimized_WithGivenCount_ShouldReturnListOfStringOfExpectedCount(int givenParenCount, int expectedCount)
        {
            P9_Parens parens = new P9_Parens();

            List<string> actual = parens.ValidPairsOfParanthesisOptimized(givenParenCount);

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}
