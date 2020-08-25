using System.Collections.Generic;
using System.Collections.Immutable;

namespace Decker.Client
{
    public class Card : ICard
    {
        public Card(string name, IDictionary<string, string> traits)
        {
            Name = name;
            Traits = traits.ToImmutableDictionary();
        }

        public string Name { get; }

        public IImmutableDictionary<string, string> Traits { get; }
    }
}
