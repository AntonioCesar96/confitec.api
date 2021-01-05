using Confitec.Domain.Dtos;
using Confitec.Domain.Entities;
using Confitec.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Confitec.Tests.QueriesTests
{
    public class UserQueriesTests
    {
        [Fact]
        public void Deve_retornar_todos_usuarios()
        {
            var users = CreateListUser();
            var filter = new FilterUserDto();

            var result = users.AsQueryable().Where(UserQueries.GetAll(filter));

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public void Deve_retornar_usuarios_filtrados_por_nome()
        {
            var users = CreateListUser();
            var filter = new FilterUserDto() { Name = " Antonio " };

            var result = users.AsQueryable().Where(UserQueries.GetAll(filter));

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void Deve_retornar_usuarios_filtrados_por_sobrenome()
        {
            var users = CreateListUser();
            var filter = new FilterUserDto() { LastName = " Souza" };

            var result = users.AsQueryable().Where(UserQueries.GetAll(filter));

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void Deve_retornar_usuarios_filtrados_por_email()
        {
            var users = CreateListUser();
            var filter = new FilterUserDto() { Email = "antoniocss@gmail.com " };

            var result = users.AsQueryable().Where(UserQueries.GetAll(filter));

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void Deve_retornar_usuarios_filtrados_por_data_nascimento()
        {
            var users = CreateListUser();
            var filter = new FilterUserDto() { BirthDate = new DateTime(2000, 12, 1) };

            var result = users.AsQueryable().Where(UserQueries.GetAll(filter));

            Assert.Equal(1, result.Count());
        }

        [Fact]
        public void Deve_retornar_usuarios_filtrados_por_escolaridade()
        {
            var users = CreateListUser();
            var filter = new FilterUserDto() { SchoolingId = 2 };

            var result = users.AsQueryable().Where(UserQueries.GetAll(filter));

            Assert.Equal(2, result.Count());
        }

        private List<User> CreateListUser()
        {
            List<User> users = new List<User>();
            users.Add(new User("Antonio", "Cesar", "antoniocss@gmail.com", new DateTime(1996, 10, 19), 1));
            users.Add(new User("Lucas", "Souza", "lucas@gmail.com", new DateTime(2000, 12, 1), 2));
            users.Add(new User("Augusto", "Souza", "augusto@gmail.com", new DateTime(1976, 5, 02), 2));
            users.Add(new User("Zuleide", "Souza", "zuleide@gmail.com", new DateTime(1950, 2, 2), 4));
            return users;
        }
    }
}
