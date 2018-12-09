using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace RecursionAndDP
{
    public class P10_PaintFill
    {
        /* Paint Fill: Implement the "paint fill" function that one might see on many image editing programs.
            That is, given a screen (represented by a two-dimensional array of colors), a point, and a new color,
            fill in the surrounding area until the color changes from the original color. */

        public int[,] Fill(int[,] picture, int row, int column, int newColor)
        {
            int originalColor = picture[row, column];
            FillColor(picture, row, column, originalColor, newColor);
            return picture;
        }

        private void FillColor(int[,] picture, int row, int column, int originalColor, int newColor)
        {
            if (row < 0 || row >= picture.GetLength(0) || column < 0 || column >= picture.GetLength(1) || picture[row, column] != originalColor)
                return;

            picture[row, column] = newColor;

            FillColor(picture, row + 1, column, originalColor, newColor);
            FillColor(picture, row - 1, column, originalColor, newColor);
            FillColor(picture, row, column + 1, originalColor, newColor);
            FillColor(picture, row, column - 1, originalColor, newColor);
        }
    }

    [TestFixture]
    public class TestPaintFill
    {
        [Test]
        public void Fill_With5By5Picture_ShouldReturn5By5PictureWithoriginalColorReplacedWithNewColor()
        {
            int[,] picture = new int[,]
            {
                {1,1,1,1,1},
                {3,1,1,1,1},
                {3,1,3,3,1},
                {3,3,3,3,3},
                {1,1,1,1,1},
            };

            int[,] expected = new int[,]
            {
                {1,1,1,1,1},
                {2,1,1,1,1},
                {2,1,2,2,1},
                {2,2,2,2,2},
                {1,1,1,1,1},
            };
            P10_PaintFill paintFill = new P10_PaintFill();

            int[,] actual = paintFill.Fill(picture, 1, 0, 2);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void Fill_With6By6Picture_ShouldReturn6By6PictureWithoriginalColorReplacedWithNewColor()
        {
            int[,] picture = new int[,]
            {
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {3,3,3,3,3,3},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1}
            };

            int[,] expected = new int[,]
            {
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {1,1,1,1,1,1},
                {3,3,3,3,3,3},
                {2,2,2,2,2,2},
                {2,2,2,2,2,2}
            };
            P10_PaintFill paintFill = new P10_PaintFill();

            int[,] actual = paintFill.Fill(picture, 4, 3, 2);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
