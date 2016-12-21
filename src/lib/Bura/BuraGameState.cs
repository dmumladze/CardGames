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
        private CardCollection<BuraCard> _deck;
        private ICardShuffler<BuraCard> _shuffler; 
        private IDefenseStrategy<BuraCard> _defenseStrategy;       

        public BuraGameState()
        {
            _gameId = Guid.NewGuid();
            _playersNeeded = 2;   
            _players = new PlayerCollection();
            _playerPicks = new Dictionary<Player, Card>(); 
            _deck = new CardCollection<BuraCard>();  
            _shuffler = new CardShuffler<BuraCard>(); 
            _defenseStrategy = new BuraDefenseStrategy();  

            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.Ace));
            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.King));
            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.Queen));
            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.Jack));
            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.Ten));
            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.Nine));
            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.Eight));
            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.Seven));
            _deck.Add(new BuraCard(CardSuit.Hearts, CardName.Six));

            _deck.Add(new BuraCard(CardSuit.Spades, CardName.Ace));
            _deck.Add(new BuraCard(CardSuit.Spades, CardName.King));
            _deck.Add(new BuraCard(CardSuit.Spades, CardName.Queen));
            _deck.Add(new BuraCard(CardSuit.Spades, CardName.Jack));
            _deck.Add(new BuraCard(CardSuit.Spades, CardName.Ten));
            _deck.Add(new BuraCard(CardSuit.Spades, CardName.Nine));
            _deck.Add(new BuraCard(CardSuit.Spades, CardName.Eight));
            _deck.Add(new BuraCard(CardSuit.Spades, CardName.Seven));
            _deck.Add(new BuraCard(CardSuit.Spades, CardName.Six));  

            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.Ace));
            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.King));
            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.Queen));
            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.Jack));
            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.Ten));
            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.Nine));
            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.Eight));
            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.Seven));
            _deck.Add(new BuraCard(CardSuit.Diamonds, CardName.Six));   

            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.Ace));
            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.King));
            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.Queen));
            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.Jack));
            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.Ten));
            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.Nine));
            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.Eight));
            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.Seven));
            _deck.Add(new BuraCard(CardSuit.Clubs, CardName.Six));                                              
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

        public CardCollection<BuraCard> Deck
        {
            get { return _deck; }
        }

        public ICardShuffler<BuraCard> Shuffler
        {
            get { return _shuffler; }
        }

        public IDefenseStrategy<BuraCard> DefenseStrategy
        {
            get { return _defenseStrategy; }
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }        
    }
}