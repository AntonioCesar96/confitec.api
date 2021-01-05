using Confitec.Domain.Commands;
using Confitec.Domain.Validators;
using System;
using System.Linq;
using Xunit;

namespace Confitec.Tests.Validators
{
    public class UserValidatorTests
    {
        [Fact]
        public void Deve_retornar_comando_valido()
        {
            var command = new CreateUserCommand("Antonio", "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 1);
            var validator = new UserValidator(command);

            var isValid = validator.ValidateCommand();

            Assert.True(isValid);
        }

        [Fact]
        public void Deve_retornar_comando_com_nome_invalido()
        {
            var command = new CreateUserCommand(null, "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 1);
            var validator = new UserValidator(command);

            var isValid = validator.ValidateCommand();
            var errorMessages = validator.GetErrorMessages();

            Assert.False(isValid);
            Assert.Equal(1, errorMessages.Count());
        }

        [Fact]
        public void Deve_retornar_comando_com_email_invalido()
        {
            var command = new CreateUserCommand("Antonio", "Cesar", "antonio$css@gmail.com", new DateTime(1996, 10, 19), 1);
            var validator = new UserValidator(command);

            var isValid = validator.ValidateCommand();
            var errorMessages = validator.GetErrorMessages();

            Assert.False(isValid);
            Assert.Equal(1, errorMessages.Count());
        }

        [Fact]
        public void Deve_retornar_comando_com_data_de_nascimento_invalido()
        {
            var command = new CreateUserCommand("Antonio", "Cesar", "antoniocss@gmail.com", DateTime.Now.AddDays(1), 1);
            var validator = new UserValidator(command);

            var isValid = validator.ValidateCommand();
            var errorMessages = validator.GetErrorMessages();

            Assert.False(isValid);
            Assert.Equal(1, errorMessages.Count());
        }

        [Fact]
        public void Deve_retornar_comando_com_escolaridade_invalida()
        {
            var command = new CreateUserCommand("Antonio", "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 0);
            var validator = new UserValidator(command);

            var isValid = validator.ValidateCommand();
            var errorMessages = validator.GetErrorMessages();

            Assert.False(isValid);
            Assert.Equal(1, errorMessages.Count());
        }
    }
}
