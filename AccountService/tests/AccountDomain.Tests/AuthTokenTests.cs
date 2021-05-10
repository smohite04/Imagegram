using FluentAssertions;
using System;
using Xunit;

namespace AccountDomain.Tests
{
    public class AuthTokenTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(100)]
        public void AuthToken_Should_Generate_Token_when_Valid_Input_Is_Provided(double value)
        {
            var userId = "test_account";
            var token = "test token";
            AccountApi.Domain.AuthToken authToken = null;
            double expiry = value == 0 ? 60 : value;
            authToken = new AccountApi.Domain.AuthToken(userId);
            authToken.UserId.Should().BeEquivalentTo(userId);
            authToken.WithAuthTokenValue(token);
            authToken.Value.Should().BeEquivalentTo(token);
            authToken.CreatedOn.TimeOfDay.Should().BeLessThan(DateTime.UtcNow.TimeOfDay);
            var data = (authToken.ExpiresOn - authToken.CreatedOn).TotalSeconds; 
        }
        [Theory]
        [InlineData(null)]
        [InlineData("")] //"" stands for emtpy
        [InlineData(" ")] //whitespace
        public void AuthToken_Should_Throw_Exception_When_Invalid_Data_Provided(string id)
        {
            Func<AccountApi.Domain.AuthToken> authToken = ()=> new AccountApi.Domain.AuthToken(id);
            authToken.Should().Throw<ArgumentException>();
        }
        [Fact]
        public void AuthToken_WithCreateOn_WithExpiresOn_Should_Assign_Dates_When_Valid()
        {
            var authToken = new AccountApi.Domain.AuthToken("test");
            authToken.WithCreatedOn(DateTime.UtcNow);
            authToken.CreatedOn.TimeOfDay.Should().BeLessThan(DateTime.UtcNow.TimeOfDay);
            authToken.WithExpiresOn(DateTime.UtcNow.AddDays(1));
            authToken.CreatedOn.TimeOfDay.Should().BeLessThan(DateTime.UtcNow.TimeOfDay);
            authToken.ExpiresOn.TimeOfDay.Should().BeLessThan(DateTime.UtcNow.TimeOfDay);
        }
        [Fact]
        public void AuthToken_WithExpiresOn_Should_Throw_Exception_When_Invalid()
        {
            var authToken = new AccountApi.Domain.AuthToken("test");
            authToken.WithCreatedOn(DateTime.UtcNow);
            Func<AccountApi.Domain.AuthToken> func = () => authToken.WithExpiresOn(DateTime.UtcNow.AddDays(-1));
            func.Should().Throw<ArgumentException>();
        }
    }
}
