using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonQuestions
{
    public class TowerHopper
    {
        public int LeastHopsNeeded(int[] tower)
        {
            if (tower == null || tower.Length == 0 || tower[0] == 0)
                return -1;

            int hops = LeastHops(tower, 0, 0);
            return (hops == int.MaxValue) ? -1 : hops;
        }

        private int LeastHops(int[] tower, int current, int hops)
        {
            if (current >= tower.Length)
                return hops;

            if (tower[current] == 0)
                return int.MaxValue;

            int maxHopSize = tower[current];
            int min = int.MaxValue;

            for(int i = 1; i<= maxHopSize; i++)
            {
                int nextHops = LeastHops(tower, current + i, hops + 1);
                min = Math.Min(min, nextHops);
            }

            return min;
        }
    }

    [TestFixture]
    public class TestTowerHopper
    {
        [Test]
        public void TestTowerHops_WithValidTowers()
        {
            int[] towers = new int[] { 4,2,0,0,2,0};
            TowerHopper th = new TowerHopper();

            int hops = th.LeastHopsNeeded(towers);

            Assert.AreEqual(2, hops);
        }

        [Test]
        public void TestTowerHops_WithInValidTowers()
        {
            int[] towers = new int[] { 4, 2, 0, 0, 0, 0 };
            TowerHopper th = new TowerHopper();

            int hops = th.LeastHopsNeeded(towers);

            Assert.AreEqual(-1, hops);
        }
    }
}
