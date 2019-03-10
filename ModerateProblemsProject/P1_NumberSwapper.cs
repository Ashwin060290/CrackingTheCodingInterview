using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerateProblemsProject
{
    public class P1_NumberSwapper
    {
        public int[] SwapNumbersNotUsingTemp(int[] numbers)
        {
            numbers[0] = numbers[0] - numbers[1];
            numbers[1] = numbers[0] + numbers[1];
            numbers[0] = numbers[1] - numbers[0];

            return numbers;
        }

        public int[] SwapNumbersUsingXor(int[] numbers)
        {
            numbers[0] = numbers[0] ^ numbers[1];
            numbers[1] = numbers[0] ^ numbers[1];
            numbers[0] = numbers[0] ^ numbers[1];

            return numbers;
        }
    }

    [TestFixture]
    public class NumberSwapperTests
    {
        [TestCase(9,5)]
        [TestCase(2, 5)]
        [TestCase(5, 5)]
        [TestCase(10, 5)]
        [TestCase(9, 8)]
        public void SwapNumbersNotUsingTemp_WithTwoInputNumbers_ShouldReturnSwappedNubers(int a, int b)
        {
            int[] numbers = new int[] { a, b };
            int[] expected = new int[] { b, a };
            P1_NumberSwapper numberSwapper = new P1_NumberSwapper();

            int[] actual = numberSwapper.SwapNumbersNotUsingTemp(numbers);

            actual.Should().BeEquivalentTo(expected);
        }

        [TestCase(9, 5)]
        [TestCase(2, 5)]
        [TestCase(5, 5)]
        [TestCase(10, 5)]
        [TestCase(9, 8)]
        public void SwapNumbersUsingXor_WithTwoInputNumbers_ShouldReturnSwappedNubers(int a, int b)
        {
            int[] numbers = new int[] { a, b };
            int[] expected = new int[] { b, a };
            P1_NumberSwapper numberSwapper = new P1_NumberSwapper();

            int[] actual = numberSwapper.SwapNumbersNotUsingTemp(numbers);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
