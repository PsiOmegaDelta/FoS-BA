using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Decker.Client.Decks.FoS
{
    public class Year1974 : IDeck
    {
        public IImmutableList<ICard> Cards { get; } = YearCards().ToImmutableList();

        private static IEnumerable<ICard> YearCards()
        {
            foreach (var cardNumber in Enumerable.Range(25, 48 - 25 + 1))
            {
                yield return new Card($"S{cardNumber}", new Dictionary<string, string> { { Constants.Year, "1974" } });
            }
        }
    }
}
