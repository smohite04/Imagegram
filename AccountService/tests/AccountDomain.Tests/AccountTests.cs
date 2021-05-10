using FluentAssertions;
using System;
using Xunit;

namespace AccountDomain.Tests
{
    public class AccountTests
    {
        [Fact]
        public void Account_Should_Be_Created_When_Id_Is_Provided()
        {
            var id = "test_account";
            var name = "test name";
            var account = new AccountApi.Domain.Account(id,name);
            account.Should().NotBeNull();
            account.Id.Should().BeEquivalentTo(id);
            account.Name.Should().BeEquivalentTo(name);
        }
        [Theory]
        [InlineData(null, null)]
        [InlineData("",null)] //"" stands for emtpy
        [InlineData(" ", null)] //whitespace
        [InlineData(" ", " ")]
        public void Account_Should_Throw_Exception_When_Invalid_Id_Is_Provided(string id, string name)
        {
            Func<AccountApi.Domain.Account> account = ()=> new AccountApi.Domain.Account(id, name);
            account.Should().Throw<ArgumentException>();
        }
    }
}
