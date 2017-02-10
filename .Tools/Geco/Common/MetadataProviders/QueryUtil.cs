using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Geco.Common.MetadataProviders
{
    public static class QueryUtil
    {
        public static IEnumerable<T> MaterializeReader<T>(DbDataReader reader)
            where T : new()
        {
            Func<DbDataReader, T> materialize = GetCachedMaterializeFunc<T>();
            while (reader.Read())
            {
                yield return materialize(reader);
            }
        }

        private static readonly ConcurrentDictionary<Type, Delegate> materializeFunctions = new ConcurrentDictionary<Type, Delegate>();
        private static Func<DbDataReader, T> GetCachedMaterializeFunc<T>()
        {
            return (Func<DbDataReader, T>)materializeFunctions.GetOrAdd(typeof(T), t =>
            {
                var r = Expression.Parameter(typeof(DbDataReader), "r");
                var lambda = Expression.Lambda(
                    Expression.MemberInit
                    (
                        Expression.New(t),
                        t.GetTypeInfo().GetProperties()
                        .Select(p => Expression.Bind(p, GetAssignmentExpression(p, r)))
                    ), EnumerableExtensions.Yield(r)
                );

                return (Func<DbDataReader, T>)lambda.Compile();
            });
        }

        private static Expression GetAssignmentExpression(PropertyInfo p, ParameterExpression r)
        {
            if (!p.CanWrite)
                throw new InvalidOperationException($"Property: {p.Name} of type:{p.DeclaringType.FullName} is not writable property!");


            return Expression.Call(ReadValueOrDefaultMethod.MakeGenericMethod(p.PropertyType), EnumerableExtensions.Yield<Expression>(r, Expression.Constant(p.Name)));
        }


        private static readonly MethodInfo ReadValueOrDefaultMethod = typeof(QueryUtil).GetTypeInfo().GetMethods(BindingFlags.NonPublic | BindingFlags.Static).First(m => m.Name == nameof(ReadValueOrDefault));
        private static T ReadValueOrDefault<T>(DbDataReader r, string name)
        {
            var index = r.GetOrdinal(name);
            return r.IsDBNull(index) ? default(T) : r.GetFieldValue<T>(index);
        }
    }
}