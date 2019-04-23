using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonQuestions
{
    public class DeckOfCards
    {
        private Card[] _cards;
        private int _currentPointer;

        public DeckOfCards()
        {
            _cards = new Card[52];
            _currentPointer = 0;

            int c = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <= 13; j++)
                {
                    _cards[c] = new Card(i, j);
                    c += 1;
                }
            }
        }

        public void Shuffle()
        {
            Random r = new Random();
            for (int j = 0; j < 26; j++)
            {
                int c1 = r.Next(0, 52);
                int c2 = r.Next(0, 52);

                Card t = _cards[c1];
                _cards[c1] = _cards[c2];
                _cards[c2] = t;
            }

        }

        public string Deal(int n)
        {
            string a = "";
            for(int i = 0; i<n; i++)
            {
                Card c = _cards[_currentPointer];
                _currentPointer += 1;

                a += c.GetString() + "\n";
            }

            return a.Substring(0, a.Length - 2);
        }


    }

    public class Card
    {
        public Suit suit;
        public Rank rank;

        public Card(int s, int r)
        {
            suit = (Suit)s;
            rank = (Rank)r;
        }

        public string GetString()
        {
            return rank.ToString() + " of " + suit.ToString();
        }
    }

    public enum Suit
    {
        Spades = 0,
        Daimond = 1,
        Flower = 2,
        Hearts = 3
    }

    public enum Rank
    {
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13
    }

    [TestFixture]
    public class TestDeckOfCards
    {
        [Test]
        public void TestDeckOfCardClass()
        {
            DeckOfCards doc = new DeckOfCards();
            doc.Shuffle();

            string a = doc.Deal(52);
        }
    }
}
