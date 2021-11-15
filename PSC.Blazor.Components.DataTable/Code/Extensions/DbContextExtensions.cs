// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-15-2021
// ***********************************************************************
// <copyright file="DbContextExtensions.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace PSC.Blazor.Components.DataTable.Code.Extensions
{
	/// <summary>
	/// Class DbContextExtensions.
	/// </summary>
	public static class DbContextExtensions
	{
		/// <summary>
		/// Sets the specified t.
		/// </summary>
		/// <param name="context">The context.</param>
		/// <param name="T">The t.</param>
		/// <returns>IQueryable.</returns>
		public static IQueryable Set(this DbContext context, Type T) => typeof(DbContext).GetMethod(nameof(Set), BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(T).Invoke(context, null) as IQueryable;

		/// <summary>
		/// Sets the specified context.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="context">The context.</param>
		/// <returns>IQueryable&lt;T&gt;.</returns>
		public static IQueryable<T> Set<T>(this DbContext context) => typeof(DbContext).GetMethod(nameof(Set), BindingFlags.Instance | BindingFlags.Public).MakeGenericMethod(typeof(T)).Invoke(context, null) as IQueryable<T>;
	}
}
