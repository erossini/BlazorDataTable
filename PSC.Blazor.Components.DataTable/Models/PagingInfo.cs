// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="PagingInfo.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using PSC.Blazor.Components.DataTable.Enums;

namespace PSC.Blazor.Components.DataTable.Models
{
	/// <summary>
	/// Class PagingInfo.
	/// </summary>
	public class PagingInfo
	{
		/// <summary>
		/// Gets the page number.
		/// </summary>
		/// <value>The page number.</value>
		public int PageNumber { get; private set; }

		/// <summary>
		/// Gets the size of the page.
		/// </summary>
		/// <value>The size of the page.</value>
		public int PageSize { get; private set; }

		/// <summary>
		/// Gets the page count.
		/// </summary>
		/// <value>The page count.</value>
		public int PageCount { get; private set; }

		/// <summary>
		/// Gets the total record count.
		/// </summary>
		/// <value>The total record count.</value>
		public long TotalRecordCount { get; private set; }

		/// <summary>
		/// Gets the sort column.
		/// </summary>
		/// <value>The sort column.</value>
		public string? SortColumn { get; private set; }

		/// <summary>
		/// Gets the sort direction.
		/// </summary>
		/// <value>The sort direction.</value>
		public SortDirection? SortDirection { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="PagingInfo"/> class.
		/// </summary>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageCount">The page count.</param>
		/// <param name="totalRecordCount">The total record count.</param>
		/// <param name="sortColumn">The sort column.</param>
		/// <param name="sortDirection">The sort direction.</param>
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

		/// <summary>
		/// Initializes a new instance of the <see cref="PagingInfo"/> class.
		/// </summary>
		/// <param name="pageNumber">The page number.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="pageCount">The page count.</param>
		/// <param name="totalRecordCount">The total record count.</param>
		public PagingInfo(int pageNumber, int pageSize, int pageCount, long totalRecordCount)
		{
			this.PageNumber = pageNumber;
			this.PageSize = pageSize;
			this.PageCount = pageCount;
			this.TotalRecordCount = totalRecordCount;
		}
	}
}
