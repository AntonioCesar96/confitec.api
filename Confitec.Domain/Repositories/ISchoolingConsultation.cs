using Confitec.Domain.Dtos;
using System.Collections.Generic;

namespace Confitec.Domain.Repositories
{
    public interface ISchoolingConsultation
    {
        IEnumerable<SchoolingDto> GetAll();
    }
}
