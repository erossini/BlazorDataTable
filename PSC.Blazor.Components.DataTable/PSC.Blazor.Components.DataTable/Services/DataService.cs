using Microsoft.EntityFrameworkCore;
using PSC.Blazor.Components.DataTable.Code;
using PSC.Blazor.Components.DataTable.Interfaces;
using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Services
{
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
}
