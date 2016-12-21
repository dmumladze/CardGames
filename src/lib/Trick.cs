using System;

namespace CardGames.Lib
{
    public class Trick<T>
    {
        public Trick()
        {            
        }  

        public Trick(T attackCard, T defendCard)      
        {
            this.AttackCard = attackCard;
            this.DefendCard = defendCard;
        }

        public T AttackCard 
        {
            get;
            set;
        }

        public T DefendCard 
        {
            get;
            set;
        }

        public bool Beaten
        {
            get;
            set;
        }
    }
}