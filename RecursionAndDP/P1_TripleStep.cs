using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace RecursionAndDP
{
    public class P1_TripleStep
    {
        /* Triple Step: A child is running up a staircase with n steps and can hop either 1 step, 2 steps, or 3
            steps at a time. Implement a method to count how many possible ways the child can run up the
            stairs.  */

        public int CountSteps(int totalSteps)
        {
            if (totalSteps == 0)
                return 1;

            if (totalSteps < 0)
                return 0;

            return (CountSteps(totalSteps - 1) + CountSteps(totalSteps - 2) + CountSteps(totalSteps - 3));

        }
    }

    [TestFixture()]
    public class TestTripleSet
    {
        [Test]
        public void TripleSet_With2TotalSteps_ShouldRreturn2()
        {
            int totalSteps = 2;
            int expected = 2;
            P1_TripleStep tripleStep = new P1_TripleStep();

            int actual = tripleStep.CountSteps(totalSteps);

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void TripleSet_With3TotalSteps_ShouldRreturn4()
        {
            int totalSteps = 3;
            int expected = 4;
            P1_TripleStep tripleStep = new P1_TripleStep();

            int actual = tripleStep.CountSteps(totalSteps);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TripleSet_With4TotalSteps_ShouldRreturn7()
        {
            int totalSteps = 4;
            int expected = 7;
            P1_TripleStep tripleStep = new P1_TripleStep();

            int actual = tripleStep.CountSteps(totalSteps);

            Assert.AreEqual(expected, actual);
        }
    }
}
