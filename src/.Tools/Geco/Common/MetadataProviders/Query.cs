using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Geco.Common.MetadataProviders
{
    public static class QueryUtil
    {
        public static IEnumerable<T> MaterializeReader<T>(IDataReader reader)
            where T : new()
        {
            Func<IDataReader, T> materialize = GetCachedMaterializeFunc<T>();
            while (reader.Read())
            {
                yield return materialize(reader);
            }
        }

        private static readonly ConcurrentDictionary<Type, Delegate> materializeFunctions = new ConcurrentDictionary<Type, Delegate>();
        private static Func<IDataReader, T> GetCachedMaterializeFunc<T>()
        {
            return (Func<IDataReader, T>)materializeFunctions.GetOrAdd(typeof(T), t =>
            {
                var r = Expression.Parameter(typeof(IDataReader), "r");
                var lambda = Expression.Lambda(
                    Expression.MemberInit(
                        Expression.New(t),
                        t.GetProperties()
                            .Select(p => Expression.Bind(p, GetAssignmentExpression(p, r)))
                    ), EnumerableExtensions.Yield(r)
                );

                return (Func<IDataReader, T>)lambda.Compile();
            });
        }

        private static Expression GetAssignmentExpression(PropertyInfo p, ParameterExpression r)
        {
            if (!p.CanWrite)
                throw new InvalidOperationException($"Property: {p.Name} of type:{p.DeclaringType.FullName} is not writable property!");

            var typeInfo = p.PropertyType.GetTypeInfo();
            if (typeInfo.IsValueType 
                && typeInfo.IsGenericType 
                && typeInfo.GetGenericTypeDefinition() == typeof(Nullable<>) 
                && typeInfo.GenericTypeParameters.Length == 1 
                && typeInfo.GenericTypeParameters[0].GetTypeInfo().IsPrimitive)
                return Expression.Call(ReadNullableMethod.MakeGenericMethod(p.PropertyType), EnumerableExtensions.Yield<Expression>(r, Expression.Constant(p.Name)));

            if (typeInfo.IsValueType && typeInfo.IsPrimitive)
                return Expression.Call(ReadStructMethod.MakeGenericMethod(p.PropertyType), EnumerableExtensions.Yield<Expression>(r, Expression.Constant(p.Name)));

            if (p.PropertyType == typeof(object) || p.PropertyType == typeof(string))
                return Expression.Call(ReadObjectMethod.MakeGenericMethod(p.PropertyType), EnumerableExtensions.Yield<Expression>(r, Expression.Constant(p.Name)));

            throw new InvalidOperationException($"Cannot materialize type:{p.PropertyType} for property: {p.Name} of type:{p.DeclaringType.FullName}");
        }


        private static readonly MethodInfo ReadObjectMethod = typeof(QueryUtil).GetMethods(BindingFlags.NonPublic | BindingFlags.Static).First(m => m.Name == nameof(ReadObject));
        private static T ReadObject<T>(IDataReader r, string name)
            where T : class
        {
            var value = r[name];
            return value == DBNull.Value ? null : (T)Convert.ChangeType(value, typeof(T));
        }

        private static readonly MethodInfo ReadStructMethod = typeof(QueryUtil).GetMethods(BindingFlags.NonPublic | BindingFlags.Static).First(m => m.Name == nameof(ReadStruct));
        private static T ReadStruct<T>(IDataReader r, string name)
            where T : struct
        {
            return (T)Convert.ChangeType(r[name], typeof(T));
        }

        private static readonly MethodInfo ReadNullableMethod = typeof(QueryUtil).GetMethods(BindingFlags.NonPublic | BindingFlags.Static).First(m => m.Name == nameof(ReadNullable));
        private static T? ReadNullable<T>(IDataReader r, string name)
            where T : struct
        {
            var value = r[name];
            return value == DBNull.Value ? default(T?) : (T) Convert.ChangeType(value, typeof(T));
        }
    }
}