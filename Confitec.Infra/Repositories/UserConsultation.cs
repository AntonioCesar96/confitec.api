using AutoMapper;
using Confitec.Domain.Dtos;
using Confitec.Domain.Queries;
using Confitec.Domain.Repositories;
using Confitec.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Confitec.Infra.Consultation
{
    public class UserConsultation : IUserConsultation
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public UserConsultation(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public QueryResultDto GetUsers(FilterUserDto filterUser)
        {
            var allUsers = _context.Users
                .Include(x => x.Schooling)
                .Where(UserQueries.GetAll(filterUser))
                .AsNoTracking();

            var users = allUsers.OrderBy(x => x.Id)
                .Skip(filterUser.CountSkip)
                .Take(filterUser.QuantityPerPage)
                .AsNoTracking();

            var result = new QueryResultDto();
            result.Page = filterUser.Page;
            result.QuantityPerPage = filterUser.QuantityPerPage;
            result.NumberOfRecords = allUsers.Count();
            result.List = _mapper.Map<List<UserDto>>(users);

            return result;
        }
    }
}
