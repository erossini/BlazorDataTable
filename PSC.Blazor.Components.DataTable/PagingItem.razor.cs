using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable
{
	public partial class PagingItem
	{
		[CascadingParameter]
		private Paging paging { get; set; }

		/// <summary>
		/// Gets or sets the URL to open
		/// </summary>
		[Parameter]
		public string Href { get; set; } = "";

		/// <summary>
		/// Gets or sets if it is active or not
		/// </summary>
		[Parameter]
		public bool IsActive { get; set; }

		/// <summary>
		/// Gets or sets the page number
		/// </summary>
		[Parameter]
		public int PageNumber { get; set; }

		protected virtual Task OnInitializedAsync()
		{
			if (this.paging == null)
				throw new ArgumentNullException("A 'PagingItem' must be a child of the 'Paging' component");

			this.paging.AddPagingItem(this);
			return Task.CompletedTask;
		}
	}
}