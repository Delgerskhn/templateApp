﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Dma.DatasourceLoader.Filters
{
    public class EndsWithFilter<T> : FilterBase<T>
    {
        private readonly string value;

        public EndsWithFilter(string propertyName, string value) : base(propertyName)
        {
            this.value = value;
        }

        public override LambdaExpression GetFilterExpression()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            MemberExpression property = Expression.Property(parameter, propertyName);
            MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });
            ConstantExpression constant = Expression.Constant(value);
            MethodCallExpression endsWithExpression = Expression.Call(property, endsWithMethod, constant);

            return Expression.Lambda<Func<T, bool>>(endsWithExpression, parameter);
        }
    }
}
