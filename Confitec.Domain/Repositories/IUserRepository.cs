using Confitec.Domain.Dtos;
using Confitec.Domain.Entities;
using System.Collections.Generic;

namespace Confitec.Domain.Repositories
{
    public interface IUserRepository
    {
        void Create(User user);
        void Update(User user);
        void Delete(User user);
        User GetById(int id);
    }
}
