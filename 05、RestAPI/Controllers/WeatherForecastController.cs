using Microsoft.AspNetCore.Mvc;

namespace _05_RestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<WeatherForecast>> Get()
        {
            var forecast = new List<WeatherForecast>
            {
                new WeatherForecast { name = "����", age = 18 },
                new WeatherForecast { name = "����", age = 20 }
            };
            return Ok(forecast);
        }
    }
}
