using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserPostApi.Contracts;

namespace UserPostApi.Service.Mock
{
    /// <summary>
    /// mock adapter implementation
    /// </summary>
    public class MockTokenAuthenticationAdapter : IAccountAuthenticationAdapter
    {
        public async Task<TokenValidationResponse> ValidateTokenAsync(string token)
        {
            if (token.Contains("mock") == true)
            {
                return new TokenValidationResponse
                {
                    AssociatedUserId = "user1"
                };
            }
            else
                return null;
        }
    }
}
