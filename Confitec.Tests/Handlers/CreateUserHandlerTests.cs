using Confitec.Domain.Commands;
using Confitec.Domain.Entities;
using Confitec.Domain.Handlers;
using Confitec.Domain.Repositories;
using Moq;
using System;
using Xunit;

namespace Confitec.Tests.Handlers
{
    public class CreateUserHandlerTests
    {
        private CreateUserHandler _createUserHandler;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ISchoolingRepository> _schoolingRepositoryMock;

        public CreateUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _schoolingRepositoryMock = new Mock<ISchoolingRepository>();

            _createUserHandler = new CreateUserHandler(
                _userRepositoryMock.Object,
                _schoolingRepositoryMock.Object);
        }

        [Fact]
        public void Deve_salvar_usuario_valido()
        {
            SetupSchoolingRepository(1);
            var command = new CreateUserCommand("Antonio", "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 1);

            var result = (GenericCommandResult)_createUserHandler.Handle(command);

            Assert.True(result.Success);
        }

        [Fact]
        public void Nao_deve_salvar_usuario_com_dados_invalidos()
        {
            SetupSchoolingRepository(1);
            var command = new CreateUserCommand(null, "Cesar", "ant$oniocss@gmail.com", new DateTime(1996, 10, 19), 0);

            var result = (GenericCommandResult)_createUserHandler.Handle(command);

            Assert.False(result.Success);
        }

        [Fact]
        public void Nao_deve_salvar_usuario_com_escolaridade_nao_existente_no_banco()
        {
            SetupSchoolingRepository(1);
            var command = new CreateUserCommand("Antonio", "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 5);

            var result = (GenericCommandResult)_createUserHandler.Handle(command);

            Assert.False(result.Success);
        }

        private void SetupSchoolingRepository(int schoolingId)
        {
            _schoolingRepositoryMock.Setup(p => p.GetById(schoolingId))
                .Returns(new Schooling());
        }
    }
}
