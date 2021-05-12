using AccountApi.Common;
using AccountApi.Common.Exceptions;
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

            AuthTokenResponse response = null;
            try
            {
                response = _tokenService.ValidateAndRefreshAsync(accountId).ConfigureAwait(false).GetAwaiter().GetResult();
               
            }
            catch (BaseApplicationException ex)
            {
                //log exception. since we want to override the exception
                if(ex.ErrorCode.Equals(ErrorCodes.ExpiredToken) || ex.ErrorCode.Equals(ErrorCodes.ValueDoesNotExist))
                    throw Errors.InvalidHeader(Keystore.Headers.AccountId);

                throw;
            }
            catch (Exception ex)
            {
                //log exception. since we want to override the exception               
                    throw Errors.InternalServerError();
            }
            if (response == null || string.IsNullOrEmpty(response.UserId) == true)
            {
                throw Errors.InvalidHeader(Keystore.Headers.AccountId);
            }
            CallContext.Current.SetUserId(response.UserId);
            CallContext.Current.SetToken(response.Token);
        }
    }
}
