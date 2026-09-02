using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ERP.Api.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    [SwaggerTag("Weather")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries =
         [
             "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
         ];

        [HttpGet]
        [SwaggerOperation(Summary = "Get weather forecast", Description = "Returns a list of weather forecasts")]
        [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 11).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    /// <summary>
    /// Weather forecast model
    /// </summary>
    public class WeatherForecast
    {
        /// <summary>Date of forecast</summary>
        public DateOnly Date { get; set; }

        /// <summary>Temperature in Celsius</summary>
        public int TemperatureC { get; set; }

        /// <summary>Temperature in Fahrenheit</summary>
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        /// <summary>Weather summary</summary>
        public string Summary { get; set; }
    }
}
