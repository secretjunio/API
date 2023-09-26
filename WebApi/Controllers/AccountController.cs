using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using Domain.Insfracstructure.Entities;
using Domain.Insfracstructure.Persistance.IRepository;

namespace Domain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IProductRepository _productRepository;
        public static string ConvertPwdtoMD5(string strword)
        {
            MD5 md5 = MD5.Create();
            byte[] Bytes = Encoding.ASCII.GetBytes(strword);
            byte[] hash = md5.ComputeHash(Bytes);
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sBuilder.Append(hash[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
        public AccountController(IRoleRepository roleRepository, IAccountRepository accountRepository,
            IProductRepository productRepository)
        {
            _roleRepository = roleRepository;
            _accountRepository = accountRepository;
            _productRepository = productRepository;
        }
        [HttpPost]
        [Route("AddRole")]
        public void AddRole(string RoleName)
        {
            var role = new Role
            {
                RoleName = RoleName,
            };
            _roleRepository.Add(role);
        }

        [HttpGet]
        [Route("GetListRole")]
        public IEnumerable<Role> GetListRole()
        {
            return  _roleRepository.GetList();
        }
        [HttpGet]
        [Route("GetRoleById")]
        public Role GetRoleById(int Id)
        {
            return  _roleRepository.Get(Id);
        }
        [HttpDelete]
        [Route("DeleteById")]
        public void DeleteById(int Id)
        {
            _roleRepository.Delete(Id);
        }
        //-------------account--------------
        [HttpPost]
        [Route("AddAccount")]
        public void AddAccount(Account acc)
        {
            var a = _productRepository.GetList();
            var account = new Account
            {
                Email = acc.Email,
                UserName = acc.UserName,
                FirstName = acc.FirstName,
                LastName = acc.LastName,
                FullName = acc.FullName,
                IsEmailConfirmed = acc.IsEmailConfirmed,
                StatusId = 0,
                NumberPhone = acc.NumberPhone,
                Password = ConvertPwdtoMD5(acc.Password)
            };
            if (account.Email != null && account.NumberPhone != null && account != null)
            {
                _accountRepository.Add(account);
            }

        }

        [HttpGet]
        [Route("GetListAccount")]
        public IEnumerable<Account> GetListAccount()
        {
            return _accountRepository.GetList();
        }
        [HttpGet]
        [Route("GetAccountById")]
        public Account GetAccountById(int Id)
        {
            return  _accountRepository.Get(Id);
        }
        [HttpDelete]
        [Route("DeleteAccount")]
        public void DeleteAccount(int Id)
        {
            _accountRepository.Delete(Id);
        }
    }
}
