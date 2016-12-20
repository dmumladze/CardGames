using System;
using CardGames.Lib.Actions;

namespace CardGames.Lib.Bura
{
    public class PlayCardAction : IAction<BuraGameState>
    {
        private Player _player;

        public PlayCardAction(Player player)
        {
            _player = player;
        }

        public void Apply(BuraGameState game)
        {

        }

        public bool IsLegal(BuraGameState game)
        {
            return true;
        }
    }
}