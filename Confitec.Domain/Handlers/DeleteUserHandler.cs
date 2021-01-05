using Confitec.Domain.Commands;
using Confitec.Domain.Commands.Contracts;
using Confitec.Domain.Handlers.Contracts;
using Confitec.Domain.Repositories;

namespace Confitec.Domain.Handlers
{
    public class DeleteUserHandler : IHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteUserHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(DeleteUserCommand command)
        {
            var user = _repository.GetById(command.Id);
            if (user == null)
                return GenericCommandResultFactory.CreateMessageError("Usuário não encontrado.");

            _repository.Delete(user);

            return GenericCommandResultFactory.CreateMessageSuccess("Usuário excluído.");
        }
    }
}
