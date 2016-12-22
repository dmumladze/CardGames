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
            this.AttackerCard = attackCard;
            this.DefenderCard = defendCard;
        }

        public T AttackerCard 
        {
            get;
            set;
        }

        public T DefenderCard 
        {
            get;
            set;
        }

        public bool Completed
        {
            get;
            set;
        }
    }
}