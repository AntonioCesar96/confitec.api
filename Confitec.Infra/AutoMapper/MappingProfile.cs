using AutoMapper;
using Confitec.Domain.Dtos;
using Confitec.Domain.Entities;

namespace Confitec.Infra.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(r => r.SchoolingDescription, o => o.MapFrom(c => c.Schooling.Description));

            CreateMap<Schooling, SchoolingDto>();
        }
    }
}
