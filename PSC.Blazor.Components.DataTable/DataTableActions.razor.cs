using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable
{
	public partial class DataTableActions
	{
		/// <summary>
		/// Indicates whether or not to include a search icon. When clicked filters, sorting and paging is performed on the server 
		/// is FetchData has a value otherwise it happens on the client
		/// </summary>
		/// <value>By default is False</value>
		[Parameter]
		public bool IncludeSearchButton { get; set; } = false;

		/// <summary>
		/// Indicates whether or not to include a toggle icon. When clicked header/grid filters will disappear
		/// </summary>
		/// <value>By default is False</value>
		[Parameter]
		public bool IncludeToggleFilters { get; set; } = false;

		/// <summary>
		/// Indicates whether or not to show the header/grid filters
		/// </summary>
		/// <value>By default is True</value>
		[Parameter]
		public bool ShowHeaderFilters { get; set; } = true;

		/// <summary>
		/// Function to call for appling filters
		/// </summary>
		[Parameter]
		public Func<Task> ApplyFilters { get; set; }

		/// <summary>
		/// Event callback when an header filter changed
		/// </summary>
		[Parameter]
		public EventCallback<bool> ShowHeaderFiltersChangedEvent { get; set; }
	}
}