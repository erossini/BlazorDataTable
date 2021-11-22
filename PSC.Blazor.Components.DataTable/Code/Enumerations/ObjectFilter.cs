// ***********************************************************************
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
		/// Comparison operator
		/// </summary>
		public abstract string ComparisonOperator { get; }

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
		public abstract Expression<Func<TModel, bool>> GenerateExpression<TModel>(
		  string propertyName,
		  object value);

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
		/// <returns><c>true</c> if the Type is allowed, <c>false</c> otherwise.</returns>
		public virtual bool AllowsType(Type type)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			return Utils.IsNumber(type) && this.IsNumberAllowed ||
				   typeCode == TypeCode.Boolean && this.IsBoolAllowed ||
				   (typeCode == TypeCode.String && this.IsStringAllowed ||
				   typeCode == TypeCode.DateTime && this.IsDateTimeAllowed);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ObjectFilter" /> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="name">The name.</param>
		protected ObjectFilter(int id, string name)
		  : base(id, name)
		{
		}

		/// <summary>
		/// Class IsEqualsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class IsEqualsFilter : ObjectFilter
		{
			/// <summary>
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "==";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="IsEqualsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal IsEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
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
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "!=";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="NotEqualsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal NotEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
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
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => ">";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="GreaterThanFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal GreaterThanFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant(Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
					binaryExpression = Expression.GreaterThan(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.GreaterThan(expression, unaryExpression);
				}

				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
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
		/// Class GreaterThanOrEqualsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class GreaterThanOrEqualsFilter : ObjectFilter
		{
			/// <summary>
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => ">=";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="GreaterThanOrEqualsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal GreaterThanOrEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant(Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
					binaryExpression = Expression.GreaterThanOrEqual(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.GreaterThanOrEqual(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
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
		/// Class LessThanFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class LessThanFilter : ObjectFilter
		{
			/// <summary>
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "<";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="LessThanFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal LessThanFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant(Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
					binaryExpression = Expression.LessThan(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.LessThan(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
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
		/// Class LessThanOrEqualsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class LessThanOrEqualsFilter : ObjectFilter
		{
			/// <summary>
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "<=";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="LessThanOrEqualsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal LessThanOrEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant(Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
					binaryExpression = Expression.LessThanOrEqual(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.LessThanOrEqual(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
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
		/// Class ContainsFilter.
		/// Implements the <see cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		/// </summary>
		/// <seealso cref="PSC.Blazor.Components.DataTable.Code.Enumerations.ObjectFilter" />
		private class ContainsFilter : ObjectFilter
		{
			/// <summary>
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "Contains";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => true;

			/// <summary>
			/// Initializes a new instance of the <see cref="ContainsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal ContainsFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = Expression.PropertyOrField(expression, propertyOrFieldName);

				ConstantExpression valueExpression = Expression.Constant(string.Format("%{0}%", value));

				MethodInfo likeMethod = typeof(DbFunctionsExtensions).GetMethod(
					nameof(DbFunctionsExtensions.Like), BindingFlags.Public | BindingFlags.Static,
					null,
					new[] { typeof(DbFunctions), typeof(string), typeof(string) }, null);

				Expression body = Expression.Call(null,
					likeMethod, Expression.Default(typeof(DbFunctions)),
					expression, valueExpression);

				return Expression.Lambda<Func<TModel, bool>>(body, parameterExpression);
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
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "Not Contains";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="NotContainsFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal NotContainsFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				Expression expression = Expression.Parameter(typeof(TModel), "e");
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

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
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "StartsWith";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => true;

			/// <summary>
			/// Initializes a new instance of the <see cref="StartsWithFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal StartsWithFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
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
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "EndsWith";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => true;

			/// <summary>
			/// Initializes a new instance of the <see cref="EndsWithFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal EndsWithFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				Expression expression = Expression.Parameter(typeof(TModel), "e");
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
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
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "IsNull";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="IsNullFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal IsNullFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
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
			/// Comparison operator
			/// </summary>
			public override string ComparisonOperator => "Is Not Null";

			/// <summary>
			/// Gets a value indicating whether the value is required.
			/// </summary>
			/// <value><c>true</c> if the value is specified; otherwise, <c>false</c>.</value>
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
			/// Gets a value indicating whether it is recommended to use embedded an filter.
			/// </summary>
			/// <value><c>true</c> if using embedded filter is recommended; otherwise, <c>false</c>.</value>
			public override bool UseEmbeddedFilter => false;

			/// <summary>
			/// Initializes a new instance of the <see cref="IsNotNullFilter" /> class.
			/// </summary>
			/// <param name="id">The identifier.</param>
			/// <param name="name">The name.</param>
			internal IsNotNullFilter(int id, string name)
			  : base(id, name)
			{
			}

			/// <summary>
			/// Generates the expression.
			/// </summary>
			/// <typeparam name="TModel">The type of the t model.</typeparam>
			/// <param name="propertyName">Name of the property.</param>
			/// <param name="value">The value.</param>
			/// <returns>Expression&lt;Func&lt;TModel, System.Boolean&gt;&gt;.</returns>
			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
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
			}
		}
	}
}