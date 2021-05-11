using AccountApi.Common;
using AccountApi.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountApi.Web
{
    public class UserAuthorizationFilter : IAuthorizationFilter
    {
        private readonly ITokenService _tokenService;

        public UserAuthorizationFilter(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
             CallContext.Current.Headers.TryGetValue(Keystore.Headers.AccountId, out string accountId);
            if (string.IsNullOrEmpty(accountId) == true)
                throw Errors.MissingHeader(Keystore.Headers.AccountId);

            var value = _tokenService.ValidateAndRefreshAsync("").ConfigureAwait(false).GetAwaiter().GetResult();
            if (value == null || string.IsNullOrEmpty(value.UserId) == true)
            {
                throw Errors.InvalidHeader(Keystore.Headers.AccountId);
            }
            CallContext.Current.SetUserId(value.UserId);
            CallContext.Current.SetToken(value.Token);
        }
    }
}
