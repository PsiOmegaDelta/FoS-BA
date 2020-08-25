using System.Collections.Generic;
using System.Collections.Immutable;

namespace Decker.Client.Decks.FoS
{
    public class BotNVA : IDeck
    {
        public IImmutableList<ICard> Cards { get; } = BotCards().ToImmutableList();

        private static IEnumerable<ICard> BotCards()
        {
            foreach (var letter in new[] { "N", "P", "Q", "R", "S", "T" })
            {
                yield return new Card(letter, new Dictionary<string, string> { { Constants.Bot, Constants.NVA } });
            }
        }
    }
}
