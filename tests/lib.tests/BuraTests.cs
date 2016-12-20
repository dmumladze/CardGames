using System;
using System.Collections.Generic;
using Xunit;
using CardGames.Lib;
using CardGames.Lib.Bura;

namespace Tests
{
    public class BuraTests
    {
        [Fact]
        public void One_Card_Greater_Than_Other() 
        {
            var king = new BuraCard(CardSuit.Clubs, CardName.King);
            king.IsTrump = true;
            var ace = new BuraCard(CardSuit.Spades, CardName.Seven);

            var result = king > ace;

            Assert.True(result);
        }

        [Fact]
        public void Deffender_Can_Beat_Attacker() 
        {
            var attacker = new List<BuraCard>();
            var deffender = new List<BuraCard>(); 

            attacker.Add(new BuraCard(CardSuit.Clubs, CardName.Seven));  
            attacker.Add(new BuraCard(CardSuit.Clubs, CardName.Queen)); 
            attacker.Add(new BuraCard(CardSuit.Clubs, CardName.Ace));                       
            attacker.Add(new BuraCard(CardSuit.Clubs, CardName.Ten));
            attacker.Add(new BuraCard(CardSuit.Clubs, CardName.Jack)); 
            attacker.Add(new BuraCard(CardSuit.Clubs, CardName.King)); 
            attacker.Add(new BuraCard(CardSuit.Clubs, CardName.Nine)); 
            attacker.Add(new BuraCard(CardSuit.Clubs, CardName.Eight));  

            attacker.Sort();          
        }        
    }
}
