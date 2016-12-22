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

            if (tricks.Count == defenderCards.Count)
                return  tricks;

            var attackersLeft = new List<BuraCard>();
            var defendersLeft = new List<BuraCard>();

            foreach (var card in attackerCards)       
            { 
                if (!visitedCards.Contains(card))        
                    attackersLeft.Add(card);
            }

            foreach (var card in defenderCards)       
            { 
                if (!visitedCards.Contains(card))        
                    defendersLeft.Add(card);
            } 

            for (var i = 0; i < attackersLeft.Count; i++)
                tricks.Add(new Trick<BuraCard>(attackersLeft[i], defendersLeft[i]));                                         
                        
            return tricks;  
        }  

        private List<Trick<BuraCard>> Defend(CardCollection<BuraCard> attackerCards, CardCollection<BuraCard> defenderCards, HashSet<BuraCard> visitedCards)
        {
            var tricks = new List<Trick<BuraCard>>();
            
            foreach (var attackerCard in attackerCards)
            {   
                var trick = new Trick<BuraCard>();                
                
                foreach (var defenderCard in defenderCards)
                { 
                    if (visitedCards.Contains(defenderCard))
                        continue;
                                                            
                    if (defenderCard.CanBeat(attackerCard))
                    { 
                        trick.AttackerCard = attackerCard;
                        trick.DefenderCard = defenderCard;   
                        trick.Completed = true;  

                        tricks.Add(trick);

                        visitedCards.Add(attackerCard);
                        visitedCards.Add(defenderCard); 
                                                                                                                    
                        break;                       
                    }                    
                }
                
                if (!trick.Completed) break;
            }

            return tricks;
        }
    }
}