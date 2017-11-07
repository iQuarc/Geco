using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Geco.Common.SimpleMetadata;

namespace Geco.Common.MetadataProviders
{
    public static class QueryUtil
    {
        public static IEnumerable<T> MaterializeReader<T>(DbDataReader reader)
            where T : IMetadataItem, new()
        {
            Func<DbDataReader, T> materialize = GetCachedMaterializeFunc<T>();
            while (reader.Read())
            {
                yield return materialize(reader);
            }
        }

        private static readonly ConcurrentDictionary<Type, Delegate> MaterializeFunctions = new ConcurrentDictionary<Type, Delegate>();
        private static Func<DbDataReader, T> GetCachedMaterializeFunc<T>()
            where T:IMetadataItem
        {
            return (Func<DbDataReader, T>)MaterializeFunctions.GetOrAdd(typeof(T), t =>
            {
                var r = Expression.Parameter(typeof(DbDataReader), "r");
                var exceptProperties = new HashSet<string>(t.GetProperties().Select(p => p.Name).Where(p => nameof(IMetadataItem.Metadata) != p));
                var lambda = Expression.Lambda(
                    Expression.Call(typeof(QueryUtil).GetMethod(nameof(AddMetadata), BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(t),
                        Expression.MemberInit
                        (
                            Expression.New(t),
                            t.GetTypeInfo().GetProperties()
                            .Where(p => nameof(IMetadataItem.Metadata) != p.Name)
                            .Where(p => p.CanWrite)
                            .Select(p => Expression.Bind(p, GetAssignmentExpression(r, p)))
                        ), r, Expression.Constant(exceptProperties)), EnumerableExtensions.Yield(r)
                );

                return (Func<DbDataReader, T>)lambda.Compile();
            });
        }

        private static Expression GetAssignmentExpression(ParameterExpression r, PropertyInfo p)
        {
            if (!p.CanWrite)
                throw new InvalidOperationException($"Property: {p.Name} of type:{p.DeclaringType.FullName} is not writable property!");

            return Expression.Call(ReadValueOrDefaultMethod.MakeGenericMethod(p.PropertyType), EnumerableExtensions.Yield<Expression>(r, Expression.Constant(p.Name)));
        }

        private static T AddMetadata<T>(T item, DbDataReader r, HashSet<string> exceptProperties)
            where T : IMetadataItem
        {
            for (int i = 0; i < r.FieldCount; i++)
            {
                var fieldName = r.GetName(i);
                if (exceptProperties.Contains(fieldName))
                    continue;
                item.Metadata.Add(fieldName, r.GetValue(i).ToString());
            }
            return item;
        }


        private static readonly MethodInfo ReadValueOrDefaultMethod = typeof(QueryUtil).GetTypeInfo().GetMethods(BindingFlags.NonPublic | BindingFlags.Static).First(m => m.Name == nameof(ReadValueOrDefault));
        private static T ReadValueOrDefault<T>(DbDataReader r, string name)
        {
            var index = r.GetOrdinal(name);
            return r.IsDBNull(index) ? default(T) : r.GetFieldValue<T>(index);
        }
    }
}