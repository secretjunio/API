using WebApi.BaseEnum;
using WebApi.Insfracstructure.DBContext;
using WebApi.Insfracstructure.Entities;
using WebApi.Insfracstructure.Persistance.IRepository;

namespace WebApi.Insfracstructure.Persistance.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly EFContext _context;
        public ProductRepository(EFContext context)
        {
            _context = context;
        }

        public Enum Add(Product p)
        {
            var tmp = _context.Products.FirstOrDefault(x => x.Name == p.Name);
            if (tmp == null)
            {
                try
                {
                    _context.Products.Add(p);
                    _context.SaveChanges();
                    return EnumSql.SuccessWithInsert;
                }
                catch
                {
                    return EnumSql.Error;//error
                }

            }
            else
            {
                return EnumSql.RecordExist;//Exist
            }
        }

        public Enum Delete(int Id)
        {
            var tmp = _context.Products.Find(Id);
            if (tmp != null)
            {
                try
                {
                    _context.Products.Remove(tmp);
                    _context.SaveChanges();
                    return EnumSql.SuccessWithDelete;
                }
                catch
                {
                    return EnumSql.Error;
                }
            }
            else
            {
                return EnumSql.RecordNotExist;
            }
        }

        public Product Get(int Id)
        {
            return _context.Products.Find(Id);
        }

        public IEnumerable<Product> GetList()
        {
            return _context.Products.ToList();
        }

        public Enum Update(Product p)
        {
            var tmp = _context.Products.Find(p.ProductId);
            if (tmp != null)
            {
                try
                {
                    _context.Products.Update(p);
                    _context.SaveChanges();
                    return EnumSql.SuccessWithUpdate;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return EnumSql.Error;
                }
            }
            else
            {
                return EnumSql.RecordNotExist;
            }
        }
    }
}
