using System;

namespace CardGames.Lib
{
    public class Card : IComparable<Card>
    {
        public Card(CardSuit suit, CardName name)
        {
            Suit = suit;
            Name = name;
        }

        public CardSuit Suit
        {
            get;
            set;
        }

        public CardName Name
        {
            get;
            set;
        }        

        public int CompareTo(Card other)
        {
            var result = this.Suit.CompareTo(other.Suit);

            if (result == 0)
                result = this.Name.CompareTo(other.Name);
            
            return result;
        }       
    }
}