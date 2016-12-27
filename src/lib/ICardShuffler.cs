using System;

namespace CardGames.Lib
{
    public interface ICardShuffler<T> 
    {
        void Shuffle(CardCollection<T> cards);
    }
}