using System;
using System.Collections;
using System.Collections.Generic;

namespace CardGames.Lib
{
    public class PlayerCollection : ICollection<Player>
    {
        private List<Player> _players;
        private int _next;

        public PlayerCollection()
        {
            _players = new List<Player>();
        }

        public PlayerCollection(IEnumerable<Player> players)
        {
            _players.AddRange(players);
            this.ApplyChange();
        }

        public virtual Player NextPlayer()
        {
            if (_players.Count == 0)
                return null;

            var next = _players[_next++];

            if (_next > _players.Count)
                _next = 0;

            return next;
        }

        public virtual void Sort()
        {
            _players.Sort((Player x, Player y) => { return x.TurnNo.CompareTo(y.TurnNo); } );
        }

        protected virtual void ApplyChange()
        {
            if (_players.Count > 1)
                this.Sort();        
        }

        public void Add(Player player)
        {
            _players.Add(player); 
            this.ApplyChange();           
        }

        public virtual void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Player player)
        {
            foreach (var item in _players)
            {
                if (item.PlayerId == player.PlayerId)
                    return true;
            }            
            return false;
        }

        public virtual bool Remove(Player player)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Player[] array, int arrayIndex)
        {
            _players.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Player> GetEnumerator()
        {
            return _players.GetEnumerator();
        }

        public int NextTurn
        {
            get { return _next; }
            protected set { _next = value; }
        }

        public int Count
        {
            get { return _players.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _players.GetEnumerator();
        }
    }
}