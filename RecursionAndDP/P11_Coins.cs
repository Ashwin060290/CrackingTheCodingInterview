using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecursionAndDP
{
    public class P11_Coins
    {
        public int WaysToMakeChange(int cents)
        {
            int[] denoms = new int[]{25,10,5,1};
            return MakeChange(cents, denoms, 0);
        }

        private int MakeChange(int amount, int[] denoms, int index)
        {
            if (index >= denoms.Length - 1)
                return 1;

            int denomAmount = denoms[index];
            int ways = 0;
            for (int i = 0; (i * denomAmount) <= amount; i++)
            {
                int amountRemaining = amount - (i * denomAmount);
                ways += MakeChange(amountRemaining, denoms, index + 1);
            }
            return ways;
        }

    }

    [TestFixture]
    public class TestCoins
    {
        [TestCase(2, 1)]
        [TestCase(5,2)]
        [TestCase(10, 4)]
        [TestCase(25, 13)]
        public void WaysToMakeChange_WithGivenNumberOfCents_ShouldReturnExpectedNumberOfWays(int cents,int expectedNumberOfWays)
        {
            P11_Coins coins = new P11_Coins();

            int actualNumberOfWays = coins.WaysToMakeChange(cents);

            Assert.AreEqual(expectedNumberOfWays,actualNumberOfWays);
        }
    }
}
