using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HardProblemsProject
{
    public class P1_Recursive_CombinationsOfNDigitPhoneNumber
    {
        public List<string> GetNDigitPhoneNumbers(int n)
        {
            List<string> result = new List<string>();
            GetCombination("", result, 0, n);
            return result;
        }

        private void GetCombination(string prefix, List<string> result, int index, int numberOfDigits)
        {
            if (index == numberOfDigits)
            {
                result.Add(prefix);
                return;
            }
            else
            {
                for (int i = 0; i <= 9; i++)
                {
                    //if (index != 0 || i != 0)
                    {
                        string newprefix = prefix + i.ToString();
                        GetCombination(newprefix, result, index + 1, numberOfDigits);
                    }
                }
            }
        }
    }

    [TestFixture]
    public class TestCombinationsOfNDigitPhoneNumber
    {
        [Test]
        public void GetNDigitPhoneNumbers_WithNumberOfDigitsAs2_ShouldReturnListOf100Numbers()
        {
            int numberOfDigits = 2;
            int expectedCount = 100;
            P1_Recursive_CombinationsOfNDigitPhoneNumber combinationsOfNDigitPhoneNumber = new P1_Recursive_CombinationsOfNDigitPhoneNumber();

            List<string> actual = combinationsOfNDigitPhoneNumber.GetNDigitPhoneNumbers(numberOfDigits);

            Assert.AreEqual(expectedCount, actual.Count);
        }

        [Test]
        public void GetNDigitPhoneNumbers_WithNumberOfDigitsAs5_ShouldReturnListOf100000Numbers()
        {
            int numberOfDigits = 5;
            int expectedCount = 100000;
            P1_Recursive_CombinationsOfNDigitPhoneNumber combinationsOfNDigitPhoneNumber = new P1_Recursive_CombinationsOfNDigitPhoneNumber();

            List<string> actual = combinationsOfNDigitPhoneNumber.GetNDigitPhoneNumbers(numberOfDigits);

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}
