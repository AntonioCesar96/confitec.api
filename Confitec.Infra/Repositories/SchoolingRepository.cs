using Confitec.Domain.Entities;
using Confitec.Domain.Repositories;
using Confitec.Infra.Contexts;
using System.Linq;

namespace Confitec.Infra.Repositories
{
    public class SchoolingRepository : ISchoolingRepository
    {
        private readonly DataContext _context;

        public SchoolingRepository(DataContext context)
        {
            _context = context;
        }

        public Schooling GetById(int id)
        {
            return _context.Schooling.FirstOrDefault(x => x.Id == id);
        }
    }
}
