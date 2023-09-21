using System.Linq;
using System.Security.Cryptography;
using System.Text;
using WebApi.BaseEnum;
using WebApi.Insfracstructure.DBContext;
using WebApi.Insfracstructure.Entities;
using WebApi.Insfracstructure.Persistance.IRepository;

namespace WebApi.Insfracstructure.Persistance.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly EFContext _context;
        public AccountRepository(EFContext context)
        {
            _context = context;
        }
        public bool Add(Account acc)
        {
            var a = new Account
            {
                UserName = acc.UserName,
                Email = acc.Email,
                NumberPhone = acc.NumberPhone,
                Password = acc.Password,
                FirstName = acc.FirstName,
                LastName = acc.LastName,
                FullName = acc.FullName,
                StatusId = 0,
                IsEmailConfirmed = false

            };
            if (a.Email != null && a != null)
            {
                _context.Accounts.Add(a);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async void Delete(int AccountId)
        {
            var a = _context.Accounts.Find(AccountId);
            if (a != null)
            {
                _context.Accounts.Remove(a);
                _context.SaveChanges();
            }
        }

        public Account Get(int AccountId)
        {
            return _context.Accounts.Find(AccountId);
        }
        public IEnumerable<Account> GetList()
        {
            var result = _context.Accounts.ToList();
            return result;

        }

        public void Update(Account acc)
        {
            var a = _context.Accounts.Find(acc.AccountId);
            if (a != null)
            {
                _context.Accounts.Update(acc);
                _context.SaveChanges();
            }
        }

      

       
    }
}
