using System;
<<<<<<< HEAD

namespace PSC.Blazor.Examples.Data
{
	public class WeatherForecast
	{
		public DateTime Date { get; set; }

		public int TemperatureC { get; set; }

		public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

		public int? MyNullableInt { get; set; }

		public string Summary { get; set; }

		public Country Country { get; set; }

		public bool UpdatedRecently { get; set; }
	}
=======
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSC.Blazor.Examples.Data
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public int? MyNullableInt { get; set; }

        public string Summary { get; set; }

        public Country Country { get; set; }

        public bool UpdatedRecently { get; set; }
    }
>>>>>>> 8067c1cc92c53e34d87ef71bf5c8fe928812459e
}