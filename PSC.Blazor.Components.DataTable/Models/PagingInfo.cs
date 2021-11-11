using PSC.Blazor.Components.DataTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Models
{
    public class PagingInfo
    {
        public int PageNumber { get; private set; }

        public int PageSize { get; private set; }

        public int PageCount { get; private set; }

        public long TotalRecordCount { get; private set; }

        public string? SortColumn { get; private set; }

        public SortDirection? SortDirection { get; private set; }

        public PagingInfo(
          int pageNumber,
          int pageSize,
          int pageCount,
          long totalRecordCount,
          string? sortColumn,
          SortDirection? sortDirection)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.PageCount = pageCount;
            this.TotalRecordCount = totalRecordCount;
            this.SortColumn = sortColumn;
            this.SortDirection = sortDirection;
        }

        public PagingInfo(int pageNumber, int pageSize, int pageCount, long totalRecordCount)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.PageCount = pageCount;
            this.TotalRecordCount = totalRecordCount;
        }
    }
}
