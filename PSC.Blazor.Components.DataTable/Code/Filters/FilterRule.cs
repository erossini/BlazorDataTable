<<<<<<< HEAD
﻿// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-15-2021
// ***********************************************************************
// <copyright file="FilterRule.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using PSC.Blazor.Components.DataTable.Code.Enumerations;
using PSC.Blazor.Components.DataTable.EventsArgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PSC.Blazor.Components.DataTable.Code.Filters
{
	/// <summary>
	/// Class FilterRule.
	/// </summary>
	/// <typeparam name="TModel">The type of the t model.</typeparam>
	public class FilterRule<TModel>
	{
		/// <summary>
		/// Gets the unique identifier.
		/// </summary>
		/// <value>The unique identifier.</value>
		public Guid Guid { get; private set; }

		/// <summary>
		/// Gets the column.
		/// </summary>
		/// <value>The column.</value>
		public DataTableColumn<TModel> Column { get; private set; }

		/// <summary>
		/// Gets the name of the property.
		/// </summary>
		/// <value>The name of the property.</value>
		public string PropertyName { get; private set; }

		/// <summary>
		/// Gets or sets the type of the filter.
		/// </summary>
		/// <value>The type of the filter.</value>
		public ObjectFilter FilterType { get; set; }

		/// <summary>
		/// Gets the expected type of the value.
		/// </summary>
		/// <value>The expected type of the value.</value>
		public Type ExpectedValueType { get; private set; }

		/// <summary>
		/// Gets the filter value.
		/// </summary>
		/// <value>The filter value.</value>
		public dynamic? FilterValue { get; private set; } = null;

		/// <summary>
		/// Gets or sets a value indicating whether this instance is applied.
		/// </summary>
		/// <value><c>true</c> if this instance is applied; otherwise, <c>false</c>.</value>
		public bool IsApplied { get; set; } = false;

		/// <summary>
		/// Gets a value indicating whether this instance is nullable.
		/// </summary>
		/// <value><c>true</c> if this instance is nullable; otherwise, <c>false</c>.</value>
		public bool IsNullable { get; private set; } = false;

		/// <summary>
		/// Initializes a new instance of the <see cref="FilterRule{TModel}" /> class.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <param name="propertyType">Type of the property.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="objectFilter">The object filter.</param>
=======
﻿using PSC.Blazor.Components.DataTable.Code.Enumerations;
using PSC.Blazor.Components.DataTable.Components;
using PSC.Blazor.Components.DataTable.EventsArgs;
using System;
using System.Linq.Expressions;

namespace PSC.Blazor.Components.DataTable.Code.Filters
{
	public class
		FilterRule<TModel>
	{
		public Guid Guid { get; private set; }

		public DataTableColumn<TModel> Column { get; private set; }

		public string PropertyName { get; private set; }

		public ObjectFilter FilterType { get; set; }

		public Type ExpectedValueType { get; private set; }

		public dynamic? FilterValue { get; private set; } = null;

		public bool IsApplied { get; set; } = false;

		public bool IsNullable { get; private set; } = false;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		public FilterRule(DataTableColumn<TModel> column, Type propertyType, string propertyName, ObjectFilter objectFilter)
		{
			Guid = Guid.NewGuid();
			Column = column;
			FilterType = objectFilter;
			PropertyName = propertyName;

			UpdatePropertyType(propertyType);
		}

<<<<<<< HEAD
		/// <summary>
		/// Updates the filter property.
		/// </summary>
		/// <param name="column">The column.</param>
		/// <param name="propertyType">Type of the property.</param>
		/// <param name="propertyName">Name of the property.</param>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		public void UpdateFilterProperty(DataTableColumn<TModel> column, Type propertyType, string propertyName)
		{
			Column = column;
			PropertyName = propertyName;
			UpdatePropertyType(propertyType);
		}

<<<<<<< HEAD
		/// <summary>
		/// Updates the filter value.
		/// </summary>
		/// <param name="valueChangedEventArgs">The <see cref="ValueChangedEventArgs" /> instance containing the event data.</param>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		public void UpdateFilterValue(ValueChangedEventArgs valueChangedEventArgs)
		{
			FilterValue = valueChangedEventArgs.Value;
		}

<<<<<<< HEAD
		/// <summary>
		/// Generates the expression.
		/// </summary>
		/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		public Expression<Func<TModel, bool>> GenerateExpression()
		{
			if (Type.GetTypeCode(ExpectedValueType) == TypeCode.DateTime)
			{
				if (Column.DateTimeFormat == DateTimeFormat.Date) return FilterType.GenerateExpression<TModel>($"{Column.GetColumnPropertyName()}.Date", FilterValue.Date);
				else if (Column.DateTimeFormat == DateTimeFormat.DateHourMinute)
				{
					var dateExpression = FilterType.GenerateExpression<TModel>($"{Column.GetColumnPropertyName()}.Date", FilterValue.Date);
					var hourExpression = FilterType.GenerateExpression<TModel>($"{Column.GetColumnPropertyName()}.Hour", FilterValue.Hour);
					var minuteExpression = FilterType.GenerateExpression<TModel>($"{Column.GetColumnPropertyName()}.Minute", FilterValue.Minute);
					var p1 = PredicateBuilder.And(dateExpression, hourExpression);
					return PredicateBuilder.And(p1, minuteExpression);
				}
				else if (Column.DateTimeFormat == DateTimeFormat.DateHourMinuteSecond)
				{
					return FilterType.GenerateExpression<TModel>(Column.GetColumnPropertyName(), FilterValue);
				}
			}

			return FilterType.GenerateExpression<TModel>(Column.GetColumnPropertyName(), FilterValue);
		}

<<<<<<< HEAD
		/// <summary>
		/// Updates the type of the property.
		/// </summary>
		/// <param name="propertyType">Type of the property.</param>
		/// <exception cref="Exception">Unsupported property type for filtering</exception>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		private void UpdatePropertyType(Type propertyType)
		{
			if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				propertyType = Nullable.GetUnderlyingType(propertyType);
				IsNullable = true;
			}

			ExpectedValueType = propertyType;

			if (propertyType.IsEnum) FilterValue = Enum.GetNames(propertyType)[0];
			else
			{
				switch (Type.GetTypeCode(propertyType))
				{
					case TypeCode.Int16:
						FilterValue = default(System.Int16);
						break;

					case TypeCode.Int32:
						FilterValue = default(System.Int32);
						break;

					case TypeCode.Int64:
						FilterValue = default(System.Int64);
						break;

					case TypeCode.UInt16:
						FilterValue = default(System.UInt16);
						break;

					case TypeCode.UInt32:
						FilterValue = default(System.UInt32);
						break;

					case TypeCode.UInt64:
						FilterValue = default(System.UInt64);
						break;

					case TypeCode.Double:
						FilterValue = default(System.Double);
						break;

					case TypeCode.Decimal:
						FilterValue = default(System.Decimal);
						break;

					case TypeCode.Byte:
						FilterValue = default(System.Byte);
						break;

					case TypeCode.Boolean:
						FilterValue = false;
						break;

					case TypeCode.String:
						FilterValue = "";
						break;

					case TypeCode.DateTime:
						FilterValue = DateTime.UtcNow;
						break;

					// TODO: Some types might be possible
					case TypeCode.Object:
					case TypeCode.Char:
					case TypeCode.SByte:
					case TypeCode.Single:
						throw new Exception("Unsupported property type for filtering");
				}
			}
		}

<<<<<<< HEAD
		/// <summary>
		/// Gets the applied filter rule text.
		/// </summary>
		/// <returns>System.String.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		public string GetAppliedFilterRuleText()
		{
			if (FilterType.ValueRequired)
			{
				if (Type.GetTypeCode(ExpectedValueType) == TypeCode.DateTime) return $"{Column.GetColumnVisualPropertyName()}\t{FilterType.ToString()}\t{FilterValue!.ToString(Column.DateTimeFormat.Format)}";
				else return $"{Column.GetColumnVisualPropertyName()}\t{FilterType.ToString()}\t{FilterValue}";
			}
			else return $"{Column.GetColumnVisualPropertyName()}\t{FilterType.ToString()}";
		}
<<<<<<< HEAD

		/// <summary>
		/// Applies the in memory filters.
		/// </summary>
		/// <param name="models">The models.</param>
		/// <returns>IList&lt;TModel&gt;.</returns>
		/// <exception cref="Exception">Unsupported property type for filtering</exception>
		public IList<TModel> ApplyInMemoryFilters(IList<TModel> models)
		{
			switch (Type.GetTypeCode(ExpectedValueType))
			{
				case TypeCode.Int16:
					break;

				case TypeCode.Int32:
					break;

				case TypeCode.Int64:
					break;

				case TypeCode.UInt16:
					break;

				case TypeCode.UInt32:
					break;

				case TypeCode.UInt64:
					break;

				case TypeCode.Double:
					break;

				case TypeCode.Decimal:
					break;

				case TypeCode.Byte:
					break;

				case TypeCode.Boolean:
					break;

				case TypeCode.String:
					models = ApplyFilterString(models);
					break;

				case TypeCode.DateTime:
					break;

				// TODO: Some types might be possible
				case TypeCode.Object:
				case TypeCode.Char:
				case TypeCode.SByte:
				case TypeCode.Single:
					throw new Exception("Unsupported property type for filtering");
			}

			return models;
		}

		/// <summary>
		/// Applies the filter string.
		/// </summary>
		/// <param name="models">The models.</param>
		/// <returns>IList&lt;TModel&gt;.</returns>
		public IList<TModel> ApplyFilterString(IList<TModel> models)
		{
			var searchStrLower = FilterValue.ToString().ToLower();
			var propsToCheck = typeof(TModel).GetProperties().Where(a => a.PropertyType == typeof(string) && a.Name == PropertyName && a.CanRead);

			return models.Where(obj =>
			{
				foreach (PropertyInfo prop in propsToCheck)
				{
					string value = (string)prop.GetValue(obj);
					if (value != null && value.ToLower().Contains(searchStrLower)) return true;
				}
				return false;
			}).ToList();
		}
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
	}
}