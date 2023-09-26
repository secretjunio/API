using Domain.Insfracstructure.Entities;

namespace Domain.Insfracstructure.Persistance.IRepository
{
    public interface IWeatherRepository
    {
        public  void Add(WeatherForecast Weather);
        public  WeatherForecast Get(int Id);
        public  IEnumerable<WeatherForecast> GetList();
        public  IEnumerable<WeatherForecast> Delete(int Id);
        public  IEnumerable<WeatherForecast> Update(int Id);
    }
    public  interface IProductRepository
    {
        public Enum Add(Product p);
        public Product Get(int Id);
        public IEnumerable<Product> GetList();
        public Enum Delete(int Id);
        public Enum Update(Product p);
    }
    public interface IRoleRepository
    {
        public void Add(Role p);
        public Role Get(int Id);
        public IEnumerable<Role> GetList();
        public void Delete(int Id);
        public void Update(Role r);
    }
    public interface IAccountRepository
    {
        public  bool Add(Account p);
        public Account Get(int AccountId);
        public IEnumerable<Account> GetList();
        public void Delete(int AccountId);
        public void Update(Account acc);
    }
}
