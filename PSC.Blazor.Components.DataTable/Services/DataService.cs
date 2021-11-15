<<<<<<< HEAD
﻿// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="DataService.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
=======
﻿using Microsoft.EntityFrameworkCore;
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
using PSC.Blazor.Components.DataTable.Code;
using PSC.Blazor.Components.DataTable.Interfaces;
using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
<<<<<<< HEAD
=======
using System.Text;
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Services
{
<<<<<<< HEAD
	/// <summary>
	/// Class DataService.
	/// Implements the <see cref="PSC.Blazor.Components.DataTable.Interfaces.IDataService{TContext}" />
	/// </summary>
	/// <typeparam name="TContext">The type of the t context.</typeparam>
	/// <seealso cref="PSC.Blazor.Components.DataTable.Interfaces.IDataService{TContext}" />
	public class DataService<TContext> : IDataService<TContext> where TContext : DbContext
	{
		/// <summary>
		/// The context
		/// </summary>
		private readonly TContext context;

		/// <summary>
		/// Initializes a new instance of the <see cref="DataService{TContext}"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public DataService(TContext context) => this.context = context;

		/// <summary>
		/// Searches the specified filters.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="filters">The filters.</param>
		/// <returns>IList&lt;TEntity&gt;.</returns>
		public IList<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> filters) where TEntity : class, new() => this.context.Set<TEntity>().Where<TEntity>(filters).ToList<TEntity>();

		/// <summary>
		/// Searches the paged.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="filters">The filters.</param>
		/// <param name="pager">The pager.</param>
		/// <returns>PagedResult&lt;TEntity&gt;.</returns>
		public PagedResult<TEntity> SearchPaged<TEntity>(
		  Expression<Func<TEntity, bool>> filters,
		  Pager pager)
		  where TEntity : class, new()
		{
			return this.context.Set<TEntity>().Where<TEntity>(filters).ApplyPaging<TEntity>(pager);
		}

		/// <summary>
		/// search as an asynchronous operation.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="filters">The filters.</param>
		/// <returns>A Task&lt;IList`1&gt; representing the asynchronous operation.</returns>
		public async Task<IList<TEntity>> SearchAsync<TEntity>(
		  Expression<Func<TEntity, bool>> filters)
		  where TEntity : class, new()
		{
			DbSet<TEntity> source = this.context.Set<TEntity>();
			List<TEntity> listAsync = await source.Where<TEntity>(filters).ToListAsync<TEntity>();
			return listAsync;
		}

		/// <summary>
		/// search paged as an asynchronous operation.
		/// </summary>
		/// <typeparam name="TEntity">The type of the t entity.</typeparam>
		/// <param name="filters">The filters.</param>
		/// <param name="pager">The pager.</param>
		/// <returns>A Task&lt;PagedResult`1&gt; representing the asynchronous operation.</returns>
		public async Task<PagedResult<TEntity>> SearchPagedAsync<TEntity>(
		  Expression<Func<TEntity, bool>> filters,
		  Pager pager)
		  where TEntity : class, new()
		{
			DbSet<TEntity> source = this.context.Set<TEntity>();
			PagedResult<TEntity> pagedResult = await source.Where<TEntity>(filters).ApplyPagingAsync<TEntity>(pager);
			return pagedResult;
		}
	}
=======
    public class DataService<TContext> : IDataService<TContext> where TContext : DbContext
    {
        private readonly TContext context;

        public DataService(TContext context) => this.context = context;

        public IList<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> filters) where TEntity : class, new() => (IList<TEntity>)this.context.Set<TEntity>().Where<TEntity>(filters).ToList<TEntity>();

        public PagedResult<TEntity> SearchPaged<TEntity>(
          Expression<Func<TEntity, bool>> filters,
          Pager pager)
          where TEntity : class, new()
        {
            return this.context.Set<TEntity>().Where<TEntity>(filters).ApplyPaging<TEntity>(pager);
        }

        public async Task<IList<TEntity>> SearchAsync<TEntity>(
          Expression<Func<TEntity, bool>> filters)
          where TEntity : class, new()
        {
            DbSet<TEntity> source = this.context.Set<TEntity>();
            List<TEntity> listAsync = await source.Where<TEntity>(filters).ToListAsync<TEntity>();
            return (IList<TEntity>)listAsync;
        }

        public async Task<PagedResult<TEntity>> SearchPagedAsync<TEntity>(
          Expression<Func<TEntity, bool>> filters,
          Pager pager)
          where TEntity : class, new()
        {
            DbSet<TEntity> source = this.context.Set<TEntity>();
            PagedResult<TEntity> pagedResult = await source.Where<TEntity>(filters).ApplyPagingAsync<TEntity>(pager);
            return pagedResult;
        }
    }
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
}
