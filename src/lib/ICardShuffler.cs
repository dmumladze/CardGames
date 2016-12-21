using System;
using System.Collections.Generic;

namespace CardGames.Lib
{
    public interface ICardShuffler<T> 
    {
        void Shuffle(CardCollection<T> cards);
    }
}