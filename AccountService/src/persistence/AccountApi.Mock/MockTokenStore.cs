using AccountApi.Contracts;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace AccountApi.Mock
{
    /// <summary>
    /// Mock store implementation
    /// </summary>
    public class MockTokenStore : ITokenStore
    {
        private static ConcurrentDictionary<string, AuthTokenEntity> _tokens = new ConcurrentDictionary<string, AuthTokenEntity>();
        public async Task<bool> DeleteAsync(string token)
        {
           return _tokens.TryRemove(token, out AuthTokenEntity authTokenEntity);           
        }

        public async Task<AuthTokenEntity> GetAsync(string token)
        {
             _tokens.TryGetValue(token, out AuthTokenEntity entity);
            return entity;
        }

        public async Task SaveAsync(AuthTokenEntity authTokenEntity)
        {
            Func<string, AuthTokenEntity, AuthTokenEntity> func = (k, oldValue) => authTokenEntity;
            _tokens.AddOrUpdate(authTokenEntity.Token, authTokenEntity,func);
        }
    }
}
