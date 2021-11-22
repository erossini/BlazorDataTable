using Microsoft.AspNetCore.Components;

namespace PSC.Blazor.Components.DataTable
{
	public partial class Spinner
	{
		/// <summary>
		/// Determins if it has to display the spinner
		/// </summary>
		[Parameter]
		public bool IsLoading { get; set; }

		/// <summary>
		/// The loading text to display
		/// </summary>
		/// <value>
		/// By default the value is "Loading data..."
		/// </value>
		[Parameter]
		public string LoadingText { get; set; } = "Loading data...";
	}
}