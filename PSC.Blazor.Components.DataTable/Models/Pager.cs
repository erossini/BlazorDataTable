using PSC.Blazor.Components.DataTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Models
{
    public class Pager
    {
        public int PageNr { get; private set; } = 1;

        public int PageSize { get; private set; } = 30;

        public string SortColumn { get; private set; } = "";

        public SortDirection SortDirection { get; private set; } = SortDirection.Ascending;

        public Pager(int pageNr, int pageSize, string sortColumn, SortDirection sortDirection)
        {
            this.PageNr = pageNr;
            this.PageSize = pageSize;
            this.SortColumn = sortColumn;
            this.SortDirection = sortDirection;
        }
    }
}
