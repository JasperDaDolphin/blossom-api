using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Blossom.Data.Implementation
{
    public static class PredicateBuilder
    {

        public static Expression<Func<T, bool>> CreateExpressions<T>(string filters)
        {
            if (!String.IsNullOrEmpty(filters))
            {
                var entityFilters = JsonConvert.DeserializeObject<EntityFilters>(filters);
                return CreateExpressions<T>(entityFilters);
            }
            return null;
        }

        public static Expression<Func<T, bool>> CreateExpressions<T>(EntityFilters filters)
		{
            Expression<Func<T, bool>> mainexpr = null;

            if (filters.Group != null) { 
                foreach (var item in filters.Group)
                {
                    Expression<Func<T, bool>> expr = null;
                    if (item.Group != null)
                    {
                        expr = CreateExpressions<T>((EntityFilters)item);
                    }
                    else if (item.Filter != null)
                    {
                        var filter = item.Filter;
                        expr = FilterToFunc<T>(filter.Attribute, filter.Expression, filter.Value);
                    }

                    if (expr != null)
                    {
                        if (mainexpr != null)
                        {
                            switch (item.Join)
                            {
                                case "&&":
                                    mainexpr = mainexpr.And(expr);
                                    break;
                                case "||":
                                    mainexpr = mainexpr.Or(expr);
                                    break;
                                default:
                                    mainexpr = mainexpr.And(expr);
                                    break;
                            }
                        }
                        else
                        {
                            mainexpr = expr;
                        }
                    }
                }
            }
            return mainexpr;
		}

        private static Expression ToExprConstant(PropertyInfo prop, string value)
        {
            object val = null;
            if (prop.Name == "System.Guid")
            {
                val = Guid.NewGuid();
            }
            else
			{
                val = Convert.ChangeType(value, prop.PropertyType);
            }

            return Expression.Constant(val);
        }

        public static Expression<Func<T, bool>> FilterToFunc<T>(string propName, string opr, string value)
        {
            Expression<Func<T, bool>> func = null;

                var type = typeof(T);
                var prop = type.GetProperty(propName);
                ParameterExpression tpe = Expression.Parameter(typeof(T));
                Expression left = Expression.Property(tpe, prop);
                Expression right = Expression.Convert(ToExprConstant(prop, value), prop.PropertyType);

                switch (opr)
                {
                    case "==":
                    case "=":
                        func = Equal<T>(left, right, tpe);
                        break;
                    case "<":
                        func = LessThan<T>(left, right, tpe);
                        break;
                    case ">":
                        func = GreaterThan<T>(left, right, tpe);
                        break;
                    case ">=":
                        func = GreaterThanOrEqual<T>(left, right, tpe);
                        break;
                    case "<=":
                        func = LessThanOrEqual<T>(left, right, tpe);
                        break;
                    case "!=":
                        func = NotEqual<T>(left, right, tpe);
                        break;
                    case "like":
                    case "LIKE":
                        func = Contains<T>(left, right, tpe);
                        break;
                }

            return func;
        }

        private static Expression<Func<T, bool>> Equal<T>(Expression left, Expression right, ParameterExpression tpe)
		{
            return Expression.Lambda<Func<T, bool>>(Expression.Equal(left, right), tpe);
        }

        private static Expression<Func<T, bool>> LessThan<T>(Expression left, Expression right, ParameterExpression tpe)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.LessThan(left, right), tpe);
        }

        private static Expression<Func<T, bool>> GreaterThan<T>(Expression left, Expression right, ParameterExpression tpe)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.GreaterThan(left, right), tpe);
        }

        private static Expression<Func<T, bool>> GreaterThanOrEqual<T>(Expression left, Expression right, ParameterExpression tpe)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.GreaterThanOrEqual(left, right), tpe);
        }

        private static Expression<Func<T, bool>> LessThanOrEqual<T>(Expression left, Expression right, ParameterExpression tpe)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.LessThanOrEqual(left, right), tpe);
        }

        private static Expression<Func<T, bool>> NotEqual<T>(Expression left, Expression right, ParameterExpression tpe)
        {
            return Expression.Lambda<Func<T, bool>>(Expression.NotEqual(left, right), tpe);
        }

        private static Expression<Func<T, bool>> Contains<T>(Expression left, Expression right, ParameterExpression tpe)
        {
            var propertyType = left.Type;
            var containsmethod = propertyType.GetMethod("Contains", new[] { typeof(string) });
            var call = Expression.Call(left, containsmethod, right);
            return Expression.Lambda<Func<T, bool>>(call, tpe);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Func<T, TResult> ExpressionToFunc<T, TResult>(this Expression<Func<T, TResult>> expr)
        {
            var res = expr.Compile();
            return res;
        }
    }
}