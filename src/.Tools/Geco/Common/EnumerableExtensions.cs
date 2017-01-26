using System;
using System.Linq;
using System.Collections.Generic;

namespace Geco.Common
{
    /// <summary>
    /// Extensions class with enumerable extensions targeted at code generation
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Yields a single value
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static IEnumerable<T> Yield<T>(T instance)
        {
            yield return instance;
        }

        /// <summary>
        /// Yields two values
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
        /// Yields tree values
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
        /// Returns a wrapped enumerable that contains info for each enumerated item, like index in original source
        /// </summary>
        /// <typeparam name="T">the type of elements in sequence</typeparam>
        /// <param name="source">the source</param>
        /// <returns>wrapped enumerable sequence</returns>
        public static IEnumerable<ItemInfo<T>> WithInfo<T>(this IEnumerable<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return WithInfoIterator(source);
        }

        /// <summary>
        /// Recreates the info for an enumerable sequence
        /// </summary>
        /// <typeparam name="T">the type of elements in sequence</typeparam>
        /// <param name="source">the source</param>
        /// <returns>wrapped enumerable sequence</returns>
        public static IEnumerable<ItemInfo<T>> WithInfo<T>(this IEnumerable<ItemInfo<T>> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            return WithInfoIterator(source.Select(s => s.Item));
        }

        private static IEnumerable<ItemInfo<T>> WithInfoIterator<T>(IEnumerable<T> source)
        {
            using (var enumerator = source.GetEnumerator())
            {
                int index = 0;
                if (!enumerator.MoveNext())
                    yield break;

                T current = enumerator.Current;

                if (enumerator.MoveNext())
                {
                    yield return new ItemInfo<T>(true, false, index++, current);
                    current = enumerator.Current;
                }
                else
                {
                    yield return new ItemInfo<T>(true, true, index++, current);
                    yield break;
                }


                while (enumerator.MoveNext())
                {
                    var next = enumerator.Current;
                    yield return new ItemInfo<T>(false, false, index++, current);
                    current = next;
                }
                yield return new ItemInfo<T>(false, true, index++, current);
            }
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