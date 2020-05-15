using System;
using System.Collections.Generic;
using System.Linq;

namespace Geco.Common
{
    /// <summary>
    ///     Extensions class with enumerable extensions targeted at code generation
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Yields a single value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static IEnumerable<T> Yield<T>(T instance)
        {
            yield return instance;
        }

        /// <summary>
        ///     Yields two values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance1"></param>
        /// <param name="instance2"></param>
        /// <returns></returns>
        public static IEnumerable<T> Yield<T>(T instance1, T instance2)
        {
            yield return instance1;
            yield return instance2;
        }

        /// <summary>
        ///     Yields tree values
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance1"></param>
        /// <param name="instance2"></param>
        /// <param name="instance3"></param>
        /// <returns></returns>
        public static IEnumerable<T> Yield<T>(T instance1, T instance2, T instance3)
        {
            yield return instance1;
            yield return instance2;
            yield return instance3;
        }

        /// <summary>
        ///     Batches the source enumerable into a sequence of enumerable each containing
        ///     <para>size</para>
        ///     elements
        /// </summary>
        /// <typeparam name="T">Element Type</typeparam>
        /// <param name="source">The source <see cref="IEnumerable{T}" /></param>
        /// <param name="count">Size of the batch indicating the number of elements in each batch</param>
        /// <returns></returns>
        public static IEnumerable<IEnumerable<T>> Batch<T>(this IEnumerable<T> source, int count)
        {
            if (count < 1) throw new ArgumentOutOfRangeException(nameof(count));
            var enumerator = source.GetEnumerator();

            IEnumerable<T> BatchCounter(int curentCount)
            {
                do
                {
                    yield return enumerator.Current;
                } while (--curentCount > 0 && enumerator.MoveNext());
            }

            while (enumerator.MoveNext()) yield return BatchCounter(count);
        }

        /// <summary>
        ///     Returns a wrapped enumerable that contains info for each enumerated item,
        ///     like the index in original source, and whether it's first or last element in the original source
        /// </summary>
        /// <typeparam name="T">the type of elements in sequence</typeparam>
        /// <param name="source">the source</param>
        /// <returns>wrapped enumerable sequence</returns>
        public static IEnumerable<ItemInfo<T>> WithInfo<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            IEnumerable<ItemInfo<T>> WithInfoIterator()
            {
                using (var enumerator = source.GetEnumerator())
                {
                    var index = 0;
                    if (!enumerator.MoveNext())
                        yield break;

                    var current = enumerator.Current;

                    if (enumerator.MoveNext())
                    {
                        yield return new ItemInfo<T>(true, false, index++, current);
                        current = enumerator.Current;
                    }
                    else
                    {
                        yield return new ItemInfo<T>(true, true, index, current);
                        yield break;
                    }


                    while (enumerator.MoveNext())
                    {
                        var next = enumerator.Current;
                        yield return new ItemInfo<T>(false, false, index++, current);
                        current = next;
                    }

                    yield return new ItemInfo<T>(false, true, index, current);
                }
            }

            return WithInfoIterator();
        }

        /// <summary>
        ///     Recreates the info for an enumerable sequence
        /// </summary>
        /// <typeparam name="T">the type of elements in sequence</typeparam>
        /// <param name="source">the source</param>
        /// <returns>wrapped enumerable sequence</returns>
        public static IEnumerable<ItemInfo<T>> WithInfo<T>(this IEnumerable<ItemInfo<T>> source)
        {
            return WithInfo(source.Select(s => s.Item));
        }
    }

    public struct ItemInfo<T>
    {
        [Flags]
        private enum Info
        {
            None = 0,
            IsFirst,
            IsLast
        }

        internal ItemInfo(bool first, bool last, int index, T item)
        {
            info = (first ? Info.IsFirst : 0) | (last ? Info.IsLast : 0);
            Index = index;
            Item = item;
        }

        private readonly Info info;
        public bool IsFirst => info.HasFlag(Info.IsFirst);
        public bool IsLast => info.HasFlag(Info.IsLast);

        public readonly int Index;
        public readonly T Item;
    }
}