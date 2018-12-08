using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace RecursionAndDP
{
    public class P2_RobotInAGrid
    {
        /* Robot in a Grid: Imagine a robot sitting on the upper left corner of grid with r rows and c columns.
            The robot can only move in two directions, right and down, but certain cells are "off limits" such that
            the robot cannot step on them. Design an algorithm to find a path for the robot from the top left to
            the bottom right.  */
        public List<Point> GetPath(bool[,] maze)
        {
            if (maze == null || maze.Length <= 0)
                return null;

            List<Point> path = new List<Point>();

            bool pathPresent = GetPath(maze, maze.GetLength(0) - 1, maze.GetLength(1) - 1, ref path);

            if (pathPresent)
                return path;
            else
                return null;
        }

        private bool GetPath(bool[,] maze, int currentRow, int currentColumn,ref List<Point> path)
        {
            if (currentColumn < 0 || currentRow < 0 || !maze[currentRow, currentColumn])
            {
                return false;
            }

            bool reachedDestination = (currentRow == 0) && (currentColumn == 0);

            if (reachedDestination || GetPath(maze, currentRow - 1, currentColumn,ref path) ||
                GetPath(maze, currentRow, currentColumn - 1,ref path))
            {
                path.Add(new Point(currentRow,currentColumn));
                return true;
            }

            return false;
        }

        public List<Point> GetPathMyWay(bool[,] maze, int currentRow, int currentColumn, List<Point> path)
        {
            if (path == null)
                return null;

            if (currentColumn < 0 || currentRow < 0 || !maze[currentRow, currentColumn])
                return null;

            if (currentColumn == 0 && currentRow == 0)
            {
                path.Add(new Point(currentRow,currentColumn));
                return path;
            }

            List<Point> leftPath = GetPathMyWay(maze, currentRow, currentColumn - 1, path);
            List<Point> upPath = GetPathMyWay(maze, currentRow - 1, currentColumn, path);

            if (leftPath == null && upPath != null)
            {
                upPath.Add(new Point(currentRow,currentColumn));
                return upPath;
            }

            else if (leftPath != null && upPath == null)
            {
                leftPath.Add(new Point(currentRow,currentColumn));
                return leftPath;
            }

            else if (leftPath != null && upPath != null)
            {
                leftPath.Add(new Point(currentRow, currentColumn));
                return leftPath;
            }

            else
                return null;


        }
    }

    public class Point
    {
        public int Row;
        public int Column;


        public Point(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }

    [TestFixture]
    public class TestRobotInAGrid
    {
        [Test]
        public void GetPath_WithNullMaze_ShouldReturnNull()
        {
            bool[,] maze = null;
            P2_RobotInAGrid robotInAGrid = new P2_RobotInAGrid();

            List<Point> actual = robotInAGrid.GetPath(null);

            Assert.IsNull(actual);
        }

        [Test]
        public void GetPath_WithOpen3by3Maze_ShouldReturnListOf5Point()
        {
            bool[,] maze = new bool[,]
            {
                {true, true, true},
                {true, true, true},
                {true, true, true}
            };
            P2_RobotInAGrid robotInAGrid = new P2_RobotInAGrid();

            List<Point> actual = robotInAGrid.GetPath(maze);

            Assert.AreEqual(5, actual.Count);
        }

        [Test]
        public void GetPath_With3by3MazeHavingBlockedPlaces_ShouldReturnListOf5Point()
        {
            bool[,] maze = new bool[,]
            {
                {true, true, false},
                {true, true, true},
                {true, true, true}
            };
            P2_RobotInAGrid robotInAGrid = new P2_RobotInAGrid();

            List<Point> actual = robotInAGrid.GetPath(maze);

            Assert.AreEqual(5, actual.Count);
        }

        [Test]
        public void GetPath_With3by3MazeHavingBlockedPlaces_ShouldReturnNull()
        {
            bool[,] maze = new bool[,]
            {
                {true, true, false},
                {true, false, true},
                {false, true, true}
            };
            P2_RobotInAGrid robotInAGrid = new P2_RobotInAGrid();

            List<Point> actual = robotInAGrid.GetPath(maze);

            Assert.IsNull(actual);
        }
        
        [Test]
        public void GetPath_With2by5MazeHavingBlockedPlaces_ShouldReturnListOf6Point()
        {
            bool[,] maze = new bool[,]
            {
                {true, true, true, true, true},
                {true, false, true, true, true},
            };
            P2_RobotInAGrid robotInAGrid = new P2_RobotInAGrid();

            List<Point> actual = robotInAGrid.GetPath(maze);

            Assert.AreEqual(6, actual.Count);
        }

        [Test]
        public void GetPath_With7by2MazeHavingBlockedPlaces_ShouldReturnListOf8Point()
        {
            bool[,] maze = new bool[,]
            {
                {true, true },
                {false,true },
                {true, true },
                {true, true },
                {true, true },
                {true, true },
                {true, true }
            };
            P2_RobotInAGrid robotInAGrid = new P2_RobotInAGrid();

            List<Point> actual = robotInAGrid.GetPath(maze);

            Assert.AreEqual(8, actual.Count);
        }

    }
}
