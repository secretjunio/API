using System.ComponentModel.DataAnnotations;

namespace WebApi.Insfracstructure.Entities
{
    public class WeatherForecast
    {
        [Key]
        public int WeatherForecastId { get; set; }
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF { 
            get {
                return (32 + (int)(TemperatureC / 0.5556));
             } 
        }

        public string? Summary { get; set; }
    }
}