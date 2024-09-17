using System.Collections.Generic;
using System.Linq;

namespace System
{
    public static class LinqExtensions
    {
        public static T ElementWithMin<T>(this IEnumerable<T> source, Func<T, float> selector)
        {
            if (source == null || !source.Any())
            {
                throw new ArgumentException("The source collection is null or empty.");
            }

            float min = float.MaxValue;
            T element = default;

            foreach (T item in source)
            {
                float value = selector(item);
                if (value < min)
                {
                    min = value;
                    element = item;
                }
            }

            return element;
        }

        public static T ElementWithMax<T>(this IEnumerable<T> source, Func<T, float> selector)
        {
            if (source == null || !source.Any())
            {
                throw new ArgumentException("The source collection is null or empty.");
            }

            float max = float.MinValue;
            T element = default;

            foreach (T item in source)
            {
                float value = selector(item);
                if (value > max)
                {
                    max = value;
                    element = item;
                }
            }

            return element;
        }

        public static bool ExistIn<T>(this T element, IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            return source.Contains(element);
        }

        public static T RAdd<T>(this ICollection<T> list, T element)
        {
            list.Add(element);
            return element;
        }

        public static T Random<T>(this ICollection<T> collection)
        {
            return collection.Count < 1 ? default : collection.ElementAt(UnityEngine.Random.Range(0, collection.Count));
        }

        public static T Random<T>(this IEnumerable<T> enumerable)
        {
            int count = enumerable.Count();
            int rnd = UnityEngine.Random.Range(0, count);
            return enumerable.ElementAt(rnd);
        }

        public static void AddDistributeProportionally<T>(this ICollection<T> collection, int totalValue, Func<T, int> funcProportion, Action<T, int> actAddingValue)
        {
            int sum = collection.Sum(funcProportion);
            int count = collection.Count;
            int counter = 1;
            int tempValue = totalValue;
            foreach (T t in collection)
            {
                int v = (int)(totalValue / (float)sum * funcProportion(t));
                actAddingValue(t, counter < count ? v : tempValue);
                tempValue = -v;
                counter++;
            }
        }
    }
}
