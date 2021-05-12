using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UserPostApi.Contracts
{
    /// <summary>
    /// Account aunthentication to connect with the token api for token validation
    /// On successful response, it will return the associated user id with the token.
    /// </summary>
    public interface IAccountAuthenticationAdapter
    {
        Task<TokenValidationResponse> ValidateTokenAsync(string token);
    }
}
