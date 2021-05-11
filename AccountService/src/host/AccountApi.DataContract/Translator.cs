using System;
using System.Collections.Generic;
using System.Text;

namespace AccountApi.DataContract
{
    public static class Translator
    {
        public static AuthTokenResponse ToDataContract(this Contracts.AuthTokenResponse authToken)
        {
            return new AuthTokenResponse
            {
                Token = authToken.Token,
                CreatedOn = authToken.CreatedOn,
                ExpiresOn = authToken.ExpiresOn,
                UserId = authToken.UserId
            };
        }
    }
}
