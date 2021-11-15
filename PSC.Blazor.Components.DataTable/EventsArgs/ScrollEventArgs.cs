// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="ScrollEventArgs.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using PSC.Blazor.Components.DataTable.Models;

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
