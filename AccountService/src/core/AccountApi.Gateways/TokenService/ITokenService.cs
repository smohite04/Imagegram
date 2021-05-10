using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Contracts
{
    public interface ITokenService
    {
        Task<AuthTokenResponse> ValidateAndRefreshAsync(string token);
        Task<AuthTokenResponse> CreateAsync(string userId);
        Task DeleteAsync(string token);
    }
}
