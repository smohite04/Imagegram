using AccountApi.Contracts;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace AccountApi.Mock
{
    /// <summary>
    /// Mock store implementation
    /// </summary>
    public class MockAccountStore : IAccountStore
    {
        private static ConcurrentDictionary<string, AccountEntity> _accounts = new ConcurrentDictionary<string, AccountEntity>();
        private static ConcurrentDictionary<string, AccountEntity> _accountsByUserId = new ConcurrentDictionary<string, AccountEntity>();
        public async Task<bool> DeleteAsync(string id)
        {
            if (_accounts.TryRemove(id, out AccountEntity entity) == true)
            {
                var userId = entity.UserId;
                if (_accountsByUserId.TryRemove(userId, out AccountEntity accountEntity) == true)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public async Task<AccountEntity> GetAsync(string id)
        {
            _accounts.TryGetValue(id, out AccountEntity entity);
            return entity;
        }

        public async Task<AccountEntity> GetByUserIdAsync(string userId)
        {
            _accountsByUserId.TryGetValue(userId, out AccountEntity entity);
            return entity;
        }

        public async Task<AccountEntity> SaveAsync(AccountEntity accountEntity)
        {
            if (string.IsNullOrEmpty(accountEntity.Id) == true)
            {
                var id = Guid.NewGuid().ToString();
                accountEntity.Id = id;
                _accounts.TryAdd(id, accountEntity);
                _accountsByUserId.TryAdd(accountEntity.UserId, accountEntity);
            }
            else
            {
                Func<string, AccountEntity, AccountEntity> func = (k, oldValue) => accountEntity;
                _accounts.AddOrUpdate(accountEntity.Id, accountEntity, func);
                _accountsByUserId.AddOrUpdate(accountEntity.UserId, accountEntity, func);
            }
            return accountEntity;
        }
    }
}
