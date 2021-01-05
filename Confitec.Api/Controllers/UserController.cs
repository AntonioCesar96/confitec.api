using AutoMapper;
using Confitec.Domain.Commands;
using Confitec.Domain.Commands.Contracts;
using Confitec.Domain.Dtos;
using Confitec.Domain.Entities;
using Confitec.Domain.Handlers.Contracts;
using Confitec.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Confitec.Api.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        [HttpPost]
        public ICommandResult Create(
            [FromBody] CreateUserCommand command,
            [FromServices] IHandler<CreateUserCommand> handler)
        {
            return handler.Handle(command);
        }

        [HttpPut]
        public ICommandResult Update(
            [FromBody] UpdateUserCommand command,
            [FromServices] IHandler<UpdateUserCommand> handler)
        {
            return handler.Handle(command);
        }

        [HttpDelete("{id}")]
        public ICommandResult Delete(
            [FromRoute] DeleteUserCommand command,
            [FromServices] IHandler<DeleteUserCommand> handler)
        {
            return handler.Handle(command);
        }

        [HttpGet("{id}")]
        public UserDto GetById(
            int id, 
            [FromServices] IUserRepository repository,
            [FromServices] IMapper mapper)
        {
            var user = repository.GetById(id);
            return mapper.Map<UserDto>(user);
        }

        [HttpGet]
        public QueryResultDto GetAll(
            [FromQuery] FilterUserDto filter,
            [FromServices] IUserConsultation consultation)
        {
            return consultation.GetUsers(filter);
        }
    }
}
