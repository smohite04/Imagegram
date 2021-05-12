using AccountApi.Contracts;
using System;
using System.Threading.Tasks;

namespace AccountApi.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountStore _accountStore;

        public AccountService(IAccountStore accountStore)
        {
            this._accountStore = accountStore;
        }
        public async Task<AccountResponse> CreateAsync(AccountRequest accountRequest)
        {
            //store the data in store
            //create domain model
            //return response.
            var entity = accountRequest.ToEntity();
            var responseEntity = await _accountStore.SaveAsync(entity);
            responseEntity.EnsureCreatedSuccessfully();
            var data = responseEntity.ToDomainModel();
            return data.ToContract();
        }

        public async Task<bool> DeleteByUserIdAsync(string userId)
        {
            //get account
            //verify
            var accountEntity = await _accountStore.GetByUserIdAsync(userId);
            accountEntity.EnsureValid(userId);
            
            var isDeleted = await _accountStore.DeleteByUserIdAsync(userId);
            isDeleted.EnsureDeleted();
            return isDeleted;
        }

        public async Task<AccountResponse> GetByUserIdAsync(string userId)
        {
            //get account
            //verify
            var accountEntity = await _accountStore.GetByUserIdAsync(userId);
            accountEntity.EnsureValid(userId);
            var data = accountEntity.ToDomainModel();
            return data.ToContract();
        }
    }
}
