using System.Collections.Generic;
using System.Collections.Immutable;

namespace Decker.Client
{
    public class Deck : IDeck
    {
        public Deck(IEnumerable<ICard> cards)
        {
            Cards = cards.ToImmutableList();
        }

        public IImmutableList<ICard> Cards { get; }
    }
}
