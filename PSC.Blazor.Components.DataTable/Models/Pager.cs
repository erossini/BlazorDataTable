<<<<<<< HEAD
﻿// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="Pager.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using PSC.Blazor.Components.DataTable.Enums;

namespace PSC.Blazor.Components.DataTable.Models
{
	/// <summary>
	/// Class Pager.
	/// </summary>
	public class Pager
	{
		/// <summary>
		/// Gets the page number.
		/// </summary>
		/// <value>The page number.</value>
		public int PageNumber { get; private set; } = 1;

		/// <summary>
		/// Gets the size of the page.
		/// </summary>
		/// <value>The size of the page.</value>
		public int PageSize { get; private set; } = 30;

		/// <summary>
		/// Gets the sort column.
		/// </summary>
		/// <value>The sort column.</value>
		public string SortColumn { get; private set; } = "";

		/// <summary>
		/// Gets the sort direction.
		/// </summary>
		/// <value>The sort direction.</value>
		public SortDirection SortDirection { get; private set; } = SortDirection.Ascending;

		/// <summary>
		/// Initializes a new instance of the <see cref="Pager"/> class.
		/// </summary>
		/// <param name="pageNr">The page nr.</param>
		/// <param name="pageSize">Size of the page.</param>
		/// <param name="sortColumn">The sort column.</param>
		/// <param name="sortDirection">The sort direction.</param>
		public Pager(int pageNr, int pageSize, string sortColumn, SortDirection sortDirection)
		{
			this.PageNumber = pageNr;
			this.PageSize = pageSize;
			this.SortColumn = sortColumn;
			this.SortDirection = sortDirection;
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
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
}
