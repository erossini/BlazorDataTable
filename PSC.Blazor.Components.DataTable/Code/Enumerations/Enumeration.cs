using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Code.Enumerations
{
    public abstract class Enumeration : IComparable
    {
        public string Name { get; private set; }

        public int Id { get; private set; }

        protected Enumeration(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public override string ToString() => this.Name;

        public static IEnumerable<T> GetAll<T>() where T : Enumeration => ((IEnumerable<FieldInfo>)typeof(T).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)).Select<FieldInfo, object>((Func<FieldInfo, object>)(f => f.GetValue((object)null))).Cast<T>();

        public override bool Equals(object obj) => obj is Enumeration enumeration && this.GetType().Equals(obj.GetType()) & this.Id.Equals(enumeration.Id);

        public override int GetHashCode() => this.Id.GetHashCode();

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue) => Math.Abs(firstValue.Id - secondValue.Id);

        public static T FromValue<T>(int value) where T : Enumeration => Enumeration.Parse<T, int>(value, nameof(value), (Func<T, bool>)(item => item.Id == value));

        public static T FromDisplayName<T>(string displayName) where T : Enumeration => Enumeration.Parse<T, string>(displayName, "display name", (Func<T, bool>)(item => item.Name == displayName));

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration => Enumeration.GetAll<T>().FirstOrDefault<T>(predicate) ?? throw new InvalidOperationException(string.Format("'{0}' is not a valid {1} in {2}", (object)value, (object)description, (object)typeof(T)));

        public int CompareTo(object other) => this.Id.CompareTo(((Enumeration)other).Id);
    }
}
