using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPostApi.Common;
using UserPostApi.Contracts;

namespace UserPostApi.Web
{
    public class AccountAuthenticationFilter : IAuthorizationFilter
    {
        private readonly IAccountAuthenticationAdapter _accountAuthenticationAdapter;

        public AccountAuthenticationFilter(IAccountAuthenticationAdapter accountAuthenticationAdapter)
        {
            _accountAuthenticationAdapter = accountAuthenticationAdapter;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            CallContext.Current.Headers.TryGetValue(Keystore.Headers.AccountId, out string accountId);
            if (string.IsNullOrEmpty(accountId) == true)
                throw Errors.MissingHeader(Keystore.Headers.AccountId);

           var response = _accountAuthenticationAdapter.ValidateTokenAsync(accountId).ConfigureAwait(false).GetAwaiter().GetResult();
            if (response == null || string.IsNullOrEmpty(response.AssociatedUserId) == true)
            {
                throw Errors.InvalidHeader(Keystore.Headers.AccountId);
            }
            CallContext.Current.SetUserId(response.AssociatedUserId);
            CallContext.Current.SetToken(accountId);
        }
    }
}
