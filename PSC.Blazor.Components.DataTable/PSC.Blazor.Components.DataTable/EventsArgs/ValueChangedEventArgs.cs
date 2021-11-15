using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.EventsArgs
{
	/// <summary>
	/// Class ValueChangedEventArgs.
	/// </summary>
	public class ValueChangedEventArgs
    {
		/// <summary>
		/// Gets the value.
		/// </summary>
		/// <value>The value.</value>
		public object Value { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="ValueChangedEventArgs"/> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public ValueChangedEventArgs(object value) => this.Value = value;
    }
}
