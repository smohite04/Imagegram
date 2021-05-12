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
        [HttpPost()]
        public async Task<AuthTokenResponse> GenerateAsync([FromBody]AuthTokenRequest authTokenRequest)
        {
            var response = await _tokenService.CreateAsync(authTokenRequest.UserId);
            return response.ToDataContract();
        }

        [HttpGet("{token}")]
        public async Task<AuthTokenResponse> AuthenticateAsync(string token)
        {
            var response = await _tokenService.ValidateAndRefreshAsync(token);
            return response.ToDataContract();
        }

        [HttpDelete("{token}")]
        public async Task DeleteAsync(string token)
        {
            await _tokenService.DeleteAsync(token);
        }
    }
}
