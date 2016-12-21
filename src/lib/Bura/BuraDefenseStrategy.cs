using System;
using System.Collections.Generic;

namespace CardGames.Lib.Bura
{
    public class BuraDefenseStrategy : IDefenseStrategy<BuraCard>
    {
        public List<Trick<BuraCard>> Execute(CardCollection<BuraCard> attackerCards, CardCollection<BuraCard> defenderCards)
        {            
            attackerCards.Sort((a, b) => { return a.CompareTo(b) * -1; });
            defenderCards.Sort(); 
            
            var visitedCards = new HashSet<BuraCard>();
            var tricks = this.Defend(attackerCards, defenderCards, visitedCards);             

            if (tricks.Count != defenderCards.Count)
            {
                var attackersLeft = new List<BuraCard>();
                var defendersLeft = new List<BuraCard>();

                for (var i = 0; i < attackerCards.Count; i++)       
                { 
                    if (!visitedCards.Contains(attackerCards[i]))        
                        attackersLeft.Add(attackerCards[i]);
                }

                for (var i = 0; i < defenderCards.Count; i++)       
                { 
                    if (!visitedCards.Contains(defenderCards[i]))        
                        defendersLeft.Add(defenderCards[i]);
                } 

                for (var i = 0; i < attackersLeft.Count; i++)
                     tricks.Add(new Trick<BuraCard>(attackersLeft[i], defendersLeft[i]));                             
            }
                        
            return tricks;  
        }  

        private List<Trick<BuraCard>> Defend(CardCollection<BuraCard> attackCards, CardCollection<BuraCard> defendCards, HashSet<BuraCard> visitedCards)
        {
            var tricks = new List<Trick<BuraCard>>();
            
            foreach (var attackCard in attackCards)
            {   
                var trick = new Trick<BuraCard>();                
                
                foreach (var defendCard in defendCards)
                { 
                    if (visitedCards.Contains(defendCard))
                        continue;
                                                            
                    if (defendCard.CanBeat(attackCard))
                    { 
                        trick.AttackCard = attackCard;
                        trick.DefendCard = defendCard;   
                        trick.Beaten = true;  

                        tricks.Add(trick);

                        visitedCards.Add(attackCard);
                        visitedCards.Add(defendCard); 
                                                                                                                    
                        break;                       
                    }                    
                }
                
                if (!trick.Beaten) break;
            }

            return tricks;
        }
    }
}