using System.Threading.Tasks;
using AccountApi.Common;
using AccountApi.DataContract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountApi.Web
{
    [TypeFilter(typeof(UserAuthorizationFilter))]
    [Route("api/v1.0/[controller]")]
    public class AccountController : Controller
    {
        private readonly Contracts.IAccountService _accountService;

        //tODO : add account service
        public AccountController(AccountApi.Contracts.IAccountService accountService)
        {
            this._accountService = accountService;
        }
       
        [HttpGet("{userId}")]
        public async Task<DataContract.AccountResponse> GetAsync(string userId)
        {
            var account = await _accountService.GetByUserIdAsync(userId);
            return account.ToDataContract();
        }
        
        [HttpPost]
        public async Task<AccountResponse> CreateAsync([FromBody]DataContract.AccountRequest request)
        {
            var accountRequest = request.ToModel();
            accountRequest.UserId = CallContext.Current.UserId;
            var accountResponse = await _accountService.CreateAsync(accountRequest);
            return accountResponse.ToDataContract();
        }
        //TODO: validate the userid against the token and one in request and throw exception
        [HttpDelete("deleteByUserId/{userId}")]
        public async Task DeleteAsync(string userId)
        {
            await _accountService.DeleteByUserIdAsync(userId);
        }
    }
}
