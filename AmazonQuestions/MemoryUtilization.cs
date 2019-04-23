using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace AmazonQuestions
{
    public class MemoryUtilization
    {
        public int[][] GetListOfOptimalUtilizationOfPairOfApps(int capacity, int[][] foreApps, int[][] backApps)
        {
            int foreAppsLen = foreApps.Length;
            int backAppsLen = backApps.Length;

            int maxUtilization = 0;
            List<AppPair> appPairs = new List<AppPair>();

            for (int i = 0; i < foreAppsLen; i++)
            {
                for (int j = 0; j < backAppsLen; j++)
                {
                    int currMemory = foreApps[i][1] + backApps[j][1];
                    if (currMemory <= capacity)
                    {
                        appPairs.Add(new AppPair(new int[] { foreApps[i][0], backApps[j][0] }, currMemory));
                        if (currMemory > maxUtilization)
                            maxUtilization = currMemory;
                    }
                }
            }

            return appPairs.Where(x => x.memory == maxUtilization).Select(y => y.pair).ToArray();
        }
    }

    public class AppPair
    {
        public int[] pair;
        public int memory;

        public AppPair(int[] p, int m)
        {
            pair = p;
            memory = m;
        }
    }

    [TestFixture]
    public class TestMemoryUtilization
    {
        [Test]
        public void Test1_GetListOfOptimalUtilizationOfPairOfApps()
        {
            int[][] foreApps = new int[][] { new int[] { 1, 2 }, new int[] { 2, 4 }, new int[] { 3, 6 } };
            int[][] backApps = new int[][] { new int[] { 1, 2 } };
            int capacity = 7;

            int[][] expected = new int[][] { new int[] { 2, 1 } };
            MemoryUtilization mu = new MemoryUtilization();

            int[][] actual = mu.GetListOfOptimalUtilizationOfPairOfApps(capacity, foreApps, backApps);

            actual.Should().BeEquivalentTo(expected);
        }

        [Test]
        public void Test2_GetListOfOptimalUtilizationOfPairOfApps()
        {
            int[][] foreApps = new int[][] { new int[] { 1, 3 }, new int[] { 2, 5 }, new int[] { 3, 7 }, new int[] { 4, 10 } };
            int[][] backApps = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 }, new int[] { 3, 4 }, new int[] { 4, 5 } };
            int capacity = 10;

            int[][] expected = new int[][] { new int[] { 2, 4 }, new int[] { 3, 2 } };
            MemoryUtilization mu = new MemoryUtilization();

            int[][] actual = mu.GetListOfOptimalUtilizationOfPairOfApps(capacity, foreApps, backApps);

            actual.Should().BeEquivalentTo(expected);
        }

    }
}
