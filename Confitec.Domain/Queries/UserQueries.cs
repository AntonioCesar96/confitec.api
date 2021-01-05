using Confitec.Domain.Dtos;
using Confitec.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace Confitec.Domain.Queries
{
    public static class UserQueries
    {
        public static Expression<Func<User, bool>> GetAll(FilterUserDto filterUser)
        {
            return x =>
                (string.IsNullOrEmpty(filterUser.Name) || x.Name.ToLower().Contains(filterUser.Name.Trim().ToLower())) &&
                (string.IsNullOrEmpty(filterUser.LastName) || x.LastName.ToLower().Contains(filterUser.LastName.Trim().ToLower())) &&
                (string.IsNullOrEmpty(filterUser.Email) || x.Email.ToLower().Contains(filterUser.Email.Trim().ToLower())) &&
                (!filterUser.BirthDate.HasValue || x.BirthDate.Date == filterUser.BirthDate.Value.Date) &&
                (!filterUser.SchoolingId.HasValue || x.SchoolingId == filterUser.SchoolingId.Value);
        }
    }
}
