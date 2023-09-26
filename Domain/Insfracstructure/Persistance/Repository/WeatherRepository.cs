using Domain.Insfracstructure.DBContext;
using Domain.Insfracstructure.Entities;
using Domain.Insfracstructure.Persistance.IRepository;

namespace Domain.Insfracstructure.Persistance.Repository
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly EFContext _context;
        public WeatherRepository(EFContext context)
        {
            _context = context;
        }

        public void Add(WeatherForecast Weather)
        {
            if (Weather != null)
            {
                Weather.Date = DateTime.Now;
                _context.Add(Weather);
                _context.SaveChanges();
            }
        }

        public IEnumerable<WeatherForecast> Delete(int Id)
        {
            try
            {
                _context.Remove(_context.Weathers.Find(Id));

                _context.SaveChanges();
            }
            catch
            {

            }
            return _context.Weathers.ToList();
        }

        public WeatherForecast Get(int Id)
        {
            return _context.Weathers.Find(Id);
        }

        public IEnumerable<WeatherForecast> GetList()
        {
            return _context.Weathers.ToList();
        }

        public IEnumerable<WeatherForecast> Update(int Id)
        {
            try
            {
                _context.Update(_context.Weathers.Find(Id));
                _context.SaveChanges();
            }
            catch
            {

            }
            return _context.Weathers.ToList();

        }
    }
}
