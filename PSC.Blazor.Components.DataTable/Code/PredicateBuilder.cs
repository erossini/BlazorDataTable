// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="PredicateBuilder.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq;
using System.Linq.Expressions;

namespace PSC.Blazor.Components.DataTable.Code
{
	/// <summary>
	/// Class PredicateBuilder.
	/// </summary>
	public static class PredicateBuilder
	{
		/// <summary>
		/// Trues this instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
		public static Expression<Func<T, bool>> True<T>() => (Expression<Func<T, bool>>)(f => true);

		/// <summary>
		/// Falses this instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
		public static Expression<Func<T, bool>> False<T>() => (Expression<Func<T, bool>>)(f => false);

		/// <summary>
		/// Ors the specified expr2.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expr1">The expr1.</param>
		/// <param name="expr2">The expr2.</param>
		/// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
		public static Expression<Func<T, bool>> Or<T>(
		  this Expression<Func<T, bool>> expr1,
		  Expression<Func<T, bool>> expr2)
		{
			InvocationExpression invocationExpression = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
			return Expression.Lambda<Func<T, bool>>(Expression.OrElse(expr1.Body, invocationExpression), expr1.Parameters);
		}

		/// <summary>
		/// Ands the specified expr2.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expr1">The expr1.</param>
		/// <param name="expr2">The expr2.</param>
		/// <returns>Expression&lt;Func&lt;T, System.Boolean&gt;&gt;.</returns>
		public static Expression<Func<T, bool>> And<T>(
		  this Expression<Func<T, bool>> expr1,
		  Expression<Func<T, bool>> expr2)
		{
			InvocationExpression invocationExpression = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
			return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(expr1.Body, invocationExpression), expr1.Parameters);
		}
	}
}