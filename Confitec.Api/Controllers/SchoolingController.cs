using Confitec.Domain.Dtos;
using Confitec.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Confitec.Api.Controllers
{
    [ApiController]
    [Route("api/schooling")]
    public class SchoolingController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<SchoolingDto> GetAll([FromServices] ISchoolingConsultation consultation)
        {
            return consultation.GetAll();
        }
    }
}
