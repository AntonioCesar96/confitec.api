using Confitec.Domain.Commands;
using Confitec.Domain.Commands.Contracts;
using Confitec.Domain.Entities;
using Confitec.Domain.Handlers.Contracts;
using Confitec.Domain.Repositories;
using Confitec.Domain.Validators;

namespace Confitec.Domain.Handlers
{
    public class CreateUserHandler : IHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly ISchoolingRepository _schoolingRepository;

        public CreateUserHandler(
            IUserRepository repository,
            ISchoolingRepository schoolingRepository)
        {
            _repository = repository;
            _schoolingRepository = schoolingRepository;
        }

        public ICommandResult Handle(CreateUserCommand command)
        {
            var validator = new UserValidator(command);
            if (!validator.ValidateCommand())
                return GenericCommandResultFactory.CreateMessageError(validator.GetErrorMessages());

            var schooling = _schoolingRepository.GetById(command.SchoolingId);
            if (schooling == null)
                return GenericCommandResultFactory.CreateMessageError("Escolaridade não encontrada.");

            var user = CreateUser(command);

            _repository.Create(user);

            return GenericCommandResultFactory.CreateMessageSuccess("Usuário salvo.");
        }

        private User CreateUser(CreateUserCommand command)
        {
            return new User(command.Name, command.LastName, command.Email, command.BirthDate, command.SchoolingId);
        }
    }
}
