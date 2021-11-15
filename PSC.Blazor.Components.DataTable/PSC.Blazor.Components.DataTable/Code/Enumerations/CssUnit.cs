using System;
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
}
