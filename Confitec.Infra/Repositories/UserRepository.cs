using Confitec.Domain.Entities;
using Confitec.Domain.Repositories;
using Confitec.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Confitec.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public User GetById(int id)
        {
            return _context.Users
                .Include(x => x.Schooling)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
