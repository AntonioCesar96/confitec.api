using Confitec.Domain.Commands;
using Confitec.Domain.Entities;
using Confitec.Domain.Handlers;
using Confitec.Domain.Repositories;
using Moq;
using System;
using Xunit;

namespace Confitec.Tests.Handlers
{
    public class UpdateUserHandlerTests
    {
        private UpdateUserHandler _updateUserHandler;
        private Mock<IUserRepository> _userRepositoryMock;
        private Mock<ISchoolingRepository> _schoolingRepositoryMock;

        public UpdateUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _schoolingRepositoryMock = new Mock<ISchoolingRepository>();

            _updateUserHandler = new UpdateUserHandler(
                _userRepositoryMock.Object,
                _schoolingRepositoryMock.Object);
        }

        [Fact]
        public void Deve_atualizar_usuario_valido()
        {
            SetupSchoolingRepository(1);
            SetupUserRepository(1);
            var command = new UpdateUserCommand("Antonio", "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 1);
            command.Id = 1;

            var result = (GenericCommandResult)_updateUserHandler.Handle(command);

            Assert.True(result.Success);
        }

        [Fact]
        public void Nao_deve_atualizar_usuario_com_dados_invalidos()
        {
            SetupSchoolingRepository(1);
            SetupUserRepository(1);
            var command = new UpdateUserCommand(null, "Cesar", "ant$oniocss@gmail.com", new DateTime(1996, 10, 19), 0);
            command.Id = 1;

            var result = (GenericCommandResult)_updateUserHandler.Handle(command);

            Assert.False(result.Success);
        }

        [Fact]
        public void Nao_deve_atualizar_usuario_com_escolaridade_nao_existente_no_banco()
        {
            SetupSchoolingRepository(1);
            SetupUserRepository(1);
            var command = new UpdateUserCommand("Antonio", "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 5);
            command.Id = 1;

            var result = (GenericCommandResult)_updateUserHandler.Handle(command);

            Assert.False(result.Success);
        }

        [Fact]
        public void Nao_deve_atualizar_quando_nao_encontrar_o_usuario_no_banco()
        {
            SetupSchoolingRepository(1);
            SetupUserRepository(2);
            var command = new UpdateUserCommand("Antonio", "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 1);
            command.Id = 1;

            var result = (GenericCommandResult)_updateUserHandler.Handle(command);

            Assert.False(result.Success);
        }

        private void SetupSchoolingRepository(int schoolingId)
        {
            _schoolingRepositoryMock.Setup(p => p.GetById(schoolingId))
                .Returns(new Schooling());
        }

        private void SetupUserRepository(int userId)
        {
            _userRepositoryMock.Setup(p => p.GetById(userId))
                .Returns(new User());
        }
    }
}
