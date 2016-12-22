using System;
using System.Collections.Generic;

namespace CardGames.Lib
{
    public interface IDefenseStrategy<T> 
    {
        List<Trick<T>> Execute(CardCollection<T> deffenderCards, CardCollection<T> attackerCards);
    }
}