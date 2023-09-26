using System.Runtime.CompilerServices;
using Domain.Insfracstructure.DBContext;
using Domain.Insfracstructure.Entities;
using Domain.Insfracstructure.Persistance.IRepository;

namespace Domain.Insfracstructure.Persistance.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly EFContext _context;
        public RoleRepository(EFContext context)
        {
            _context = context;
        }

        public void Add(Role r)
        {
            if(r != null)
            {
                _context.Roles.Add(r);
            }
            _context.SaveChanges();
        }

        public void Delete(int Id)
        {
            var r = _context.Roles.Find(Id);
            if (r != null)
            {
                _context.Roles.Remove(r);
                _context.SaveChanges();
            }
        }

        public Role Get(int Id)
        {
            return _context.Roles.Find(Id);
        }

        public IEnumerable<Role> GetList()
        {
            return _context.Roles.ToList();
        }

        public void Update(Role r)
        {
            var role = _context.Roles.Find(r.RoleId);
            if(role != null)
            {
                _context.Roles.Update(role);
                _context.SaveChanges();
            }
        }
    }
}
