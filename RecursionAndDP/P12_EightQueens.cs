using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace RecursionAndDP
{
    /* Eight Queens: Write an algorithm to print all ways of arranging eight queens on an 8x8 chess board
        so that none of them share the same row, column, or diagonal. In this case, "diagonal" means all
        diagonals, not just the two that bisect the board.  */

    public class P12_EightQueens
    {
        public List<int[]> NQueenProblem(int numberOfQueens)
        {
            int[] columns = new int[numberOfQueens];
            int gridSize = numberOfQueens;
            List<int[]> results = new List<int[]>();

            PlaceQueens(0, columns, results, gridSize);

            return results;
        }

        private void PlaceQueens(int row, int[] columns, List<int[]> results, int gridSize)
        {
            if (row == gridSize)
            {
                int[] clone = new int[gridSize];
                columns.CopyTo(clone,0);
                results.Add(clone);
            }

            else
            {
                for (int col = 0; col < gridSize; col++)
                {
                    if (IsSafePlace(row, col, columns))
                    {
                        columns[row] = col;
                        PlaceQueens(row+1,columns, results, gridSize);
                    }
                }
            }
        }

        private bool IsSafePlace(int row, int col, int[] columns)
        {
            for (int row2 = 0; row2 < row; row2++)
            {
                int col2 = columns[row2];

                if (col == col2)
                    return false;

                int colDistance = Math.Abs(col - col2);
                int rowDistance = Math.Abs(row - row2);

                if (rowDistance == colDistance)
                    return false;
            }

            return true;
        }
    }

    [TestFixture]
    public class TestEightQueens
    {
        [TestCase(8, 92)]
        public void NQueenProblem_ForGivenNumberOfQueens_ShouldReturnListOfexpectedCount(int numberOfQueens,int expectedCount)
        {
            P12_EightQueens queens = new P12_EightQueens();

            List<int[]> actual = queens.NQueenProblem(numberOfQueens);

            Assert.AreEqual(expectedCount, actual.Count);
        }
    }
}
