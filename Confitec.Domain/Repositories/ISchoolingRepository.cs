using Confitec.Domain.Entities;

namespace Confitec.Domain.Repositories
{
    public interface ISchoolingRepository
    {
        Schooling GetById(int id);
    }
}
