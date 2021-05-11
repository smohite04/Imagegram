using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Contracts
{
    public interface IAccountService
    {
       Task<AccountResponse> CreateAsync(AccountRequest accountRequest);
       Task<string> DeleteInitAsync(string accountId);
       Task<AccountDeletionResponse> DeleteStatusAsync(string sessionId);
    }
}
