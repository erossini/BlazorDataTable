// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-15-2021
// ***********************************************************************
// <copyright file="Utils.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace PSC.Blazor.Components.DataTable.Code
{
	/// <summary>
	/// Class Utils.
	/// </summary>
	public static class Utils
	{
		/// <summary>
		/// Gets the name of the property.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="property">The property.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="Exception">Expression is not a MemeberExpression</exception>
		public static string GetPropertyName<T>(Expression<Func<T, object>> property)
		{
			if (!(property.Body is MemberExpression memberExpression))
			{
				try
				{
					memberExpression = ((UnaryExpression)property.Body).Operand as MemberExpression;
				}
				catch (InvalidCastException ex)
				{
					throw new Exception("Expression is not a MemeberExpression");
				}
			}
			PropertyInfo member = (PropertyInfo)memberExpression.Member;
			Type propertyType = member.PropertyType;
			string name = member.Name;
			string[] strArray = memberExpression.ToString().Split('.');
			return strArray.Length > 2 ? string.Join(".", ((IEnumerable<string>)strArray).Skip<string>(1)) : memberExpression.Member.Name;
		}

		/// <summary>
		/// Gets the type of the property.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="property">The property.</param>
		/// <returns>Type.</returns>
		/// <exception cref="Exception">Expression is not a MemeberExpression</exception>
		public static Type GetPropertyType<T>(Expression<Func<T, object>> property)
		{
			if (!(property.Body is MemberExpression memberExpression))
			{
				try
				{
					memberExpression = ((UnaryExpression)property.Body).Operand as MemberExpression;
				}
				catch (InvalidCastException ex)
				{
					throw new Exception("Expression is not a MemeberExpression");
				}
			}
			return ((PropertyInfo)memberExpression.Member).PropertyType;
		}

		/// <summary>
		/// Applies the paging.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="pager">The pager.</param>
		/// <returns>Models.PagedResult&lt;T&gt;.</returns>
		public static Models.PagedResult<T> ApplyPaging<T>(this IQueryable<T> source, Pager pager)
		{
			if (!string.IsNullOrEmpty(pager.SortColumn))
				source = source.OrderBy<T>(pager.SortColumn + " " + pager.SortDirection.ToString().ToLower(), Array.Empty<object>());

			int count = (pager.PageNumber - 1) * pager.PageSize;
			return new Models.PagedResult<T>(Queryable.Take<T>(Queryable.Skip<T>(source, count), pager.PageSize).ToList<T>(), pager.PageNumber, pager.PageSize, source.Count<T>(), pager.SortColumn, pager.SortDirection);
		}

		/// <summary>
		/// Applies the paging.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="pager">The pager.</param>
		/// <returns>Models.PagedResult&lt;T&gt;.</returns>
		public static Models.PagedResult<T> ApplyPaging<T>(this IEnumerable<T> source, Pager pager)
		{
			if (!string.IsNullOrEmpty(pager.SortColumn))
				source = source.AsQueryable().OrderBy<T>(pager.SortColumn + " " + pager.SortDirection.ToString().ToLower(), Array.Empty<object>());

			int count = (pager.PageNumber - 1) * pager.PageSize;
			IEnumerable<T> list = source.Skip(count).Take(pager.PageSize);
			return new Models.PagedResult<T>(list, pager.PageNumber, pager.PageSize, source.Count(), pager.SortColumn, pager.SortDirection);
		}

		/// <summary>
		/// apply paging as an asynchronous operation.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source">The source.</param>
		/// <param name="pager">The pager.</param>
		/// <returns>A Task&lt;Models.PagedResult`1&gt; representing the asynchronous operation.</returns>
		public static async Task<Models.PagedResult<T>> ApplyPagingAsync<T>(
		  this IQueryable<T> source,
		  Pager pager)
		{
			if (!string.IsNullOrEmpty(pager.SortColumn))
				source = source.OrderBy<T>(pager.SortColumn + " " + pager.SortDirection.ToString().ToLower(), Array.Empty<object>());

			int skip = (pager.PageNumber - 1) * pager.PageSize;
			List<T> result = await Queryable.Skip<T>(source, skip).Take<T>(pager.PageSize).ToListAsync<T>();

			return new Models.PagedResult<T>(result, pager.PageNumber, pager.PageSize, source.Count<T>(), pager.SortColumn, pager.SortDirection);
		}

		/// <summary>
		/// Gets the minimum maximum value.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns>Tuple&lt;T, T&gt;.</returns>
		public static Tuple<T, T> GetMinMaxValue<T>()
		{
			object obj1 = default(T);
			object obj2 = default(T);
			if (obj1 == null || obj2 == null)
				return null;
			switch (Type.GetTypeCode(typeof(T)))
			{
				case TypeCode.Char:
					obj1 = char.MinValue;
					obj2 = char.MaxValue;
					break;
				case TypeCode.SByte:
					obj1 = sbyte.MinValue;
					obj2 = sbyte.MaxValue;
					break;
				case TypeCode.Byte:
					obj1 = (byte)0;
					obj2 = byte.MaxValue;
					break;
				case TypeCode.Int16:
					obj1 = short.MinValue;
					obj2 = short.MaxValue;
					break;
				case TypeCode.UInt16:
					obj1 = (ushort)0;
					obj2 = ushort.MaxValue;
					break;
				case TypeCode.Int32:
					obj1 = int.MinValue;
					obj2 = int.MaxValue;
					break;
				case TypeCode.UInt32:
					obj1 = 0U;
					obj2 = uint.MaxValue;
					break;
				case TypeCode.Int64:
					obj1 = long.MinValue;
					obj2 = long.MaxValue;
					break;
				case TypeCode.UInt64:
					obj1 = 0UL;
					obj2 = ulong.MaxValue;
					break;
				case TypeCode.Single:
					obj1 = float.MinValue;
					obj2 = float.MaxValue;
					break;
				case TypeCode.Double:
					obj1 = double.MinValue;
					obj2 = double.MaxValue;
					break;
				case TypeCode.Decimal:
					obj1 = decimal.MinValue;
					obj2 = decimal.MaxValue;
					break;
				case TypeCode.DateTime:
					obj1 = DateTime.MinValue;
					obj2 = DateTime.MaxValue;
					break;
			}
			return Tuple.Create<T, T>((T)obj1, (T)obj2);
		}

		/// <summary>
		/// Determines whether the specified type is number.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><c>true</c> if the specified type is number; otherwise, <c>false</c>.</returns>
		public static bool IsNumber(Type type)
		{
			switch (Type.GetTypeCode(type))
			{
				case TypeCode.SByte:
				case TypeCode.Byte:
				case TypeCode.Int16:
				case TypeCode.UInt16:
				case TypeCode.Int32:
				case TypeCode.UInt32:
				case TypeCode.Int64:
				case TypeCode.UInt64:
				case TypeCode.Single:
				case TypeCode.Double:
				case TypeCode.Decimal:
					return true;
				default:
					return false;
			}
		}

		/// <summary>
		/// Determines whether the specified object is number.
		/// </summary>
		/// <param name="obj">The object.</param>
		/// <returns><c>true</c> if the specified object is number; otherwise, <c>false</c>.</returns>
		public static bool IsNumber(object obj) => Utils.IsNumber(obj.GetType());
	}
}