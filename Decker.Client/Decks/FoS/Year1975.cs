using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Decker.Client.Decks.FoS
{
    public class Year1975 : IDeck
    {
        public IImmutableList<ICard> Cards { get; } = YearCards().ToImmutableList();

        private static IEnumerable<ICard> YearCards()
        {
            foreach (var cardNumber in Enumerable.Range(49, 72 - 49 + 1))
            {
                yield return new Card($"S{cardNumber}", new Dictionary<string, string> { { Constants.Year, "1975" } });
            }
        }
    }
}
