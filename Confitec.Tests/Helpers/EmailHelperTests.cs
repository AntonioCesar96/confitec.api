using Confitec.Domain.Helpers;
using Xunit;

namespace Confitec.Tests.Helpers
{
    public class EmailHelperTests
    {
        [Theory]
        [InlineData("a@a.com")]
        [InlineData("a@a.com.br")]
        [InlineData("123@xyz.com")]
        [InlineData("jxxxx@linkedin.com")]
        [InlineData("phrase.without.space@example.com")]
        [InlineData("valid@email.net")]
        [InlineData("valid_@email.com.br")]
        [InlineData("_@email.com")]
        public void Deve_aceitar_email_valido(string valorValido)
        {
            var isValid = EmailHelper.Validade(valorValido);

            Assert.True(isValid);
        }

        [Theory]
        [InlineData("a@a")]
        [InlineData("a@a..com")]
        [InlineData("123@$.xyz")]
        [InlineData("'phrase with space'@example.com")]
        [InlineData("jxx@xx@linkedin.com")]
        [InlineData("valid@email$com")]
        [InlineData("valid @email.com.br")]
        [InlineData("va$lid@email.com.br")]
        [InlineData("@email.com")]
        public void Nao_deve_aceitar_email_invalido(string valorInvalido)
        {
            var isValid = EmailHelper.Validade(valorInvalido);

            Assert.False(isValid);
        }
    }
}
