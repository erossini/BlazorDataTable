<<<<<<< HEAD
﻿// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-15-2021
// ***********************************************************************
// <copyright file="CssUnit.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace PSC.Blazor.Components.DataTable.Code.Enumerations
{
	/// <summary>
	/// Class CssUnit.
	/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.Enumeration" />
	/// <remarks><para>
	/// CSS offers a number of different units for expressing length. Some have their history in typography,
	/// such as point (pt) and pica (pc), others are known from everyday use, such as centimeter (cm) and inch (in).
	/// And there is also a “magic” unit that was invented specifically for CSS: the px.
	/// </para>
	/// <para>
	///   <list type="table">
	///     <item>
	///       <description></description>
	///       <description>
	///         <strong>Recommended</strong>
	///       </description>
	///       <description>
	///         <strong>Occasional use</strong>
	///       </description>
	///       <description>
	///         <strong>Not recommended</strong>
	///       </description>
	///     </item>
	///     <item>
	///       <description>
	///         <strong>Screen</strong>
	///       </description>
	///       <description>ex, px, %</description>
	///       <description>ex</description>
	///       <description>pt, cm, mm, in, pc</description>
	///     </item>
	///     <item>
	///       <description>
	///         <strong>Print</strong>
	///       </description>
	///       <description>em, cm, mm, in, pt, pc, %</description>
	///       <description>px, ex</description>
	///       <description></description>
	///     </item>
	///   </list>
	/// </para>
	/// <para>
	/// The relation between the absolute units is as follows: 1in = 2.54cm = 25.4mm = 72pt = 6pc.</para>
	/// <para> The so-called absolute units (<strong>cm</strong>, <strong>mm</strong>, <strong>in</strong>, <strong>pt</strong> and <strong>pc</strong>) mean the same in CSS as everywhere else, but only if your output device has a high enough resolution. On a laser printer, 1cm should be exactly 1 centimeter. But on low-resolution devices, such as computer screens, CSS doesn't require that. And indeed, the result tends to be different from one device to another and from one CSS implementation to another. It's better to reserve these units for high-resolution devices and in particular for printed output. On computer screens and handheld devices, you'll probably not get what you expect.</para></remarks>
	public abstract class CssUnit : Enumeration
	{
		/// <summary>
		/// The centimeter
		/// </summary>
		public static readonly CssUnit Cm = new AbsoluteUnit(1, "cm");
		/// <summary>
		/// The millimeter
		/// </summary>
		public static readonly CssUnit Mm = new AbsoluteUnit(2, "mm");
		/// <summary>
		/// The inches
		/// </summary>
		public static readonly CssUnit In = new AbsoluteUnit(3, "in");
		/// <summary>
		/// The pixel
		/// </summary>
		public static readonly CssUnit Px = new AbsoluteUnit(4, "px");
		/// <summary>
		/// The point
		/// </summary>
		public static readonly CssUnit Pt = new AbsoluteUnit(5, "pt");
		/// <summary>
		/// The pica
		/// </summary>
		public static readonly CssUnit Pc = new AbsoluteUnit(6, "pc");
		/// <summary>
		/// The em
		/// </summary>
		public static readonly CssUnit Em = new RelativeUnit(7, "em");
		/// <summary>
		/// The ex
		/// </summary>
		public static readonly CssUnit Ex = new RelativeUnit(8, "ex");
		/// <summary>
		/// The ch
		/// </summary>
		public static readonly CssUnit Ch = new RelativeUnit(9, "ch");
		/// <summary>
		/// The rem
		/// </summary>
		public static readonly CssUnit Rem = new RelativeUnit(10, "rem");
		/// <summary>
		/// The viewport width
		/// </summary>
		public static readonly CssUnit Vw = new RelativeUnit(11, "vw");
		/// <summary>
		/// The viewport height
		/// </summary>
		public static readonly CssUnit Vh = new RelativeUnit(12, "vh");
		/// <summary>
		/// The viewport minimum
		/// </summary>
		public static readonly CssUnit VMin = new RelativeUnit(13, "vmin");
		/// <summary>
		/// The viewport maximum
		/// </summary>
		public static readonly CssUnit VMax = new RelativeUnit(14, "vmax");
		/// <summary>
		/// The percentage
		/// </summary>
		public static readonly CssUnit Percentage = new RelativeUnit(15, "%");

		/// <summary>
		/// Initializes a new instance of the <see cref="CssUnit" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		protected CssUnit(int id, string name)
		  : base(id, name)
		{
		}

		/// <summary>
		/// Class AbsoluteUnit.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.CssUnit" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.CssUnit" />
		private class AbsoluteUnit : CssUnit
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="AbsoluteUnit" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal AbsoluteUnit(int id, string name)
			  : base(id, name)
			{
			}
		}

		/// <summary>
		/// Class RelativeUnit.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.CssUnit" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.CssUnit" />
		private class RelativeUnit : CssUnit
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="RelativeUnit" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal RelativeUnit(int id, string name)
			  : base(id, name)
			{
			}
		}
	}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Code.Enumerations
{
    public abstract class CssUnit : Enumeration
	{
        public static readonly CssUnit Cm = (CssUnit)new CssUnit.AbsoluteUnit(1, "cm");
        public static readonly CssUnit Mm = (CssUnit)new CssUnit.AbsoluteUnit(2, "mm");
        public static readonly CssUnit In = (CssUnit)new CssUnit.AbsoluteUnit(3, "in");
        public static readonly CssUnit Px = (CssUnit)new CssUnit.AbsoluteUnit(4, "px");
        public static readonly CssUnit Pt = (CssUnit)new CssUnit.AbsoluteUnit(5, "pt");
        public static readonly CssUnit Pc = (CssUnit)new CssUnit.AbsoluteUnit(6, "pc");
        public static readonly CssUnit Em = (CssUnit)new CssUnit.RelativeUnit(7, "em");
        public static readonly CssUnit Ex = (CssUnit)new CssUnit.RelativeUnit(8, "ex");
        public static readonly CssUnit Ch = (CssUnit)new CssUnit.RelativeUnit(9, "ch");
        public static readonly CssUnit Rem = (CssUnit)new CssUnit.RelativeUnit(10, "rem");
        public static readonly CssUnit Vw = (CssUnit)new CssUnit.RelativeUnit(11, "vw");
        public static readonly CssUnit Vh = (CssUnit)new CssUnit.RelativeUnit(12, "vh");
        public static readonly CssUnit VMin = (CssUnit)new CssUnit.RelativeUnit(13, "vmin");
        public static readonly CssUnit VMax = (CssUnit)new CssUnit.RelativeUnit(14, "vmax");
        public static readonly CssUnit Percentage = (CssUnit)new CssUnit.RelativeUnit(15, "%");

        protected CssUnit(int id, string name)
          : base(id, name)
        {
        }

        private class AbsoluteUnit : CssUnit
        {
            internal AbsoluteUnit(int id, string name)
              : base(id, name)
            {
            }
        }

        private class RelativeUnit : CssUnit
        {
            internal RelativeUnit(int id, string name)
              : base(id, name)
            {
            }
        }
    }
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
}
