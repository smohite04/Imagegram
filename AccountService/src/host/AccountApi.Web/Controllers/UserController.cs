using System.Collections.Generic;
using System.Threading.Tasks;
using AccountApi.Contracts;
using AccountApi.DataContract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AccountApi.Web.Controllers
{
    [Route("api/v1.0/[controller]")]
    public class AccountController : Controller
    {
        //tODO : add account service
        public AccountController()
        {
        }
        [TypeFilter(typeof(UserAuthorizationFilter))]
        [HttpGet("{id}")]
        public async Task<AccountResponse> GetAsync(int id)
        {
            return null;
        }
        
        [HttpPost]
        public AccountResponse Post([FromBody]AccountRequest value)
        {
            return null;
        }
        
        [TypeFilter(typeof(UserAuthorizationFilter))]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
