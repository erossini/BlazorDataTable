// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="IDataService.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Interfaces
{
	/// <summary>
	/// Interface IDataService
	/// </summary>
	/// <typeparam name="TContext">The type of the t context.</typeparam>
	public interface IDataService<TContext> where TContext : DbContext
	{
		/// <summary>
		/// Searches the specified filters.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="filters">The filters.</param>
		/// <returns>IList&lt;TEntity&gt;.</returns>
		IList<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> filters) where TEntity : class, new();

		/// <summary>
		/// Searches the paged.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="filters">The filters.</param>
		/// <param name="pager">The pager.</param>
		/// <returns>PagedResult&lt;TEntity&gt;.</returns>
		PagedResult<TEntity> SearchPaged<TEntity>(
		  Expression<Func<TEntity, bool>> filters,
		  Pager pager)
		  where TEntity : class, new();

		/// <summary>
		/// Searches the asynchronous.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="filters">The filters.</param>
		/// <returns>Task&lt;IList&lt;TEntity&gt;&gt;.</returns>
		Task<IList<TEntity>> SearchAsync<TEntity>(Expression<Func<TEntity, bool>> filters) where TEntity : class, new();

		/// <summary>
		/// Searches the paged asynchronous.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="filters">The filters.</param>
		/// <param name="pager">The pager.</param>
		/// <returns>Task&lt;PagedResult&lt;TEntity&gt;&gt;.</returns>
		Task<PagedResult<TEntity>> SearchPagedAsync<TEntity>(
		  Expression<Func<TEntity, bool>> filters,
		  Pager pager)
		  where TEntity : class, new();
	}
}
