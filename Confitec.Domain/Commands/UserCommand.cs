using Confitec.Domain.Commands.Contracts;
using System;

namespace Confitec.Domain.Commands
{
    public abstract class UserCommand : ICommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public int SchoolingId { get; set; }
    }
}
