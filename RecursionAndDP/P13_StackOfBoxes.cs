using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecursionAndDP
{
    /* Stack of Boxes: You have a stack of n boxes, with widths wi, heights hi, and depths di. The boxes
        cannot be rotated and can only be stacked on top of one another if each box in the stack is strictly
        larger than the box above it in width, height, and depth. Implement a method to compute the
        height of the tallest possible stack. The height of a stack is the sum of the heights of each box. */

    public class P13_StackOfBoxes
    {
        public int GetMaxHeight(List<Box> stackOfBoxes)
        {
            List<Box> sortedBoxes = stackOfBoxes.OrderByDescending(x => x.height).ToList();
            int maxHeight = 0;

            for(int i = 0; i< sortedBoxes.Count; i++)
            {
                int height = StackBoxes(sortedBoxes, i);
                maxHeight = Math.Max(maxHeight, height);
            }

            return maxHeight;
        }

        private int StackBoxes(List<Box> sortedBoxes, int index)
        {
            Box bottom = sortedBoxes[index];
            int maxHeight = 0;
            for (int i = index + 1; i < sortedBoxes.Count; i++)
            {
                if (sortedBoxes[i].CanBePlacedOver(bottom))
                {
                    int height = StackBoxes(sortedBoxes, i);
                    maxHeight = Math.Max(height, maxHeight);
                }
            }
            maxHeight += bottom.height;
            return maxHeight;
        }
    }

    public class Box
    {
        public int height;
        public int width;
        public int length;

        public Box(int h, int w, int l)
        {
            height = h;
            width = w;
            length = l;
        }

        public bool CanBePlacedOver(Box bottom)
        {
            if (height < bottom.height && width < bottom.width && length < bottom.length)
                return true;

            return false;
        }
    }

    [TestFixture]
    public class TestStackOfBoxes
    {
        [Test]
        public void GetMaxHeight_WithSquareOfSize1and2and3_ShouldReturnMaxHeightAs6()
        {
            List<Box> boxes = new List<Box>(){new Box(1,1,1), new Box(3,3,3), new Box(2,2,2)};
            int expected = 6;
            P13_StackOfBoxes stackOfBoxes = new P13_StackOfBoxes();

            int actual = stackOfBoxes.GetMaxHeight(boxes);

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void GetMaxHeight_WithSquareOfSize1and1and3_ShouldReturnMaxHeightAs4()
        {
            List<Box> boxes = new List<Box>() { new Box(1, 1, 1), new Box(3, 3, 3), new Box(1, 1, 1) };
            int expected = 4;
            P13_StackOfBoxes stackOfBoxes = new P13_StackOfBoxes();

            int actual = stackOfBoxes.GetMaxHeight(boxes);

            Assert.AreEqual(expected, actual);
        }
    }
}
