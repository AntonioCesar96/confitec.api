using System;

namespace Confitec.Domain.Commands
{
    public class CreateUserCommand : UserCommand
    {
        public CreateUserCommand() { }

        public CreateUserCommand(
            string name,
            string lastName,
            string email,
            DateTime birthDate,
            int schoolingId)
        {
            Name = name;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            SchoolingId = schoolingId;
        }
    }
}
