using PSC.Blazor.Components.DataTable.Code;
using PSC.Blazor.Components.DataTable.Enums;
using PSC.Blazor.Components.DataTable.EventsArgs;
using PSC.Blazor.Components.DataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using System.Linq.Expressions;
=======
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
using System.Threading.Tasks;

namespace PSC.Blazor.Examples.Data
{
<<<<<<< HEAD
	public class WeatherForecastService
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, int amount = 10)
		{
			var rng = new Random();

			return Task.FromResult(Enumerable.Range(1, amount).Select(index => new WeatherForecast
			{
				Date = startDate.AddDays(index),
				TemperatureC = rng.Next(-20, 55),
				Summary = Summaries[rng.Next(Summaries.Length)],
				MyNullableInt = rng.Next(1, 10) > 3 ? null : 1,
				Country = (Country)Enum.GetValues(typeof(Country)).GetValue(rng.Next(0, Enum.GetValues(typeof(Country)).Length)),
				UpdatedRecently = rng.Next(1, 10) > 3 ? true : false
			}).ToArray());
		}

		private WeatherForecast[]? generatedForecasts = null;
		public Task<PagedResult<WeatherForecast>> SearchForecastAsync(RequestArgs<WeatherForecast> args, int amount = 10)
		{
			PagedResult<WeatherForecast> pagedResult = null;
			Pager pager = null;

			if (generatedForecasts == null)
			{
				var rng = new Random();

				generatedForecasts = Enumerable.Range(1, amount).Select(index => new WeatherForecast
				{
					Date = DateTime.Now.AddDays(-10).AddDays(index),
					TemperatureC = rng.Next(-20, 55),
					Summary = Summaries[rng.Next(Summaries.Length)],
					MyNullableInt = rng.Next(1, 10) > 3 ? null : 1,
					Country = (Country)Enum.GetValues(typeof(Country)).GetValue(rng.Next(0, Enum.GetValues(typeof(Country)).Length)),
					UpdatedRecently = rng.Next(1, 10) > 3 ? true : false
				}).ToArray();

				pager = new Pager(pageNr: 1, pageSize: 10, sortColumn: "", SortDirection.Ascending);
			}
			else if (args == null && pager == null)
				pager = new Pager(pageNr: 1, pageSize: 10, sortColumn: "", SortDirection.Ascending); // generatedForecasts isn't cleared when leaving the server side example, so pager could be null
			else
				pager = args.Pager;

			// This is the important part
			IQueryable<WeatherForecast> result = generatedForecasts.AsQueryable();

			Expression<Func<WeatherForecast, bool>>? filterExpression = null;
			List<WeatherForecast> rsl = result.ToList();
			if (args != null)
			{
				foreach (var arg in args.AppliedFilters)
				{
					if (arg.FilterType.UseEmbeddedFilter)
						rsl = arg.FilterType.ApplyEmbeddedFilter<WeatherForecast>(rsl, arg.PropertyName, arg.FilterValue.ToString());
					else
					{
						var filterRuleExpression = arg.GenerateExpression();

						if (filterExpression == null)
							filterExpression = filterRuleExpression;
						else
							filterExpression = PredicateBuilder.And(filterExpression, filterRuleExpression);

						rsl = result.Where(filterExpression).ToList();
					}
				}
			}

			pagedResult = Utils.ApplyPaging(rsl, pager);

			return Task.FromResult(pagedResult);
		}
	}
=======
    public class WeatherForecastService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate, int amount = 10)
        {
            var rng = new Random();

            return Task.FromResult(Enumerable.Range(1, amount).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
                MyNullableInt = rng.Next(1, 10) > 3 ? (int?)null : 1,
                Country = (Country)Enum.GetValues(typeof(Country)).GetValue(rng.Next(0, Enum.GetValues(typeof(Country)).Length)),
                UpdatedRecently = rng.Next(1, 10) > 3 ? true : false
            }).ToArray());
        }

        private WeatherForecast[]? generatedForecasts = null;
        public Task<PagedResult<WeatherForecast>> SearchForecastAsync(RequestArgs<WeatherForecast> args, int amount = 10)
        {
            PagedResult<WeatherForecast> pagedResult = null;
            Pager pager = null;

            if (generatedForecasts == null)
            {
                var rng = new Random();

                generatedForecasts = Enumerable.Range(1, amount).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(-10).AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)],
                    MyNullableInt = rng.Next(1, 10) > 3 ? (int?)null : 1,
                    Country = (Country)Enum.GetValues(typeof(Country)).GetValue(rng.Next(0, Enum.GetValues(typeof(Country)).Length)),
                    UpdatedRecently = rng.Next(1, 10) > 3 ? true : false
                }).ToArray();

                pager = new Pager(pageNr: 1, pageSize: 10, sortColumn: "", SortDirection.Ascending);
            }
            else if (args == null && pager == null) pager = new Pager(pageNr: 1, pageSize: 10, sortColumn: "", SortDirection.Ascending); // generatedForecasts isn't cleared when leaving the server side example, so pager could be null
            else pager = args.Pager;

            // This is the important part
            IQueryable<WeatherForecast> result = generatedForecasts.AsQueryable();

            if (args != null) result = result.Where(args.GetFilterExpression());

            pagedResult = Utils.ApplyPaging(result, pager);

            return Task.FromResult(pagedResult);
        }
    }
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
}
