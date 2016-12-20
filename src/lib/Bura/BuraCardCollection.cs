using System;
using  System.Collections.Generic;

namespace CardGames.Lib.Bura
{
    public class BuraCardCollection : List<BuraCard>
    {
        public BuraCardCollection()
        {
            Add(new BuraCard(CardSuit.Hearts, CardName.Ace));
            Add(new BuraCard(CardSuit.Hearts, CardName.King));
            Add(new BuraCard(CardSuit.Hearts, CardName.Queen));
            Add(new BuraCard(CardSuit.Hearts, CardName.Jack));
            Add(new BuraCard(CardSuit.Hearts, CardName.Ten));
            Add(new BuraCard(CardSuit.Hearts, CardName.Nine));
            Add(new BuraCard(CardSuit.Hearts, CardName.Eight));
            Add(new BuraCard(CardSuit.Hearts, CardName.Seven));
            Add(new BuraCard(CardSuit.Hearts, CardName.Six));

            Add(new BuraCard(CardSuit.Spades, CardName.Ace));
            Add(new BuraCard(CardSuit.Spades, CardName.King));
            Add(new BuraCard(CardSuit.Spades, CardName.Queen));
            Add(new BuraCard(CardSuit.Spades, CardName.Jack));
            Add(new BuraCard(CardSuit.Spades, CardName.Ten));
            Add(new BuraCard(CardSuit.Spades, CardName.Nine));
            Add(new BuraCard(CardSuit.Spades, CardName.Eight));
            Add(new BuraCard(CardSuit.Spades, CardName.Seven));
            Add(new BuraCard(CardSuit.Spades, CardName.Six));  

            Add(new BuraCard(CardSuit.Diamonds, CardName.Ace));
            Add(new BuraCard(CardSuit.Diamonds, CardName.King));
            Add(new BuraCard(CardSuit.Diamonds, CardName.Queen));
            Add(new BuraCard(CardSuit.Diamonds, CardName.Jack));
            Add(new BuraCard(CardSuit.Diamonds, CardName.Ten));
            Add(new BuraCard(CardSuit.Diamonds, CardName.Nine));
            Add(new BuraCard(CardSuit.Diamonds, CardName.Eight));
            Add(new BuraCard(CardSuit.Diamonds, CardName.Seven));
            Add(new BuraCard(CardSuit.Diamonds, CardName.Six));   

            Add(new BuraCard(CardSuit.Clubs, CardName.Ace));
            Add(new BuraCard(CardSuit.Clubs, CardName.King));
            Add(new BuraCard(CardSuit.Clubs, CardName.Queen));
            Add(new BuraCard(CardSuit.Clubs, CardName.Jack));
            Add(new BuraCard(CardSuit.Clubs, CardName.Ten));
            Add(new BuraCard(CardSuit.Clubs, CardName.Nine));
            Add(new BuraCard(CardSuit.Clubs, CardName.Eight));
            Add(new BuraCard(CardSuit.Clubs, CardName.Seven));
            Add(new BuraCard(CardSuit.Clubs, CardName.Six));                               
        }
    }
}