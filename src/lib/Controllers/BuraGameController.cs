using System;
using System.Collections.Concurrent;
using CardGames.Lib.Bura;

namespace CardGames.Lib.Controllers
{
    public class BuraGameController
    {
        private ConcurrentDictionary<Guid, BuraGameState> _gameCache;

        public BuraGameController()
        {
            _gameCache = new ConcurrentDictionary<Guid, BuraGameState>();
        }

        public void Create(CreateRequest request)
        {
            // if (!_gameCache.TryGetValue(request.GameId, out BuraGameState state))
            // {
            //     state = new BuraGameState();
            //     _gameCache.TryAdd(state.GameId, state);
            // }
        }

        public void Join(JoinRequest request)
        {

        }
    }  

    public class JoinRequest
    {
        public int PlayerId { get; set; }
        public Guid GameId { get; set; }
    } 

    public class CreateRequest 
    {
        public int PlayerId { get; set; }     
        public Guid GameId { get; set; } 
    }     
}