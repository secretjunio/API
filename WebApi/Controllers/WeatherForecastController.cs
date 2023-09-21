using Microsoft.AspNetCore.Mvc;
using WebApi.Insfracstructure.DBContext;
using WebApi.Insfracstructure.Entities;
using WebApi.Insfracstructure.Persistance.IRepository;
using WebApi.Insfracstructure.Persistance.Repository;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherForecastController(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _weatherRepository.GetList();
        }
        [HttpPost]
        [Route("Post")]
        public IEnumerable<WeatherForecast> Post(WeatherForecast Weather)
        {
            var tmp = new WeatherForecast
            {
                Date = Weather.Date,
                Summary = Weather.Summary,
                TemperatureC = Weather.TemperatureC
            };
            _weatherRepository.Add(tmp);
            return _weatherRepository.GetList();
        }
    }
}