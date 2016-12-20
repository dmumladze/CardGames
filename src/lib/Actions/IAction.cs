using System;

namespace CardGames.Lib.Actions
{
    public interface IAction<T>
    {
        bool IsLegal(T gameState);
        void Apply(T gameState);
    }
}