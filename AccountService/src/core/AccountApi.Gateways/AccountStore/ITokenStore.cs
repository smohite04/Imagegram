using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountApi.Contracts
{
    public interface IAccountStore
    {
        Task<AccountEntity> SaveAsync(AccountEntity accountEntity);
        Task<AccountEntity> GetAsync(string id);
        Task<AccountEntity> GetByUserIdAsync(string userId);
        Task<bool> DeleteAsync(string id);
    }
}
