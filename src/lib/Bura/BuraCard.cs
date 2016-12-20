using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CardGames.Lib.Bura
{
    [DebuggerDisplay("{Suit}, {Name}, {Score}")]
    public class BuraCard : Card, IComparable<BuraCard>
    {
        private static Dictionary<CardName, int> scores;

        static BuraCard()
        {
            scores = new Dictionary<CardName, int>();
            scores.Add(CardName.Ace, 11);
            scores.Add(CardName.King, 4);
            scores.Add(CardName.Queen, 3);
            scores.Add(CardName.Jack, 2);
            scores.Add(CardName.Ten, 10);
        }

        public BuraCard(CardSuit suit, CardName name)
            : base(suit, name)
        {
            int score;
            scores.TryGetValue(name, out score);
            Score = score;
        }  

        public int Score
        {
            get;
            set;
        }

        public bool IsTrump
        {
            get;
            set;
        }

        public int CompareTo(BuraCard other)
        {
            var result = base.CompareTo(other);

            if (result == 0)
                result = this.Score.CompareTo(other.Score);

            if (result == 0)
                result = this.IsTrump.CompareTo(other.IsTrump);

            return result;
        }

        public static bool operator >(BuraCard a, BuraCard b)
        {
            if (a.Suit == b.Suit)
                return a.Name > b.Name;
            
            if (a.IsTrump)
                return true;

            return false;
        }   

        public static bool operator <(BuraCard a, BuraCard b)
        {
            if (a.Suit == b.Suit)
                return a.Name < b.Name;
            
            if (b.IsTrump)
                return true;

            return false;
        }             
    }
}