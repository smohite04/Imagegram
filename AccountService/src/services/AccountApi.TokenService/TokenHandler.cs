using AccountApi.Common;
using AccountApi.Contracts;
using AccountApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountApi.TokenService
{
    /// <summary>
    /// This class acts as a mediator for token related responsibilities
    /// </summary>
    public static class TokenHandler
    {
        private const double _expiryInSeconds = 3600;
        public static AuthToken Create(string userId, double expiryInSeconds = 0)
        {
            var tokenValue = Guid.NewGuid().ToString();
            var createdOn = DateTime.UtcNow;
            var expiry = expiryInSeconds == 0 ? _expiryInSeconds : expiryInSeconds;
            var expiresOn = createdOn.AddSeconds(expiry);
            var token = new AuthToken(userId)
                 .WithAuthTokenValue(tokenValue)
                 .WithCreatedOn(createdOn)
                 .WithExpiresOn(expiresOn);
            return token;
        }
        public static void ExtendExpiryByDefaultPeriod(this AuthToken authToken)
        {
           var expiresOn = authToken.ExpiresOn.AddSeconds(_expiryInSeconds);
           authToken.WithExpiresOn(expiresOn);
            
        }
        public static void IsValid(this AuthTokenEntity entity, string token)
        {
            if (entity == null)
                throw Errors.ValueDoesNotExist("token", token);

            if (entity.ExpiresOn < DateTime.UtcNow)
            {
                throw Errors.ExpiredToken(token);
            }
        }
    }
}
