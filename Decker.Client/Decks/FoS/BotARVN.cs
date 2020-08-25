using System.Collections.Generic;
using System.Collections.Immutable;

namespace Decker.Client.Decks.FoS
{
    public class BotARVN : IDeck
    {
        public IImmutableList<ICard> Cards { get; } = BotCards().ToImmutableList();

        private static IEnumerable<ICard> BotCards()
        {
            foreach (var letter in new[] { "G", "H", "J", "K", "L", "M" })
            {
                yield return new Card(letter, new Dictionary<string, string> { { Constants.Bot, Constants.ARVN } });
            }
        }
    }
}
