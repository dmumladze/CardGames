using System;
using Xunit;
using CardGames.Lib;
using CardGames.Lib.Bura;

namespace Tests
{
    public class BuraTests
    {
        [Fact]
        public void Trump_CanBeat_Non_Trump() 
        {
            var six = new BuraCard(CardSuit.Clubs, CardName.Six);            
            var ace = new BuraCard(CardSuit.Spades, CardName.Ace);

            six.Trump = true;
            var result = six.CanBeat(ace);

            Assert.True(result);
        }

        [Fact]
        public void DefenderCards_Can_Beat_AttackerCards_Without_Trump() 
        {
            var attackerCards = new CardCollection<BuraCard>();
            var defenderCards = new CardCollection<BuraCard>(); 

            attackerCards.Add(new BuraCard(CardSuit.Clubs, CardName.Seven));  
            attackerCards.Add(new BuraCard(CardSuit.Clubs, CardName.Queen));                     
            attackerCards.Add(new BuraCard(CardSuit.Clubs, CardName.Eight));  

            defenderCards.Add(new BuraCard(CardSuit.Clubs, CardName.Ace));                       
            defenderCards.Add(new BuraCard(CardSuit.Clubs, CardName.Ten));
            defenderCards.Add(new BuraCard(CardSuit.Clubs, CardName.Nine)); 

            var strategy = new BuraDefenseStrategy();

            var tricks = strategy.Execute(attackerCards, defenderCards);

            foreach (var trick in tricks)              
            {
                Assert.True(trick.Completed);
            }
        }  

        [Fact]
        public void DefenderCards_Can_Beat_AttackerCards_With_Trump() 
        {
            var attackerCards = new CardCollection<BuraCard>();
            var defenderCards = new CardCollection<BuraCard>(); 

            attackerCards.Add(new BuraCard(CardSuit.Clubs, CardName.Seven));  
            attackerCards.Add(new BuraCard(CardSuit.Clubs, CardName.Queen));                     
            attackerCards.Add(new BuraCard(CardSuit.Clubs, CardName.Eight));  

            defenderCards.Add(new BuraCard(CardSuit.Hearts, CardName.Six));
            defenderCards[0].Trump = true;                       
            defenderCards.Add(new BuraCard(CardSuit.Clubs, CardName.Ten));
            defenderCards.Add(new BuraCard(CardSuit.Clubs, CardName.Nine)); 

            var strategy = new BuraDefenseStrategy();

            var tricks = strategy.Execute(attackerCards, defenderCards);

            foreach (var trick in tricks)              
            {
                Assert.True(trick.Completed);
            }
        }              
    }
}
