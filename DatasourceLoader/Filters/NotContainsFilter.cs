﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Dma.DatasourceLoader.Filters
{
    public class NotContainsFilter<T> : FilterBase<T>
    {
        private readonly string value;

        public NotContainsFilter(string propertyName, string value) : base(propertyName) 
        {
            this.value = value;
        }

        public override LambdaExpression GetFilterExpression()
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T));
            MemberExpression property = Expression.Property(parameter, propertyName);
            MethodInfo containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            ConstantExpression constant = Expression.Constant(value);
            MethodCallExpression containsExpression = Expression.Call(property, containsMethod, constant);
            UnaryExpression notContainsExpression = Expression.Not(containsExpression);

            return Expression.Lambda<Func<T, bool>>(notContainsExpression, parameter);
        }
    }

}
