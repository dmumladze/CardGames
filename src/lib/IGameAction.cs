using System;

namespace CardGames.Lib
{
    public interface IGameAction<TState>
    {
        void Apply(TState gameState);
        bool IsLegal(TState gameState);        
    }
}