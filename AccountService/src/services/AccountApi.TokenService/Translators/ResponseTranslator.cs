using AccountApi.Contracts;
using AccountApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountApi.TokenService
{
    public static class Translator
    {
        public static AuthTokenResponse ToContract(this AuthToken authToken)
        {
            return new AuthTokenResponse
            {
                Token = authToken.Value,
                CreatedOn = authToken.CreatedOn,
                ExpiresOn = authToken.ExpiresOn,
                UserId = authToken.UserId
            };
        }
        public static AuthTokenEntity ToEntity(this AuthToken authToken)
        {
            return new AuthTokenEntity
            {
                Token = authToken.Value,
                CreatedOn = authToken.CreatedOn,
                ExpiresOn = authToken.ExpiresOn,
                UserId = authToken.UserId
            };
        }
        public static AuthToken ToDomainModel(this AuthTokenEntity authTokenEntity)
        {
            return new AuthToken(authTokenEntity.UserId)
                       .WithAuthTokenValue(authTokenEntity.Token)
                       .WithCreatedOn(authTokenEntity.CreatedOn)
                       .WithExpiresOn(authTokenEntity.ExpiresOn);
        }
    }
}
