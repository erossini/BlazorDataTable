using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.EventsArgs
{
	/// <summary>
	/// Class ScrollEventArgs.
	/// </summary>
	public class ScrollEventArgs
    {
		/// <summary>
		/// Gets or sets the container rect.
		/// </summary>
		/// <value>The container rect.</value>
		public DOMRect ContainerRect { get; set; }
		/// <summary>
		/// Gets or sets the content rect.
		/// </summary>
		/// <value>The content rect.</value>
		public DOMRect ContentRect { get; set; }
    }
}
