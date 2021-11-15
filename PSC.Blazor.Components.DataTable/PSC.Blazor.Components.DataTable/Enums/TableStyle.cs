using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Enums
{
    [Flags]
    public enum TableStyle
    {
		/// <summary>
		/// The dark
		/// </summary>
		Dark = 1,
		/// <summary>
		/// The striped
		/// </summary>
		Striped = 2,
		/// <summary>
		/// The bordered
		/// </summary>
		Bordered = 4,
		/// <summary>
		/// The borderless
		/// </summary>
		Borderless = 8,
		/// <summary>
		/// The hover
		/// </summary>
		Hover = 16,
		/// <summary>
		/// The sm
		/// </summary>
		Sm = 32,
    }
}