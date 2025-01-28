using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class IEnumerableExtensionMethods
    {
        public static T ElementAtOrDefault<T>(this IEnumerable<T> collection, int index, T defaultT)
        {
            T element = collection.ElementAtOrDefault(index);

            if (EqualityComparer<T>.Default.Equals(element))
                return defaultT;

            return element;
        }

        public static T FirstOrDefault<T>(this IEnumerable<T> collection, T defaultT)
        {
            T element = collection.FirstOrDefault();

            if (EqualityComparer<T>.Default.Equals(element))
                return defaultT;

            return element;
        }

        public static Types.Collections.Directional<T> ToDirectional<T>(this IEnumerable<T> collection)
        {
            return new
            (
                collection.ElementAt(0),
                collection.ElementAt(1),
                collection.ElementAt(2),
                collection.ElementAt(3),
                collection.ElementAt(4),
                collection.ElementAt(5),
                collection.ElementAt(6),
                collection.ElementAt(7)
            );
        }

        public static Types.Collections.EntropicList<T> ToEntropicList<T>(this IEnumerable<T> collection)
        {
            return new(collection);
        }
    }
}
