using System.Collections.Generic;
using System.Threading.Tasks;
using AccountApi.Common;
using AccountApi.Contracts;
using AccountApi.DataContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AuthTokenResponse = AccountApi.DataContract.AuthTokenResponse;

namespace AccountApi.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            this._tokenService = tokenService;
        }
        [HttpGet("{id}")]
        public async Task<AuthTokenResponse> GenerateAsync(string userId)
        {
            var response = await _tokenService.CreateAsync(userId);
            return response.ToDataContract();
        }
        
        [HttpGet("authenticate")]
        public async  Task<AuthTokenResponse> AuthenticateAsync()
        {
            var response = await _tokenService.ValidateAndRefreshAsync(CallContext.Current.AuthenticationToken);
            return response.ToDataContract();
        }
        
        [HttpDelete()]
        public async Task DeleteAsync()
        {
            await _tokenService.DeleteAsync(CallContext.Current.AuthenticationToken);
        }
    }
}
