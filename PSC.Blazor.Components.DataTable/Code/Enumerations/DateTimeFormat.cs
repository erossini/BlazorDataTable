// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-15-2021
// ***********************************************************************
// <copyright file="DateTimeFormat.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Linq.Expressions;

namespace PSC.Blazor.Components.DataTable.Code.Enumerations
{
	/// <summary>
	/// Class DateTimeFormat.
	/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.Enumeration" />
	public abstract class DateTimeFormat : Enumeration
	{
		/// <summary>
		/// The date
		/// </summary>
		public static readonly DateTimeFormat Date = new DateFormat(1, nameof(Date));
		/// <summary>
		/// The date hour minute
		/// </summary>
		public static readonly DateTimeFormat DateHourMinute = new DateHourMinuteFormat(2, nameof(DateHourMinute));
		/// <summary>
		/// The date hour minute second
		/// </summary>
		public static readonly DateTimeFormat DateHourMinuteSecond = new DateHourMinuteSecondFormat(3, nameof(DateHourMinuteSecond));

		/// <summary>
		/// Initializes a new instance of the <see cref="DateTimeFormat" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		protected DateTimeFormat(int id, string name)
		  : base(id, name)
		{
		}

		/// <summary>
		/// Gets the format.
		/// </summary>
		/// <value>The format.</value>
		public abstract string Format { get; }

		/// <summary>
		/// Gets the expression.
		/// </summary>
		/// <value>The expression.</value>
		public abstract Expression Expression { get; }

		/// <summary>
		/// Class DateFormat.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.DateTimeFormat" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.DateTimeFormat" />
		private class DateFormat : DateTimeFormat
		{
			/// <summary>
			/// Gets the format.
			/// </summary>
			/// <value>The format.</value>
			public override string Format => "yyyy-MM-dd";

			/// <summary>
			/// Gets the expression.
			/// </summary>
			/// <value>The expression.</value>
			/// <exception cref="NotImplementedException"></exception>
			public override Expression Expression => throw new NotImplementedException();

			/// <summary>
			/// Initializes a new instance of the <see cref="DateFormat" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal DateFormat(int id, string name)
			  : base(id, name)
			{
			}
		}

		/// <summary>
		/// Class DateHourMinuteFormat.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.DateTimeFormat" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.DateTimeFormat" />
		private class DateHourMinuteFormat : DateTimeFormat
		{
			/// <summary>
			/// Gets the format.
			/// </summary>
			/// <value>The format.</value>
			public override string Format => "yyyy-MM-ddTHH:mm";

			/// <summary>
			/// Gets the expression.
			/// </summary>
			/// <value>The expression.</value>
			/// <exception cref="NotImplementedException"></exception>
			public override Expression Expression => throw new NotImplementedException();

			/// <summary>
			/// Initializes a new instance of the <see cref="DateHourMinuteFormat" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal DateHourMinuteFormat(int id, string name)
			  : base(id, name)
			{
			}
		}

		/// <summary>
		/// Class DateHourMinuteSecondFormat.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.DateTimeFormat" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.DateTimeFormat" />
		private class DateHourMinuteSecondFormat : DateTimeFormat
		{
			/// <summary>
			/// Gets the format.
			/// </summary>
			/// <value>The format.</value>
			public override string Format => "yyyy-MM-ddTHH:mm:ss";

			/// <summary>
			/// Gets the expression.
			/// </summary>
			/// <value>The expression.</value>
			/// <exception cref="NotImplementedException"></exception>
			public override Expression Expression => throw new NotImplementedException();

			/// <summary>
			/// Initializes a new instance of the <see cref="DateHourMinuteSecondFormat" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal DateHourMinuteSecondFormat(int id, string name)
			  : base(id, name)
			{
			}
		}
	}
}