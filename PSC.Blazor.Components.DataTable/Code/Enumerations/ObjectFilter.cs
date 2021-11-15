<<<<<<< HEAD
﻿// ***********************************************************************
// Assembly         : PSC.Blazor.Components.DataTable
// Author           : Enrico Rossini
// Created          : 11-14-2021
//
// Last Modified By : Enrico Rossini
// Last Modified On : 11-15-2021
// ***********************************************************************
// <copyright file="ObjectFilter.cs" company="Enrico Rossini - PureSourceCode.com">
//     Enrico Rossini - PureSourceCode.com
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace PSC.Blazor.Components.DataTable.Code.Enumerations
{
	/// <summary>
	/// Class ObjectFilter.
	/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.Enumeration" />
	/// </summary>
	/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.Enumeration" />
	public abstract class ObjectFilter : Enumeration
	{
		/// <summary>
		/// The is equals
		/// </summary>
		public static readonly ObjectFilter IsEquals = new IsEqualsFilter(1, nameof(IsEquals));
		/// <summary>
		/// The not equals
		/// </summary>
		public static readonly ObjectFilter NotEquals = new NotEqualsFilter(2, nameof(NotEquals));
		/// <summary>
		/// The greater than
		/// </summary>
		public static readonly ObjectFilter GreaterThan = new GreaterThanFilter(3, nameof(GreaterThan));
		/// <summary>
		/// The greater than or equals
		/// </summary>
		public static readonly ObjectFilter GreaterThanOrEquals = new GreaterThanOrEqualsFilter(4, nameof(GreaterThanOrEquals));
		/// <summary>
		/// The less than
		/// </summary>
		public static readonly ObjectFilter LessThan = new LessThanFilter(5, nameof(LessThan));
		/// <summary>
		/// The less than or equals
		/// </summary>
		public static readonly ObjectFilter LessThanOrEquals = new LessThanOrEqualsFilter(6, nameof(LessThanOrEquals));
		/// <summary>
		/// Determines whether this instance contains the object.
		/// </summary>
		public static readonly ObjectFilter Contains = new ContainsFilter(7, nameof(Contains));
		/// <summary>
		/// The not contains
		/// </summary>
		public static readonly ObjectFilter NotContains = new NotContainsFilter(8, nameof(NotContains));
		/// <summary>
		/// The starts with
		/// </summary>
		public static readonly ObjectFilter StartsWith = new StartsWithFilter(9, nameof(StartsWith));
		/// <summary>
		/// The ends with
		/// </summary>
		public static readonly ObjectFilter EndsWith = new EndsWithFilter(10, nameof(EndsWith));
		/// <summary>
		/// The is null
		/// </summary>
		public static readonly ObjectFilter IsNull = new IsNullFilter(11, nameof(IsNull));
		/// <summary>
		/// The is not null
		/// </summary>
		public static readonly ObjectFilter IsNotNull = new IsNotNullFilter(12, nameof(IsNotNull));

		/// <summary>
		/// Gets a value indicating whether [value required].
		/// </summary>
		/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
		public abstract bool ValueRequired { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is number allowed.
		/// </summary>
		/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
		public abstract bool IsNumberAllowed { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is bool allowed.
		/// </summary>
		/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
		public abstract bool IsBoolAllowed { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is string allowed.
		/// </summary>
		/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
		public abstract bool IsStringAllowed { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is date time allowed.
		/// </summary>
		/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
		public abstract bool IsDateTimeAllowed { get; }

		/// <summary>
		/// Gets a value indicating whether this instance is non nullable allowed.
		/// </summary>
		/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
		public abstract bool IsNonNullableAllowed { get; }

		/// <summary>
		/// Gets a value indicating whether [use embedded filter].
		/// </summary>
		/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
		public abstract bool UseEmbeddedFilter { get; }

		/// <summary>
		/// Generates the expression.
		/// </summary>
		/// <typeparam name="TModel">The type of the t model.</typeparam>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="value">The value.</param>
		/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq.Expressions;

namespace PSC.Blazor.Components.DataTable.Code.Enumerations
{
	public abstract class ObjectFilter : Enumeration
	{
		public static readonly ObjectFilter IsEquals = (ObjectFilter)new ObjectFilter.IsEqualsFilter(1, nameof(IsEquals));
		public static readonly ObjectFilter NotEquals = (ObjectFilter)new ObjectFilter.NotEqualsFilter(2, nameof(NotEquals));
		public static readonly ObjectFilter GreaterThan = (ObjectFilter)new ObjectFilter.GreaterThanFilter(3, nameof(GreaterThan));
		public static readonly ObjectFilter GreaterThanOrEquals = (ObjectFilter)new ObjectFilter.GreaterThanOrEqualsFilter(4, nameof(GreaterThanOrEquals));
		public static readonly ObjectFilter LessThan = (ObjectFilter)new ObjectFilter.LessThanFilter(5, nameof(LessThan));
		public static readonly ObjectFilter LessThanOrEquals = (ObjectFilter)new ObjectFilter.LessThanOrEqualsFilter(6, nameof(LessThanOrEquals));
		public static readonly ObjectFilter Contains = (ObjectFilter)new ObjectFilter.ContainsFilter(7, nameof(Contains));
		public static readonly ObjectFilter NotContains = (ObjectFilter)new ObjectFilter.NotContainsFilter(8, nameof(NotContains));
		public static readonly ObjectFilter StartsWith = (ObjectFilter)new ObjectFilter.StartsWithFilter(9, nameof(StartsWith));
		public static readonly ObjectFilter EndsWith = (ObjectFilter)new ObjectFilter.EndsWithFilter(10, nameof(EndsWith));
		public static readonly ObjectFilter IsNull = (ObjectFilter)new ObjectFilter.IsNullFilter(11, nameof(IsNull));
		public static readonly ObjectFilter IsNotNull = (ObjectFilter)new ObjectFilter.IsNotNullFilter(12, nameof(IsNotNull));

		public abstract bool ValueRequired { get; }

		public abstract bool IsNumberAllowed { get; }

		public abstract bool IsBoolAllowed { get; }

		public abstract bool IsStringAllowed { get; }

		public abstract bool IsDateTimeAllowed { get; }

		public abstract bool IsNonNullableAllowed { get; }

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		public abstract Expression<Func<TModel, bool>> GenerateExpression<TModel>(
		  string propertyName,
		  object value);

<<<<<<< HEAD
		/// <summary>
		/// Applies the embedded filter.
		/// </summary>
		/// <typeparam name="TModel">The type of the t model.</typeparam>
		/// <param name="models">The models.</param>
		/// <param name="propertyName">Name of the property.</param>
		/// <param name="value">The value.</param>
		/// <returns>IList&lt;TModel&gt;.</returns>
		public abstract IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value);

		/// <summary>
		/// Allowses the type.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
		public virtual bool AllowsType(Type type)
=======
		public bool AllowsType(Type type)
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			return Utils.IsNumber(type) && this.IsNumberAllowed ||
				   typeCode == TypeCode.Boolean && this.IsBoolAllowed ||
				   (typeCode == TypeCode.String && this.IsStringAllowed ||
				   typeCode == TypeCode.DateTime && this.IsDateTimeAllowed);
		}

<<<<<<< HEAD
		/// <summary>
		/// Initializes a new instance of the <see cref="ObjectFilter" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
		protected ObjectFilter(int id, string name)
		  : base(id, name)
		{
		}

<<<<<<< HEAD
		/// <summary>
		/// Class IsEqualsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class IsEqualsFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="IsEqualsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
		private class IsEqualsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal IsEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;
=======
				Expression expression = (Expression)parameterExpression;
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
<<<<<<< HEAD
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				UnaryExpression unaryExpression = !expression.Type.IsEnum ?
					Expression.ConvertChecked(Expression.Constant(value), expression.Type) :
					Expression.ConvertChecked(Expression.Constant(
						Convert.ToInt32(Enum.Parse(expression.Type, value.ToString()))), expression.Type);

				return Expression.Lambda<Func<TModel, bool>>(Expression.Equal(expression, unaryExpression), parameterExpression);
			}

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			/// <exception cref="NotImplementedException"></exception>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Class NotEqualsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class NotEqualsFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="NotEqualsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);

				UnaryExpression unaryExpression = !expression.Type.IsEnum ?
												  Expression.ConvertChecked(Expression.Constant(value), expression.Type) :
												  Expression.ConvertChecked(Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString()))), expression.Type);

				return Expression.Lambda<Func<TModel, bool>>(Expression.Equal(expression, unaryExpression), parameterExpression);
			}
		}

		private class NotEqualsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal NotEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;

=======
				Expression expression = (Expression)parameterExpression;
				
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
<<<<<<< HEAD
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				UnaryExpression unaryExpression = !expression.Type.IsEnum ?
					Expression.ConvertChecked(Expression.Constant(value), expression.Type) :
					Expression.ConvertChecked(Expression.Constant(
						Convert.ToInt32(Enum.Parse(expression.Type, value.ToString()))), expression.Type);

				return Expression.Lambda<Func<TModel, bool>>(Expression.NotEqual(expression, unaryExpression), parameterExpression);
			}

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			/// <exception cref="NotImplementedException"></exception>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Class GreaterThanFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class GreaterThanFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="GreaterThanFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);

				UnaryExpression unaryExpression = !expression.Type.IsEnum ? Expression.ConvertChecked(Expression.Constant(value), expression.Type) : Expression.ConvertChecked(Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString()))), expression.Type);
				return Expression.Lambda<Func<TModel, bool>>(Expression.NotEqual(expression, unaryExpression), parameterExpression);
			}
		}

		private class GreaterThanFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal GreaterThanFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;
=======
				Expression expression = (Expression)parameterExpression;
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
<<<<<<< HEAD
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);
=======
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
<<<<<<< HEAD
					ConstantExpression constantExpression = Expression.Constant(Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
=======
					ConstantExpression constantExpression = Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
					binaryExpression = Expression.GreaterThan(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.GreaterThan(expression, unaryExpression);
				}

				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
			}
<<<<<<< HEAD

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			/// <exception cref="NotImplementedException"></exception>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Class GreaterThanOrEqualsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class GreaterThanOrEqualsFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="GreaterThanOrEqualsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
		}

		private class GreaterThanOrEqualsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal GreaterThanOrEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant(Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
=======
				Expression expression = (Expression)parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
					binaryExpression = Expression.GreaterThanOrEqual(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.GreaterThanOrEqual(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
			}
<<<<<<< HEAD

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			/// <exception cref="NotImplementedException"></exception>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Class LessThanFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class LessThanFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="LessThanFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
		}

		private class LessThanFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal LessThanFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;
=======
				Expression expression = (Expression)parameterExpression;
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
<<<<<<< HEAD
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);
=======
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
<<<<<<< HEAD
					ConstantExpression constantExpression = Expression.Constant(Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
=======
					ConstantExpression constantExpression = Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
					binaryExpression = Expression.LessThan(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.LessThan(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
			}
<<<<<<< HEAD

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			/// <exception cref="NotImplementedException"></exception>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Class LessThanOrEqualsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class LessThanOrEqualsFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="LessThanOrEqualsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
		}

		private class LessThanOrEqualsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal LessThanOrEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;
=======
				Expression expression = (Expression)parameterExpression;
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
<<<<<<< HEAD
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);
=======
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
<<<<<<< HEAD
					ConstantExpression constantExpression = Expression.Constant(Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
=======
					ConstantExpression constantExpression = Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
					binaryExpression = Expression.LessThanOrEqual(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.LessThanOrEqual(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
			}
<<<<<<< HEAD

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			/// <exception cref="NotImplementedException"></exception>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Class ContainsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class ContainsFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => true;

			/// <summary>
			/// Initializes a new instance of the <see cref="ContainsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
		}

		private class ContainsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => false;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => false;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal ContainsFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;
=======
				Expression expression = (Expression)parameterExpression;
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
<<<<<<< HEAD
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				ConstantExpression valueExpression = Expression.Constant(string.Format("%{0}%", value));

				MethodInfo likeMethod = typeof(DbFunctionsExtensions).GetMethod(
					nameof(DbFunctionsExtensions.Like), BindingFlags.Public | BindingFlags.Static,
					null,
					new[] { typeof(DbFunctions), typeof(string), typeof(string) }, null);

				Expression body = Expression.Call(null,
					likeMethod, Expression.Default(typeof(DbFunctions)),
=======
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);

				ConstantExpression valueExpression = Expression.Constant((object)string.Format("%{0}%", value));

				Expression body = Expression.Call(typeof(DbFunctionsExtensions),
					nameof(DbFunctionsExtensions.Like), null, Expression.Default(typeof(DbFunctions)),
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
					expression, valueExpression);

				return Expression.Lambda<Func<TModel, bool>>(body, parameterExpression);
			}
<<<<<<< HEAD

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				var searchStrLower = value.ToLower();
				var propsToCheck = typeof(TModel).GetProperties().Where(a => a.PropertyType == typeof(string) && a.Name == propertyName && a.CanRead);

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
		}

		/// <summary>
		/// Class NotContainsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class NotContainsFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="NotContainsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
		}

		private class NotContainsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => false;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => false;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal NotContainsFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				Expression expression = Expression.Parameter(typeof(TModel), "e");
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
<<<<<<< HEAD

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				ConstantExpression constantExpression = Expression.Constant(string.Format("%{0}%", value));

				return Expression.Lambda<Func<TModel, bool>>(Expression.Call(typeof(DbFunctionsExtensions),
					nameof(DbFunctionsExtensions.Like), null, Expression.Constant(EF.Functions), expression, constantExpression));
			}

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				var searchStrLower = value.ToLower();
				var propsToCheck = typeof(TModel).GetProperties().Where(a => a.PropertyType == typeof(string) && a.Name == propertyName && a.CanRead);

				return models.Where(obj =>
				{
					foreach (PropertyInfo prop in propsToCheck)
					{
						string value = (string)prop.GetValue(obj);
						if (value != null && !value.ToLower().Contains(searchStrLower)) return true;
					}
					return false;
				}).ToList();
			}
		}

		/// <summary>
		/// Class StartsWithFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class StartsWithFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => true;

			/// <summary>
			/// Initializes a new instance of the <see cref="StartsWithFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
				
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
				
				ConstantExpression constantExpression = Expression.Constant((object)string.Format("%{0}%", value));

				return Expression.Lambda<Func<TModel, bool>>(Expression.Call(typeof(DbFunctionsExtensions), nameof(DbFunctionsExtensions.Like), null, Expression.Constant(EF.Functions), expression, constantExpression));
			}
		}

		private class StartsWithFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => false;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => false;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal StartsWithFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
<<<<<<< HEAD
				Expression expression = Expression.Parameter(typeof(TModel), "e");
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				ConstantExpression constantExpression = Expression.Constant(string.Format("{0}%", value));

				return Expression.Lambda<Func<TModel, bool>>(Expression.Call(typeof(DbFunctionsExtensions),
					nameof(DbFunctionsExtensions.Like), null, Expression.Constant(EF.Functions), expression, constantExpression));
			}

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				var searchStrLower = value.ToLower();
				var propsToCheck = typeof(TModel).GetProperties().Where(a => a.PropertyType == typeof(string) && a.Name == propertyName && a.CanRead);

				return models.Where(obj =>
				{
					foreach (PropertyInfo prop in propsToCheck)
					{
						string value = (string)prop.GetValue(obj);
						if (value != null && value.ToLower().StartsWith(searchStrLower)) return true;
					}
					return false;
				}).ToList();
			}
		}

		/// <summary>
		/// Class EndsWithFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class EndsWithFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => true;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => false;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => true;

			/// <summary>
			/// Initializes a new instance of the <see cref="EndsWithFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
				Expression expression = (Expression)Expression.Parameter(typeof(TModel), "e");
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
				
				ConstantExpression constantExpression = Expression.Constant((object)string.Format("{0}%", value));

				return Expression.Lambda<Func<TModel, bool>>(Expression.Call(typeof(DbFunctionsExtensions), nameof(DbFunctionsExtensions.Like), null, Expression.Constant(EF.Functions), expression, constantExpression));
			}
		}

		private class EndsWithFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => false;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => false;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal EndsWithFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
<<<<<<< HEAD
				Expression expression = Expression.Parameter(typeof(TModel), "e");
=======
				Expression expression = (Expression)Expression.Parameter(typeof(TModel), "e");
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
<<<<<<< HEAD
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				ConstantExpression constantExpression = Expression.Constant(string.Format("%{0}", value));

				return Expression.Lambda<Func<TModel, bool>>(Expression.Call(typeof(DbFunctionsExtensions),
					nameof(DbFunctionsExtensions.Like), null, Expression.Constant(EF.Functions), expression, constantExpression));
			}

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				var searchStrLower = value.ToLower();
				var propsToCheck = typeof(TModel).GetProperties().Where(a => a.PropertyType == typeof(string) && a.Name == propertyName && a.CanRead);

				return models.Where(obj =>
				{
					foreach (PropertyInfo prop in propsToCheck)
					{
						string value = (string)prop.GetValue(obj);
						if (value != null && value.ToLower().EndsWith(searchStrLower)) return true;
					}
					return false;
				}).ToList();
			}
		}

		/// <summary>
		/// Class IsNullFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class IsNullFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => false;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="IsNullFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);

				ConstantExpression constantExpression = Expression.Constant((object)string.Format("%{0}", value));

				return Expression.Lambda<Func<TModel, bool>>(Expression.Call(typeof(DbFunctionsExtensions), nameof(DbFunctionsExtensions.Like), null, Expression.Constant(EF.Functions), expression, constantExpression));
			}
		}

		private class IsNullFilter : ObjectFilter
		{
			public override bool ValueRequired => false;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal IsNullFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);
				UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(null), expression.Type);
				return Expression.Lambda<Func<TModel, bool>>(Expression.Equal(expression,
					unaryExpression), parameterExpression);
			}

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			/// <exception cref="NotImplementedException"></exception>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Class IsNotNullFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class IsNotNullFilter : ObjectFilter
		{
			/// <summary>
			/// Gets a value indicating whether [value required].
			/// </summary>
			/// <value><c>true</c> if [value required]; otherwise, <c>false</c>.</value>
			public override bool ValueRequired => false;

			/// <summary>
			/// Gets a value indicating whether this instance is number allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is number allowed; otherwise, <c>false</c>.</value>
			public override bool IsNumberAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is bool allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is bool allowed; otherwise, <c>false</c>.</value>
			public override bool IsBoolAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is string allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is string allowed; otherwise, <c>false</c>.</value>
			public override bool IsStringAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is date time allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is date time allowed; otherwise, <c>false</c>.</value>
			public override bool IsDateTimeAllowed => true;

			/// <summary>
			/// Gets a value indicating whether this instance is non nullable allowed.
			/// </summary>
			/// <value><c>true</c> if this instance is non nullable allowed; otherwise, <c>false</c>.</value>
			public override bool IsNonNullableAllowed => true;

			/// <summary>
			/// Gets a value indicating whether [use embedded filter].
			/// </summary>
			/// <value><c>true</c> if [use embedded filter]; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="IsNotNullFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
=======
				Expression expression = (Expression)parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
				UnaryExpression unaryExpression = Expression.ConvertChecked((Expression)Expression.Constant((object)null), expression.Type);
				return Expression.Lambda<Func<TModel, bool>>((Expression)Expression.Equal(expression, (Expression)unaryExpression), parameterExpression);
			}
		}

		private class IsNotNullFilter : ObjectFilter
		{
			public override bool ValueRequired => false;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			internal IsNotNullFilter(int id, string name)
			  : base(id, name)
			{
			}

<<<<<<< HEAD
			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
<<<<<<< HEAD
				Expression expression = parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(null), expression.Type);

				return Expression.Lambda<Func<TModel, bool>>(
					Expression.Not(Expression.Equal(expression, unaryExpression)), parameterExpression);
			}

			/// <summary>
			/// Applies the embedded filter.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="models">The models.</param>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>IList&lt;TModel&gt;.</returns>
			/// <exception cref="NotImplementedException"></exception>
			public override IList<TModel> ApplyEmbeddedFilter<TModel>(IList<TModel> models, string propertyName, string value)
			{
				throw new NotImplementedException();
=======
				Expression expression = (Expression)parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
				UnaryExpression unaryExpression = Expression.ConvertChecked((Expression)Expression.Constant((object)null), expression.Type);
				return Expression.Lambda<Func<TModel, bool>>((Expression)Expression.Not((Expression)Expression.Equal(expression, (Expression)unaryExpression)), parameterExpression);
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
			}
		}
	}
}