using Microsoft.EntityFrameworkCore;
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

		public abstract Expression<Func<TModel, bool>> GenerateExpression<TModel>(
		  string propertyName,
		  object value);

		public bool AllowsType(Type type)
		{
			TypeCode typeCode = Type.GetTypeCode(type);
			return Utils.IsNumber(type) && this.IsNumberAllowed ||
				   typeCode == TypeCode.Boolean && this.IsBoolAllowed ||
				   (typeCode == TypeCode.String && this.IsStringAllowed ||
				   typeCode == TypeCode.DateTime && this.IsDateTimeAllowed);
		}

		protected ObjectFilter(int id, string name)
		  : base(id, name)
		{
		}

		private class IsEqualsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

			internal IsEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = (Expression)parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
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

			internal NotEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = (Expression)parameterExpression;
				
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
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

			internal GreaterThanFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = (Expression)parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
					binaryExpression = Expression.GreaterThan(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.GreaterThan(expression, unaryExpression);
				}

				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
			}
		}

		private class GreaterThanOrEqualsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

			internal GreaterThanOrEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = (Expression)parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
					binaryExpression = Expression.GreaterThanOrEqual(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.GreaterThanOrEqual(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
			}
		}

		private class LessThanFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

			internal LessThanFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = (Expression)parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
					binaryExpression = Expression.LessThan(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.LessThan(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
			}
		}

		private class LessThanOrEqualsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => true;

			public override bool IsBoolAllowed => true;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => true;

			public override bool IsNonNullableAllowed => true;

			internal LessThanOrEqualsFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = (Expression)parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);

				BinaryExpression binaryExpression;
				if (expression.Type.IsEnum)
				{
					ConstantExpression constantExpression = Expression.Constant((object)Convert.ToInt32(Enum.Parse(expression.Type, value.ToString())));
					binaryExpression = Expression.LessThanOrEqual(Expression.ConvertChecked(expression, typeof(int)), constantExpression);
				}
				else
				{
					UnaryExpression unaryExpression = Expression.ConvertChecked(Expression.Constant(value), expression.Type);
					binaryExpression = Expression.LessThanOrEqual(expression, unaryExpression);
				}
				return Expression.Lambda<Func<TModel, bool>>(binaryExpression, parameterExpression);
			}
		}

		private class ContainsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => false;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => false;

			public override bool IsNonNullableAllowed => true;

			internal ContainsFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = (Expression)parameterExpression;

				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);

				ConstantExpression valueExpression = Expression.Constant((object)string.Format("%{0}%", value));

				Expression body = Expression.Call(typeof(DbFunctionsExtensions),
					nameof(DbFunctionsExtensions.Like), null, Expression.Default(typeof(DbFunctions)),
					expression, valueExpression);

				return Expression.Lambda<Func<TModel, bool>>(body, parameterExpression);
			}
		}

		private class NotContainsFilter : ObjectFilter
		{
			public override bool ValueRequired => true;

			public override bool IsNumberAllowed => false;

			public override bool IsBoolAllowed => false;

			public override bool IsStringAllowed => true;

			public override bool IsDateTimeAllowed => false;

			public override bool IsNonNullableAllowed => true;

			internal NotContainsFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				Expression expression = Expression.Parameter(typeof(TModel), "e");
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				
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

			internal StartsWithFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
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

			internal EndsWithFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				Expression expression = (Expression)Expression.Parameter(typeof(TModel), "e");
				string str = propertyName;
				char[] chArray = new char[1] { '.' };

				foreach (string propertyOrFieldName in str.Split(chArray))
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

			internal IsNullFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
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

			internal IsNotNullFilter(int id, string name)
			  : base(id, name)
			{
			}

			public override Expression<Func<TModel, bool>> GenerateExpression<TModel>(
			  string propertyName,
			  object value)
			{
				ParameterExpression parameterExpression = Expression.Parameter(typeof(TModel), "e");
				Expression expression = (Expression)parameterExpression;
				string str = propertyName;
				char[] chArray = new char[1] { '.' };
				foreach (string propertyOrFieldName in str.Split(chArray))
					expression = (Expression)Expression.PropertyOrField(expression, propertyOrFieldName);
				UnaryExpression unaryExpression = Expression.ConvertChecked((Expression)Expression.Constant((object)null), expression.Type);
				return Expression.Lambda<Func<TModel, bool>>((Expression)Expression.Not((Expression)Expression.Equal(expression, (Expression)unaryExpression)), parameterExpression);
			}
		}
	}
}