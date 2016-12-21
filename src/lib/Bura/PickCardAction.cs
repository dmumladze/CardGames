using System;

namespace CardGames.Lib.Bura
{
    public class PickCardAction : IGameAction<BuraGameState>
    {
        private Player _player;
        private Card _pick;

        public PickCardAction(Player player, Card pick)
        {
            _player = player;
            _pick = pick;
        }

        public bool IsLegal(BuraGameState game)
        {
            return !game.PlayerPicks.ContainsKey(_player);
        }

        public void Apply(BuraGameState game)
        {
            game.PlayerPicks.Add(_player, _pick);
        }
    }
}