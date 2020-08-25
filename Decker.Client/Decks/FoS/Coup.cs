using System.Collections.Generic;
using System.Collections.Immutable;

namespace Decker.Client.Decks.FoS
{
    public class Coup : IDeck
    {
        public IImmutableList<ICard> Cards { get; } = CoupCards().ToImmutableList();

        private static IEnumerable<ICard> CoupCards()
        {
            var noTraits = new Dictionary<string, string>();
            yield return new Card("Watergate", noTraits);
            yield return new Card("Nixon Resigns", noTraits);
            yield return new Card("Saigon Stands Alone", noTraits);
        }
    }
}
