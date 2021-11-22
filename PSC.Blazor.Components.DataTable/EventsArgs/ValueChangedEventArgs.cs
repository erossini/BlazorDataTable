// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="ValueChangedEventArgs.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
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
		/// Initializes a new instance of the <see cref="ValueChangedEventArgs" /> class.
		/// </summary>
		/// <param name="value">The value.</param>
		public ValueChangedEventArgs(object value) => this.Value = value;
	}
}
