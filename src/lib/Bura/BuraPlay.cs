using System;
using System.Collections.Generic;

namespace CardGames.Lib.Bura
{
    public class BuraPlay
    {
        public IEnumerable<BuraCard> Defender
        {
            get;
            set;
        }

        public IEnumerable<BuraCard> Attacker
        {
            get;
            set;
        }
    }
}