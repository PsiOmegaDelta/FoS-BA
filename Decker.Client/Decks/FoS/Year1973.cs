using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Decker.Client.Decks.FoS
{
    public class Year1973 : IDeck
    {
        public IImmutableList<ICard> Cards { get; } = YearCards().ToImmutableList();

        private static IEnumerable<ICard> YearCards()
        {
            foreach (var cardNumber in Enumerable.Range(1, 24))
            {
                yield return new Card($"S{cardNumber}", new Dictionary<string, string> { { Constants.Year, "1973" } });
            }
        }
    }
}
