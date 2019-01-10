using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonQuestions
{
    public class OddTimesOccurence
    {
        public int[] GetTwoNumbersHavingOddNumberOfOccurences(int[] integerArray)
        {
            HashSet<int> occurence = new HashSet<int>();

            foreach (int i in integerArray)
            {
                if (occurence.Contains(i))
                    occurence.Remove(i);
                else
                    occurence.Add(i);
            }

            if (occurence.Count == 2)
            {
                return new int[2]{occurence.ElementAt(0), occurence.ElementAt(1)};
            }

            else
            {
                throw new Exception("More than two numbers having odd number of occurence");
            }
        }
    }

    [TestFixture]
    public class TestOddTimesOccurence
    {
        [Test]
        public void GetTwoNumbersHavingOddNumberOfOccurences_With2numbersHavingOddNumberOfOccurence_ShouldReturnThoseTwoNumbers()
        {
            int[] integerArray = new int[]{1,1,1,1,2,2,3,4,4,5,5,6,6,6,6,7,7,7,8,8,9,9,9,9,9,9};
            int[] expected = new int[]{3,7};
            OddTimesOccurence oddTimesOccurence = new OddTimesOccurence();

            int[] actual = oddTimesOccurence.GetTwoNumbersHavingOddNumberOfOccurences(integerArray);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void GetTwoNumbersHavingOddNumberOfOccurences_With3numbersHavingOddNumberOfOccurence_ShouldThrowException()
        {
            int[] integerArray = new int[] { 1, 1, 1, 1, 2, 2, 3, 4, 4, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 9, 9, 9, 9, 9, 9 };
            string expectedError = "More than two numbers having odd number of occurence";
            OddTimesOccurence oddTimesOccurence = new OddTimesOccurence();

            var exception = Assert.Throws<Exception>(() => oddTimesOccurence.GetTwoNumbersHavingOddNumberOfOccurences(integerArray));

            exception.Message.Should().BeEquivalentTo(expectedError);
        }
    }
}
