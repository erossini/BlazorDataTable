// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-15-2021
// ***********************************************************************
// <copyright file="Enumeration.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PSC.Blazor.Components.DataTable.Code.Enumerations
{
	/// <summary>
	/// Class Enumeration.
	/// Implements the <see cref="System.IComparable" />
	/// </summary>
	/// <seealso cref="System.IComparable" />
	public abstract class Enumeration : IComparable
	{
		/// <summary>
		/// Gets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name { get; private set; }

		/// <summary>
		/// Gets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id { get; private set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Enumeration" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		protected Enumeration(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}

		/// <summary>
		/// Returns a <see cref="System.String" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="System.String" /> that represents this instance.</returns>
		public override string ToString() => this.Name;

		/// <summary>
		/// Gets all.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>IEnumerable&lt;T&gt;.</returns>
		public static IEnumerable<T> GetAll<T>() where T : Enumeration => ((IEnumerable<FieldInfo>)typeof(T).GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public)).Select<FieldInfo, object>(f => f.GetValue(null)).Cast<T>();

		/// <summary>
		/// Determines whether the specified <see cref="System.Object" /> is equal to this instance.
		/// </summary>
		/// <param name="obj">The object to compare with the current object.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj is Enumeration enumeration && this.GetType().Equals(obj.GetType()) & this.Id.Equals(enumeration.Id);

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => this.Id.GetHashCode();

		/// <summary>
		/// Absolutes the difference.
		/// </summary>
		/// <param name="firstValue">The first value.</param>
		/// <param name="secondValue">The second value.</param>
		/// <returns>System.Int32.</returns>
		public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue) => Math.Abs(firstValue.Id - secondValue.Id);

		/// <summary>
		/// Froms the value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="value">The value.</param>
		/// <returns>T.</returns>
		public static T FromValue<T>(int value) where T : Enumeration => Enumeration.Parse<T, int>(value, nameof(value), item => item.Id == value);

		/// <summary>
		/// Froms the display name.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="displayName">The display name.</param>
		/// <returns>T.</returns>
		public static T FromDisplayName<T>(string displayName) where T : Enumeration => Enumeration.Parse<T, string>(displayName, "display name", item => item.Name == displayName);

		/// <summary>
		/// Parses the specified value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <typeparam name="K"></typeparam>
		/// <param name="value">The value.</param>
		/// <param name="description">The description.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>T.</returns>
		/// <exception cref="InvalidOperationException"></exception>
		private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration => Enumeration.GetAll<T>().FirstOrDefault<T>(predicate) ?? throw new InvalidOperationException(string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T)));

		/// <summary>
		/// Compares to.
		/// </summary>
		/// <param name="other">The other.</param>
		/// <returns>System.Int32.</returns>
		public int CompareTo(object other) => this.Id.CompareTo(((Enumeration)other).Id);
	}
}
