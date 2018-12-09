using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecursionAndDP
{
    /*  Boolean Evaluation: Given a boolean expression consisting of the symbols 0 (false), 1 (true), &
        (AND), I (OR), and /\ (XOR), and a desired boolean result value result, implement a function to
        count the number of ways of parenthesizing the expression such that it evaluates to result.
        EXAMPLE
        countEval("l /\01011", false) -> 2
        countEval("0&0&0&1/\ll0", true) -> 10  */

    public class P14_BooleanEvaluation
    {
        public int CountEval(string stringToEavaluate, bool expectedresult)
        {
            if (stringToEavaluate.Length == 0) return 0;
            if (stringToEavaluate.Length == 1)
            {
                bool value = stringToEavaluate == "1";

                if (value == expectedresult)
                    return 1;
                else
                    return 0;

            }

            int ways = 0;
            for (int i = 1; i < stringToEavaluate.Length; i += 2)
            {
                char c = stringToEavaluate[i];

                string left = stringToEavaluate.Substring(0, i);
                string right = stringToEavaluate.Substring(i + 1, stringToEavaluate.Length - i - 1);

                int leftTrue = CountEval(left, true);
                int leftFalse = CountEval(left, false);

                int rightTrue = CountEval(right, true);
                int rightFalse = CountEval(right, false);

                int total = (leftTrue + leftFalse) * (rightTrue + rightFalse);

                int totalTrue = 0;

                if (c == '&')
                {
                    totalTrue = leftTrue * rightTrue;
                }

                if (c == '|')
                {
                    totalTrue = (leftTrue * rightTrue) + (leftTrue * rightFalse) + (leftFalse * rightTrue);
                }

                if (c == '^')
                {
                    totalTrue = (leftTrue * rightFalse) + (leftFalse * rightTrue);
                }

                if (expectedresult)
                {
                    ways += totalTrue;
                }
                else
                {
                    ways += (total - totalTrue);
                }
            }
            return ways;
        }
    }

    [TestFixture]
    public class TestBooleanEvaluation
    {
        [Test]
        public void CountEval_WithGivenExpressionForTrueEvaluation_ShouldReturn10()
        {
            string eval = "0&0&0&1^1|0";
            int expected = 10;

            P14_BooleanEvaluation booleanEvaluation = new P14_BooleanEvaluation();

            int actual = booleanEvaluation.CountEval(eval, true);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountEval_WithGivenExpressionForFalseEvaluation_ShouldReturn2()
        {
            string eval = "1^0|0|1";
            int expected = 2;

            P14_BooleanEvaluation booleanEvaluation = new P14_BooleanEvaluation();

            int actual = booleanEvaluation.CountEval(eval, false);

            Assert.AreEqual(expected, actual);
        }
    }
}
