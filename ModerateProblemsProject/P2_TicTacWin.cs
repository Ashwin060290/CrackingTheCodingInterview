using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModerateProblemsProject
{
    public class P2_TicTacWin
    {
        public Coin WhoWonTicTac(Coin[,] board)
        {
            if (board.GetLength(0) != board.GetLength(1))
                return Coin.none;

            Coin winningCoin = Coin.none;
            winningCoin = CheckDaigonal(board);

            if (winningCoin == Coin.none)
                winningCoin = CheckHorizontalLanes(board);

            if (winningCoin == Coin.none)
                winningCoin = CheckVerticalLanes(board);

            return winningCoin;
        }

        private Coin CheckDaigonal(Coin[,] board)
        {
            Coin daigonal1 = CheckDaigonal1(board);

            if (daigonal1 != Coin.none)
                return daigonal1;

            return CheckDaigonal2(board);
        }

        private Coin CheckHorizontalLanes(Coin[,] board)
        {
            for(int i = 0; i < board.GetLength(0); i++)
            {
                Coin horizontal = CheckHorizontalLane(board, i);

                if (horizontal != Coin.none)
                    return horizontal;
            }

            return Coin.none;
        }

        private Coin CheckVerticalLanes(Coin[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                Coin vertical = CheckVerticalLane(board, i);

                if (vertical != Coin.none)
                    return vertical;
            }

            return Coin.none;
        }

        private Coin CheckHorizontalLane(Coin[,] board, int row)
        {
            int max = board.GetLength(0);

            Coin start = board[row, 0];
            if (start == Coin.none)
                return Coin.none;

            for(int i = 1; i< max; i++)
            {
                if (board[row, i] != start)
                    return Coin.none;
            }

            return start;
        }

        private Coin CheckVerticalLane(Coin[,] board, int column)
        {
            int max = board.GetLength(0);

            Coin start = board[0, column];
            if (start == Coin.none)
                return Coin.none;

            for (int i = 1; i < max; i++)
            {
                if (board[i, column] != start)
                    return Coin.none;
            }

            return start;
        }

        private Coin CheckDaigonal1(Coin[,] board)
        {
            int max = board.GetLength(0);

            Coin start = board[0, 0];
            if (start == Coin.none)
                return Coin.none;

            for(int i = 1; i < max; i++)
            {
                if (board[i, i] != start)
                    return Coin.none;
            }

            return start;
        }

        private Coin CheckDaigonal2(Coin[,] board)
        {
            int max = board.GetLength(0);

            Coin start = board[0, max-1];
            if (start == Coin.none)
                return Coin.none;

            for (int i = 1; i < max; i++)
            {
                if (board[i, max - 1-i] != start)
                    return Coin.none;
            }

            return start;
        }
    }

    public enum Coin
    {
        none,
        red,
        blue
    }

    [TestFixture]
    public class TicTacWinTests
    {
        [Test]
        public void WhoWonTicTac_WithDiagonalWinnerRedCoin_ShouldReturnRedCoin()
        {
            P2_TicTacWin ticTacWin = new P2_TicTacWin();
            Coin[,] board = new Coin[,] { { Coin.red, Coin.blue, Coin.red, Coin.none},
                                          { Coin.blue, Coin.red, Coin.blue, Coin.none},
                                          { Coin.red, Coin.blue, Coin.red, Coin.none},
                                          { Coin.red, Coin.blue, Coin.red, Coin.red}};           

            Coin winner = ticTacWin.WhoWonTicTac(board);

            winner.Should().BeEquivalentTo(Coin.red);
        }

        [Test]
        public void WhoWonTicTac_WithDiagonalWinnerBlueCoin_ShouldReturnBlueCoin()
        {
            P2_TicTacWin ticTacWin = new P2_TicTacWin();
            Coin[,] board = new Coin[,] { { Coin.red, Coin.blue, Coin.red, Coin.blue},
                                          { Coin.blue, Coin.red, Coin.blue, Coin.none},
                                          { Coin.red, Coin.blue, Coin.blue, Coin.none},
                                          { Coin.blue, Coin.blue, Coin.red, Coin.red}};

            Coin winner = ticTacWin.WhoWonTicTac(board);

            winner.Should().BeEquivalentTo(Coin.blue);
        }

        [Test]
        public void WhoWonTicTac_WithHorizontalWinnerRedCoin_ShouldReturnRedCoin()
        {
            P2_TicTacWin ticTacWin = new P2_TicTacWin();
            Coin[,] board = new Coin[,] { { Coin.red, Coin.blue, Coin.red, Coin.blue},
                                          { Coin.blue, Coin.red, Coin.blue, Coin.none},
                                          { Coin.red, Coin.blue, Coin.blue, Coin.none},
                                          { Coin.red, Coin.red, Coin.red, Coin.red}};

            Coin winner = ticTacWin.WhoWonTicTac(board);

            winner.Should().BeEquivalentTo(Coin.red);
        }

        [Test]
        public void WhoWonTicTac_WithVerticalWinnerBlueCoin_ShouldReturnBlueCoin()
        {
            P2_TicTacWin ticTacWin = new P2_TicTacWin();
            Coin[,] board = new Coin[,] { { Coin.red, Coin.blue, Coin.red, Coin.blue},
                                          { Coin.blue, Coin.red, Coin.blue, Coin.blue},
                                          { Coin.red, Coin.blue, Coin.blue, Coin.blue},
                                          { Coin.red, Coin.red, Coin.red, Coin.blue}};

            Coin winner = ticTacWin.WhoWonTicTac(board);

            winner.Should().BeEquivalentTo(Coin.blue);
        }

        [Test]
        public void WhoWonTicTac_WithNoWinner_ShouldReturnNoneCoin()
        {
            P2_TicTacWin ticTacWin = new P2_TicTacWin();
            Coin[,] board = new Coin[,] { { Coin.red, Coin.blue, Coin.red, Coin.none},
                                          { Coin.blue, Coin.red, Coin.blue, Coin.none},
                                          { Coin.red, Coin.blue, Coin.blue, Coin.none},
                                          { Coin.red, Coin.red, Coin.none, Coin.none}};

            Coin winner = ticTacWin.WhoWonTicTac(board);

            winner.Should().BeEquivalentTo(Coin.none);
        }
    }
}
