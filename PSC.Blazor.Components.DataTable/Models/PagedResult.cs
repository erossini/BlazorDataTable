<<<<<<< HEAD
﻿// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="PagedResult.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using PSC.Blazor.Components.DataTable.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PSC.Blazor.Components.DataTable.Models
{
	/// <summary>
	/// Class PagedResult.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PagedResult<T>
	{
		/// <summary>
		/// Gets the data.
		/// </summary>
		/// <value>The data.</value>
		public List<T> Data { get; private set; }

		/// <summary>
		/// Gets the paging.
		/// </summary>
		/// <value>The paging.</value>
		public PagingInfo Paging { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PagedResult{T}"/> class.
		/// </summary>
		/// <param name="items">The items.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="totalRecordCount">The total record count.</param>
		public PagedResult(IEnumerable<T> items, int pageNumber, int pageSize, long totalRecordCount)
		{
			this.Data = items.ToList<T>();
			int pageCount = totalRecordCount > 0L ? (int)Math.Ceiling(totalRecordCount / (double)pageSize) : 0;
			this.Paging = new PagingInfo(pageNumber, pageSize, pageCount, totalRecordCount);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="PagedResult{T}"/> class.
		/// </summary>
		/// <param name="items">The items.</param>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="totalRecordCount">The total record count.</param>
		/// <param name="sortColumn">The sort column.</param>
		/// <param name="sortDirection">The sort direction.</param>
		public PagedResult(
		  IEnumerable<T> items,
		  int pageNumber,
		  int pageSize,
		  long totalRecordCount,
		  string sortColumn,
		  SortDirection sortDirection)
		{
			this.Data = items.ToList<T>();
			int pageCount = totalRecordCount > 0L ? (int)Math.Ceiling(totalRecordCount / (double)pageSize) : 0;
			this.Paging = new PagingInfo(pageNumber, pageSize, pageCount, totalRecordCount, sortColumn, new SortDirection?(sortDirection));
		}
	}
=======
﻿using PSC.Blazor.Components.DataTable.Enums;
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
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
}
