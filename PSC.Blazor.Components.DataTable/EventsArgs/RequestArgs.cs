using PSC.Blazor.Components.DataTable.Code;
using PSC.Blazor.Components.DataTable.Code.Filters;
using PSC.Blazor.Components.DataTable.Enums;
using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.EventsArgs
{
    public class RequestArgs<TModel>
    {
		public int PageNr { get; set; }

		public int PageSize { get; set; }

		public SortDirection SortDirection { get; set; }

		public string SortColumn { get; set; }

		public Pager Pager { get; private set; }

        public IList<FilterRule<TModel>> AppliedFilters { get; private set; }

        public RequestArgs(int pageNr, int pageSize, SortDirection sortDirection, string sortColumn, IList<FilterRule<TModel>> appliedFilters)
        {
            Pager = new Pager(pageNr, pageSize, sortColumn, sortDirection);
            AppliedFilters = appliedFilters;
        }

        public RequestArgs(Pager pager, IList<FilterRule<TModel>> appliedFilters)
        {
            Pager = pager;
            AppliedFilters = appliedFilters;
        }

        public Expression<Func<TModel, bool>> GetFilterExpression()
        {
            Expression<Func<TModel, bool>> filterExpression = (e) => true;

            foreach (var filterRule in AppliedFilters)
            {
                filterExpression = PredicateBuilder.And(filterExpression, filterRule.GenerateExpression());
            }

            return filterExpression;
        }
    }
}