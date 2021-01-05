using AutoMapper;
using Confitec.Domain.Dtos;
using Confitec.Domain.Repositories;
using Confitec.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Confitec.Infra.Consultation
{
    public class SchoolingConsultation : ISchoolingConsultation
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public SchoolingConsultation(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<SchoolingDto> GetAll()
        {
            var allSchooling = _context.Schooling
                .OrderBy(x => x.Id)
                .AsNoTracking();

            return _mapper.Map<List<SchoolingDto>>(allSchooling);
        }
    }
}
