using System;
using System.Collections.Generic;

namespace CardGames.Lib
{
    public interface IShuffler<T>
    {
        void Shuffle(IList<T> collection);
    }

    public class DeckShuffler<T> : IShuffler<T> where T : Card
    {
        public void Shuffle(IList<T> collection)
        {
        }
    }
}