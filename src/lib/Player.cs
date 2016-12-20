using System;

namespace CardGames.Lib
{
    public class Player
    {
        public int PlayerId 
        { 
            get; 
            set; 
        }

        public string Name 
        { 
            get; 
            set; 
        }

        public int TurnNo
        {
            get;
            set;
        }

        public override int GetHashCode()
        {
            return PlayerId;
        }
    }
}