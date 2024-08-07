﻿// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-15-2021
// ***********************************************************************
// <copyright file="QueryableExtensions.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace PSC.Blazor.Components.DataTable.Code.Extensions
{
	/// <summary>
	/// Class QueryableExtensions.
	/// </summary>
	public static class QueryableExtensions
	{
		/// <summary>
		/// Applies the paging.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="source">The source.</param>
		/// <param name="pager">The pager.</param>
		/// <returns>Models.PagedResult&lt;TEntity&gt;.</returns>
		public static Models.PagedResult<TEntity> ApplyPaging<TEntity>(
		  this IQueryable<TEntity> source,
		  Pager pager)
		{
			if (!string.IsNullOrEmpty(pager.SortColumn))
				source = source.OrderBy<TEntity>(pager.SortColumn + " " + pager.SortDirection.ToString().ToLower(), Array.Empty<object>());

			int count = (pager.PageNumber - 1) * pager.PageSize;
			return new Models.PagedResult<TEntity>(Queryable.Take<TEntity>(Queryable.Skip<TEntity>(source, count), pager.PageSize).ToList<TEntity>(),
				pager.PageNumber, pager.PageSize, source.Count<TEntity>(), pager.SortColumn, pager.SortDirection);
		}
	}
}