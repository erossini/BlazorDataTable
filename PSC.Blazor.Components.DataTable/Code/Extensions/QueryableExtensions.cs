using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Code.Extensions
{
    public static class QueryableExtensions
    {
        public static Models.PagedResult<TEntity> ApplyPaging<TEntity>(
          this IQueryable<TEntity> source,
          Pager pager)
        {
            if (!string.IsNullOrEmpty(pager.SortColumn))
                source = (IQueryable<TEntity>)DynamicQueryableExtensions.OrderBy<TEntity>(source, pager.SortColumn + " " + pager.SortDirection.ToString().ToLower(), Array.Empty<object>());
            int count = (pager.PageNr - 1) * pager.PageSize;
            return new Models.PagedResult<TEntity>((IEnumerable<TEntity>)Queryable.Take<TEntity>(Queryable.Skip<TEntity>(source, count), pager.PageSize).ToList<TEntity>(), pager.PageNr, pager.PageSize, (long)Queryable.Count<TEntity>(source), pager.SortColumn, pager.SortDirection);
        }
    }
}