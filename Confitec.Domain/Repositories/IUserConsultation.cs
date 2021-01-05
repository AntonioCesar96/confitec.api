using Confitec.Domain.Dtos;

namespace Confitec.Domain.Repositories
{
    public interface IUserConsultation
    {
        QueryResultDto GetUsers(FilterUserDto filterUser);
    }
}
