using AccountApi.Contracts;
using AccountApi.Domain;
using System;
using System.Threading.Tasks;

namespace AccountApi.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly ITokenStore _tokenStore;

        public TokenService(ITokenStore tokenStore)
        {
            _tokenStore = tokenStore;
        }
        public async Task<AuthTokenResponse> CreateAsync(string userId)
        {
            //1.create a token for given user id
            //2. store the token against the userid       
            var authToken = TokenHandler.Create(userId);
            var entity = authToken.ToEntity();
            await _tokenStore.SaveAsync(entity);
            return authToken.ToContract();
        }

        public async Task DeleteAsync(string token)
        {
            await _tokenStore.DeleteAsync(token);
        }

        public async Task<AuthTokenResponse> ValidateAndRefreshAsync(string token)
        {
            //1.get the token for provided token value and validate
            //2. update the expiry since it's still active
            //3.save the updated value
            var authTokenEntity = await _tokenStore.GetAsync(token);
            authTokenEntity.IsValid(token);

            var authToken = authTokenEntity.ToDomainModel();
            authToken.ExtendExpiryByDefaultPeriod();

            var entity = authToken.ToEntity();
            await _tokenStore.SaveAsync(entity);

            return authToken.ToContract();
        }        
    }
}
