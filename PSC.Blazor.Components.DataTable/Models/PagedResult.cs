using PSC.Blazor.Components.DataTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Models
{
    public class PagedResult<T>
    {
        public List<T> Data { get; private set; }

        public PagingInfo Paging { get; private set; }

        public PagedResult(IEnumerable<T> items, int pageNumber, int pageSize, long totalRecordCount)
        {
            this.Data = items.ToList<T>();
            int pageCount = totalRecordCount > 0L ? (int)Math.Ceiling((double)totalRecordCount / (double)pageSize) : 0;
            this.Paging = new PagingInfo(pageNumber, pageSize, pageCount, totalRecordCount);
        }

        public PagedResult(
          IEnumerable<T> items,
          int pageNumber,
          int pageSize,
          long totalRecordCount,
          string sortColumn,
          SortDirection sortDirection)
        {
            this.Data = items.ToList<T>();
            int pageCount = totalRecordCount > 0L ? (int)Math.Ceiling((double)totalRecordCount / (double)pageSize) : 0;
            this.Paging = new PagingInfo(pageNumber, pageSize, pageCount, totalRecordCount, sortColumn, new SortDirection?(sortDirection));
        }
    }
}
