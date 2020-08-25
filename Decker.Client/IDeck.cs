using System.Collections.Immutable;

namespace Decker.Client
{
    public interface IDeck
    {
        IImmutableList<ICard> Cards { get; }
    }
}
