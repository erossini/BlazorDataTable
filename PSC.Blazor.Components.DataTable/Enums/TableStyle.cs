﻿// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-14-2021
// ***********************************************************************
// <copyright file="TableStyle.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;

namespace PSC.Blazor.Components.DataTable.Enums
{
	/// <summary>
	/// Enum TableStyle
	/// </summary>
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