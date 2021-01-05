using System;

namespace Confitec.Domain.Commands
{
    public class UpdateUserCommand : UserCommand
    {
        public int Id { get; set; }

        public UpdateUserCommand() { }

        public UpdateUserCommand(
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
