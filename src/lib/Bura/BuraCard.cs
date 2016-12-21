using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CardGames.Lib.Bura
{
    [DebuggerDisplay("{Suit}, {Name}, {Score}, {IsTrump}")]
    public class BuraCard : Card, IComparable<BuraCard>
    {
        private static Dictionary<CardName, int> scores;

        static BuraCard()
        {
            scores = new Dictionary<CardName, int>();
            scores.Add(CardName.Jack, 2);
            scores.Add(CardName.Queen, 3);  
            scores.Add(CardName.King, 4); 
            scores.Add(CardName.Ten, 10);                        
            scores.Add(CardName.Ace, 11);                                 
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

        public bool Trump
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
                result = this.Trump.CompareTo(other.Trump);

            return result;
        }   

        public bool CanBeat(BuraCard other)
        {
            if (this.Suit == other.Suit)
                return this.Name > other.Name;
            
            return this.Trump;            
        }         
    }
}