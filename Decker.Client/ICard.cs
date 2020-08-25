using System.Collections.Immutable;

namespace Decker.Client
{
    public interface ICard
    {
        string Name { get; }

        IImmutableDictionary<string, string> Traits { get; }
    }
}
