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

        public async Task<string> DeleteInitAsync(string userId)
        {
            //get account
            //verify
            var accountEntity = await _accountStore.GetByUserIdAsync(userId);
            accountEntity.EnsureValid(userId);
            
            //TODO:  add in house queue for data deletion and return the session linked against it
            return Guid.NewGuid().ToString();
        }

        public Task<AccountDeletionResponse> DeleteStatusAsync(string sessionId)
        {
            throw new NotImplementedException();
        }
    }
}
