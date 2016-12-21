using System;

namespace CardGames.Lib.Bura
{
    public class JoinBuraAction : IGameAction<BuraGameState>
    {
        private Player _player;

        public JoinBuraAction(Player player)
        {
            _player = player;
        }

        public bool IsLegal(BuraGameState game)
        {
            return game.PlayersNeeded < 2 && !game.Players.Contains(_player);
        }

        public void Apply(BuraGameState game)
        {
            game.Players.Add(_player);
            game.PlayersNeeded--;
        }
    }
}