using System.Collections.Generic;

namespace Decker.Client.Extensions
{
    public static class EnumerablExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>(this T input)
        {
            yield return input;
        }

        public static Queue<T> ToQueue<T>(this IEnumerable<T> source)
        {
            return new Queue<T>(source);
        }

        public static Stack<T> ToStack<T>(this IEnumerable<T> source)
        {
            return new Stack<T>(source);
        }
    }
}
