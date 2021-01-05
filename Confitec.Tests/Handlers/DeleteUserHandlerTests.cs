using Confitec.Domain.Commands;
using Confitec.Domain.Entities;
using Confitec.Domain.Handlers;
using Confitec.Domain.Repositories;
using Moq;
using Xunit;

namespace Confitec.Tests.Handlers
{
    public class DeleteUserHandlerTests
    {
        private DeleteUserHandler _deleteUserHandler;
        private Mock<IUserRepository> _userRepositoryMock;

        public DeleteUserHandlerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();

            _deleteUserHandler = new DeleteUserHandler(_userRepositoryMock.Object);
        }

        [Fact]
        public void Deve_excluir_o_usuario()
        {
            SetupUserRepository(1);
            var command = new DeleteUserCommand() { Id = 1 };

            var result = (GenericCommandResult)_deleteUserHandler.Handle(command);

            Assert.True(result.Success);
        }

        [Fact]
        public void Nao_deve_excluir_quando_nao_encontrar_o_usuario_no_banco()
        {
            SetupUserRepository(2);
            var command = new DeleteUserCommand() { Id = 1 };

            var result = (GenericCommandResult)_deleteUserHandler.Handle(command);

            Assert.False(result.Success);
        }

        private void SetupUserRepository(int userId)
        {
            _userRepositoryMock.Setup(p => p.GetById(userId))
                .Returns(new User());
        }
    }
}
