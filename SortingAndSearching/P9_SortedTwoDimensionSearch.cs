using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAndSearching
{
    public class P9_SortedTwoDimensionSearch
    {
        public int[] FindX(int[,] matrix, int numberToFind, int upperLeftX, int upperLeftY, int bottomRightX, int bottomRightY)
        {
            if (upperLeftX == bottomRightX && upperLeftY == bottomRightY)
            {
                if (matrix[upperLeftX, bottomRightY] == numberToFind)
                    return new int[2] { upperLeftX, bottomRightY };
                else
                    return null;
            }

            if (NumberInFirstQuadrant(matrix, numberToFind, upperLeftX, upperLeftY, bottomRightX, bottomRightY))
            {
                int x = (upperLeftX + bottomRightX) / 2;
                int y = (upperLeftY + bottomRightY) / 2;
                return FindX(matrix, numberToFind, upperLeftX, upperLeftY, x, y);
            }

            if (NumberInFourthQuadrant(matrix, numberToFind, upperLeftX, upperLeftY, bottomRightX, bottomRightY))
            {
                int x = (upperLeftX + bottomRightX) / 2;
                int y = (upperLeftY + bottomRightY) / 2;
                return FindX(matrix, numberToFind, x + 1, y + 1, bottomRightX, bottomRightY);
            }

            int x1 = (upperLeftX + bottomRightX) / 2;
            int y1 = (upperLeftY + bottomRightY) / 2;

            int[] secondQuadrant = null, thirdQuadrant = null;

            if (!CheckArrayOutOfBound(matrix, x1, y1 + 1))
                secondQuadrant = FindX(matrix, numberToFind, upperLeftX, y1 + 1, x1, bottomRightY);

            if (!CheckArrayOutOfBound(matrix, x1 + 1, y1))
                thirdQuadrant = FindX(matrix, numberToFind, x1 + 1, upperLeftY, bottomRightX, y1);


            if (secondQuadrant != null)
                return secondQuadrant;

            if (thirdQuadrant != null)
                return thirdQuadrant;

            return null;
        }

        private bool NumberInFirstQuadrant(int[,] matrix, int numberToFind, int upperLeftX, int upperLeftY, int bottomRightX, int bottomRightY)
        {
            int x = (upperLeftX + bottomRightX) / 2;
            int y = (upperLeftY + bottomRightY) / 2;

            if (matrix[x, y] >= numberToFind)
                return true;
            else
                return false;
        }

        private bool NumberInFourthQuadrant(int[,] matrix, int numberToFind, int upperLeftX, int upperLeftY, int bottomRightX, int bottomRightY)
        {
            int x = (upperLeftX + bottomRightX) / 2;
            int y = (upperLeftY + bottomRightY) / 2;

            if (CheckArrayOutOfBound(matrix, x + 1, y + 1))
                return false;

            if (matrix[x + 1, y + 1] <= numberToFind)
                return true;
            else
                return false;
        }

        private bool CheckArrayOutOfBound(int[,] matrix, int x, int y)
        {
            if (x >= matrix.GetLength(0) || y >= matrix.GetLength(1))
                return true;

            return false;
        }
    }

    [TestFixture]
    public class SortedTwoDimensionSearchTests
    {
        [Test]
        public void FindX_Matrix3by2HavingNumber_ReturnsCorrectXAndY()
        {
            int[,] matrix = new int[,] { { 15, 20, 70 }, { 20, 35, 80 }, { 30, 55, 95 }, { 40, 80, 100 } };
            int[] expected = new int[] { 3, 2 };
            P9_SortedTwoDimensionSearch sortedTwoDimensionSearch = new P9_SortedTwoDimensionSearch();

            int[] actual = sortedTwoDimensionSearch.FindX(matrix, 100, 0, 0, 3, 2);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void FindX_Matrix4by4HavingNumber_ReturnsCorrectXAndY()
        {
            int[,] matrix = new int[,] { { 15, 20, 70, 85 }, { 20, 35, 80, 95 }, { 30, 55, 95, 105 }, { 40, 80, 100, 120 } };
            int[] expected = new int[] { 0,3 };
            P9_SortedTwoDimensionSearch sortedTwoDimensionSearch = new P9_SortedTwoDimensionSearch();

            int[] actual = sortedTwoDimensionSearch.FindX(matrix, 85, 0, 0, 3, 3);

            expected.Should().BeEquivalentTo(actual);
        }

        [Test]
        public void FindX_Matrix4by4NotHavingNumber_ReturnsNull()
        {
            int[,] matrix = new int[,] { { 15, 20, 70, 85 }, { 20, 35, 80, 95 }, { 30, 55, 95, 105 }, { 40, 80, 100, 120 } };
            P9_SortedTwoDimensionSearch sortedTwoDimensionSearch = new P9_SortedTwoDimensionSearch();

            int[] actual = sortedTwoDimensionSearch.FindX(matrix, 86, 0, 0, 3, 3);

            Assert.IsNull(actual);
        }

        public void FindX_Matrix3by2NotHavingNumber_ShouldReturnNull()
        {
            int[,] matrix = new int[,] { { 15, 20, 70 }, { 20, 35, 80 }, { 30, 55, 95 }, { 40, 80, 100 } };
            P9_SortedTwoDimensionSearch sortedTwoDimensionSearch = new P9_SortedTwoDimensionSearch();

            int[] actual = sortedTwoDimensionSearch.FindX(matrix, 85, 0, 0, 3, 2);

            Assert.IsNull(actual);
        }
    }
}
