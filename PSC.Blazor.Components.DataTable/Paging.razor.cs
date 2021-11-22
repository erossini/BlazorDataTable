using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable
{
	public partial class Paging
	{
		/// <summary>
		/// Gets or sets the number of pages.
		/// </summary>
		[Parameter]
		public int PageCount { get; set; } = 1;
		/// <summary>
		/// Gets or sets the active page
		/// </summary>
		[Parameter]
		public int ActivePageNumber { get; set; } = 1;
		/// <summary>
		/// Gets or sets the number of items per page
		/// </summary>
		[Parameter]
		public int PageSize { get; set; } = 10;
		/// <summary>
		/// Defines the list of page sizes to display in the select
		/// </summary>
		[Parameter]
		public List<int> PageSizeList { get; set; } = new List<int> { 10, 25, 50 };
		/// <summary>
		/// Gets or sets the event to call when the user selects a new page to go
		/// </summary>
		[Parameter]
		public EventCallback<int> GoToPageEvent { get; set; }

		/// <summary>
		/// Gets or sets the event to call when the user changes the page size
		/// </summary>
		[Parameter]
		public EventCallback<int> PageSizeChangedEvent { get; set; }

		/// <summary>
		/// Gets or sets the CSS class for buttons
		/// </summary>
		[Parameter]
		public string ButtonClass { get; set; } = "btn-light border";
		/// <summary>
		/// Gets or sets the CSS class for the page number
		/// </summary>
		[Parameter]
		public string PageNumberClass { get; set; } = "bg-light border";
		/// <summary>
		/// Gets or sets if the button to jump to the first page is visible or not
		/// </summary>
		[Parameter]
		public bool IncludeFirstButton { get; set; } = true;
		/// <summary>
		/// Gets or sets if the button to jump to the last page is visible or not
		/// </summary>
		[Parameter]
		public bool IncludeLastButton { get; set; } = true;
		/// <summary>
		/// Gets or sets if the first page is a label and not a button
		/// </summary>
		[Parameter]
		public bool UseLabelFirstButton { get; set; } = false;
		/// <summary>
		/// Gets or sets if the last page is a label and not a button
		/// </summary>
		[Parameter]
		public bool UseLabelLastButton { get; set; } = false;
		/// <summary>
		/// Gets or sets the text for the first page
		/// </summary>
		[Parameter]
		public string FirstPageButtonLabel { get; set; } = "First";
		/// <summary>
		/// Gets or sets the text for the last page
		/// </summary>
		[Parameter]
		public string LastPageButtonLabel { get; set; } = "Last";
		/// <summary>
		/// Gets or sets if the next button has to be shown
		/// </summary>
		[Parameter]
		public bool IncludeNextButton { get; set; } = true;
		/// <summary>
		/// Gets or sets if the previous button has to be shown
		/// </summary>
		[Parameter]
		public bool IncludePrevButton { get; set; } = true;
		/// <summary>
		/// Gets or sets if the page size dropdown has to be shown
		/// </summary>
		[Parameter]
		public bool IncludePageSizeSelect { get; set; } = true;
		/// <summary>
		/// Gets or sets if the next button is a label and not a button
		/// </summary>
		[Parameter]
		public bool UseLabelNextButton { get; set; } = false;
		/// <summary>
		/// Gets or sets if the previous button is a label and not a button
		/// </summary>
		[Parameter]
		public bool UseLabelPrevButton { get; set; } = false;
		/// <summary>
		/// Gets or sets the text for the next page
		/// </summary>
		[Parameter]
		public string NextButtonLabel { get; set; } = "Next";
		/// <summary>
		/// Gets or sets the text for the previous page
		/// </summary>
		[Parameter]
		public string PrevButtonLabel { get; set; } = "Prev";
		[Parameter]
		public RenderFragment ChildContent { get; set; }

		private List<PagingItem> pagingItems = new List<PagingItem>();
		internal void AddPagingItem(PagingItem pagingItem)
		{
			this.pagingItems.Add(pagingItem);
			this.StateHasChanged();
		}

		private async Task ChangePageSize(ChangeEventArgs e)
		{
			PageSize = Convert.ToInt16(e.Value.ToString());
			await this.PageSizeChangedEvent.InvokeAsync(PageSize);
		}

		private async Task GoToPage(int pageNr)
		{
			if (pageNr <= this.PageCount && pageNr >= 1)
			{
				this.ActivePageNumber = pageNr;
				this.StateHasChanged();
			}

			await this.GoToPageEvent.InvokeAsync(this.ActivePageNumber);
		}

		private async Task NextPage()
		{
			if (this.ActivePageNumber < this.PageCount)
			{
				++this.ActivePageNumber;
				this.StateHasChanged();
			}

			await this.GoToPageEvent.InvokeAsync(this.ActivePageNumber);
		}

		private async Task PreviousPage()
		{
			if (this.ActivePageNumber > 1)
			{
				--this.ActivePageNumber;
				this.StateHasChanged();
			}

			await this.GoToPageEvent.InvokeAsync(this.ActivePageNumber);
		}

		private string GetActiveCssClass(int pageNr) => this.ActivePageNumber != pageNr ? "" : "active";
	}
}