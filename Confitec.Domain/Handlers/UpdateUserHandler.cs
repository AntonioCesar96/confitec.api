using Confitec.Domain.Commands;
using Confitec.Domain.Commands.Contracts;
using Confitec.Domain.Entities;
using Confitec.Domain.Handlers.Contracts;
using Confitec.Domain.Repositories;
using Confitec.Domain.Validators;

namespace Confitec.Domain.Handlers
{
    public class UpdateUserHandler : IHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly ISchoolingRepository _schoolingRepository;

        public UpdateUserHandler(
            IUserRepository repository,
            ISchoolingRepository schoolingRepository)
        {
            _repository = repository;
            _schoolingRepository = schoolingRepository;
        }

        public ICommandResult Handle(UpdateUserCommand command)
        {
            var validator = new UserValidator(command);
            if (!validator.ValidateCommand())
                return GenericCommandResultFactory.CreateMessageError(validator.GetErrorMessages());

            var schooling = _schoolingRepository.GetById(command.SchoolingId);
            if (schooling == null)
                return GenericCommandResultFactory.CreateMessageError("Escolaridade não encontrada.");

            var user = _repository.GetById(command.Id);
            if (user == null)
                return GenericCommandResultFactory.CreateMessageError("Usuário não encontrado.");

            UpdateUser(user, command);

            _repository.Update(user);

            return GenericCommandResultFactory.CreateMessageSuccess("Usuário atualizado.");
        }

        private void UpdateUser(User user, UpdateUserCommand command)
        {
            user.UpdateName(command.Name);
            user.UpdateLastName(command.LastName);
            user.UpdateEmail(command.Email);
            user.UpdateBirthDate(command.BirthDate);
            user.UpdateSchooling(command.SchoolingId);
        }
    }
}
