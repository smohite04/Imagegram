using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Contracts
{
    public interface ITokenStore
    {
        Task SaveAsync(AuthTokenEntity authTokenEntity);
        Task<AuthTokenEntity> GetAsync(string token);      
        Task<bool> DeleteAsync(string token);
    }
}
