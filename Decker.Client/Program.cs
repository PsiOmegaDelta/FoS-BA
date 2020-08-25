using Decker.Client.Decks.FoS;
using Decker.Client.Extensions;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Decker.Client
{
    public static class Program
    {
        [Obsolete]
        public static void Main()
        {
            var firstCoup = new[] { Enumerable.Empty<ICard>(), new Card("Watergate", new Dictionary<string, string>()).ToEnumerable<ICard>() }.ToList();
            var secondCoup = new[] { Enumerable.Empty<ICard>(), new Card("Nixon Resigns", new Dictionary<string, string>()).ToEnumerable<ICard>() }.ToList();
            var thirdCoup = new[] { Enumerable.Empty<ICard>(), new Card("Saigon Stands Alone", new Dictionary<string, string>()).ToEnumerable<ICard>() }.ToList();

            var firstEra = new Year1973().Cards.Shuffle().Take(8).Batch(4).SelectMany((x, i) => x.Concat(firstCoup[i]).Shuffle());
            var secondEra = new Year1974().Cards.Shuffle().Take(8).Batch(4).SelectMany((x, i) => x.Concat(secondCoup[i]).Shuffle());
            var thirdEra = new Year1975().Cards.Shuffle().Take(8).Batch(4).SelectMany((x, i) => x.Concat(thirdCoup[i]).Shuffle());

            var arvnDeck = new BotARVN();
            var nvaDeck = new BotNVA();

            var eventCards = firstEra.Concat(secondEra).Concat(thirdEra).ToQueue();
            var botCards = arvnDeck.Cards.Concat(nvaDeck.Cards).Shuffle().ToQueue();
            var playedEventCards = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Played cards: " + (playedEventCards + 1));
                Console.WriteLine("Press: E for Event card - A for ARVN bot card - N for NVA bot card - S to shuffle bot cards");

                var eventCard = eventCards.Peek();
                Console.WriteLine("Current Event card: " + eventCard.Name + (eventCard.Traits.ContainsKey(Constants.Year) ? " (" + eventCard.Traits[Constants.Year] + ")" : string.Empty));

                var botCard = botCards.Peek();
                Console.WriteLine("Current Bot card: " + botCard.Name + " (" + botCard.Traits[Constants.Bot] + ")");
                switch (Console.ReadLine().ToUpper())
                {
                    case "A":
                        do
                        {
                            botCards.Enqueue(botCards.Dequeue()); // Puts the first card last, repeat until the top card is ARVN
                        } while (botCards.Peek().Traits[Constants.Bot] != Constants.ARVN);
                        break;

                    case "E":
                        playedEventCards++;
                        eventCards.Dequeue();
                        break;

                    case "N":
                        do
                        {
                            botCards.Enqueue(botCards.Dequeue()); // As for ARVN, but looking for NVA instead
                        } while (botCards.Peek().Traits[Constants.Bot] != Constants.NVA);
                        break;

                    case "S":
                        botCards = arvnDeck.Cards.Concat(nvaDeck.Cards).Shuffle().ToQueue();
                        break;
                }
            } while (eventCards.Count > 0);
        }
    }
}
