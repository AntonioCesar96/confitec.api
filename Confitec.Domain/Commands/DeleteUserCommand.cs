using Confitec.Domain.Commands.Contracts;

namespace Confitec.Domain.Commands
{
    public class DeleteUserCommand : ICommand
    {
        public int Id { get; set; }
    }
}
