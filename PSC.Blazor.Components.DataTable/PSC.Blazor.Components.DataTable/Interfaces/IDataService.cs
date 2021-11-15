using Microsoft.EntityFrameworkCore;
using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Interfaces
{
    public interface IDataService<TContext> where TContext : DbContext
    {
        IList<TEntity> Search<TEntity>(Expression<Func<TEntity, bool>> filters) where TEntity : class, new();

        PagedResult<TEntity> SearchPaged<TEntity>(
          Expression<Func<TEntity, bool>> filters,
          Pager pager)
          where TEntity : class, new();

        Task<IList<TEntity>> SearchAsync<TEntity>(Expression<Func<TEntity, bool>> filters) where TEntity : class, new();

        Task<PagedResult<TEntity>> SearchPagedAsync<TEntity>(
          Expression<Func<TEntity, bool>> filters,
          Pager pager)
          where TEntity : class, new();
    }
}
