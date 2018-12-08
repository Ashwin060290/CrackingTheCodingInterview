using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace RecursionAndDP
{
    /* Towers of Hanoi: In the classic problem of the Towers of Hanoi, you have 3 towers and N disks of
        different sizes which can slide onto any tower. The puzzle starts with disks sorted in ascending order
        of size from top to bottom (i.e., each disk sits on top of an even larger one). You have the following
        constraints:
        (1) Only one disk can be moved at a time.
        (2) A disk is slid off the top of one tower onto another tower.
        (3) A disk cannot be placed on top of a smaller disk.
        Write a program to move the disks from the first tower to the last using stacks.  */

    public class P6_TowerOfHanoi
    {
        public Stack<int> MoveToAnotherTower(Stack<int> tower1)
        {
            Stack<int> buffer = new Stack<int>();
            Stack<int> destination = new Stack<int>();
            MoveDisks(tower1.Count ,tower1, destination, buffer);

            return destination;
        }

        private void MoveDisks(int n ,Stack<int> source, Stack<int> destination, Stack<int> buffer)
        {
            if (n <= 0)
                return;

            MoveDisks(n-1, source, buffer, destination);
            destination.Push(source.Pop());
            MoveDisks(n-1,buffer,destination,source);
        }
    }

    [TestFixture]
    public class TestTowerOfHanoi
    {
        public Stack<int> GetTowerOfSize(int n)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = n - 1; i >= 0; i--)
            {
                stack.Push(i);
            }

            return stack;
        }

        [Test]
        public void MoveToAnotherTower_WithTowerOfSize5_ShouldReturnNewEquivalentTower()
        {
            int size = 5;
            Stack<int> sourceTower = GetTowerOfSize(size);
            Stack<int> expectedTower = GetTowerOfSize(size);
            P6_TowerOfHanoi towerOfHanoi = new P6_TowerOfHanoi();

            Stack<int> destinationTower = towerOfHanoi.MoveToAnotherTower(sourceTower);

            destinationTower.Should().BeEquivalentTo(expectedTower);
        }

        [Test]
        public void MoveToAnotherTower_WithTowerOfSize3_ShouldReturnNewEquivalentTower()
        {
            int size = 3;
            Stack<int> sourceTower = GetTowerOfSize(size);
            Stack<int> expectedTower = GetTowerOfSize(size);
            P6_TowerOfHanoi towerOfHanoi = new P6_TowerOfHanoi();

            Stack<int> destinationTower = towerOfHanoi.MoveToAnotherTower(sourceTower);

            destinationTower.Should().BeEquivalentTo(expectedTower);
        }
    }
}
