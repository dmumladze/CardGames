using System;
using System.Collections.Generic;

namespace CardGames.Lib.Bura
{
    public class BuraGameState
    {
        private Guid _gameId;
        private int _playersNeeded;
        private PlayerCollection _players;        
        private Dictionary<Player, Card> _playerPicks;
        private BuraCardCollection _deck;
        private IShuffler<BuraCard> _shuffler;        

        public BuraGameState()
        {
            _gameId = Guid.NewGuid();
            _playersNeeded = 2;   
            _players = new PlayerCollection();
            _playerPicks = new Dictionary<Player, Card>(); 
            _deck = new BuraCardCollection();  
            _shuffler = new DeckShuffler<BuraCard>();                                 
        }

        public Guid GameId
        {
            get { return _gameId; }
        }

        public int PlayersNeeded
        {
            get { return _playersNeeded; }
            set { _playersNeeded = value; }
        }        

        public PlayerCollection Players
        {
            get { return _players; }
        }

        public Dictionary<Player, Card> PlayerPicks
        {
            get { return _playerPicks; }
        }

        public Player NextPlayer
        {
            get;
            set;
        }

        public BuraCardCollection Deck
        {
            get { return _deck; }
        }

        public IShuffler<BuraCard> Shuffler
        {
            get { return _shuffler; }
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }        
    }
}