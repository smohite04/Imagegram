using System;
using System.Collections.Generic;
using System.Text;

namespace AccountApi.DataContract
{
    public static class AccountTranslator
    {
        public static AccountResponse ToDataContract(this Contracts.AccountResponse accountResponse)
        {
            return new AccountResponse
            {
                Id = accountResponse.Id,
                UserId = accountResponse.UserId,
                Name = accountResponse.Name
            };
        }
        public static Contracts.AccountRequest ToModel(this AccountRequest accountRequest)
        {
            return new Contracts.AccountRequest
            {
                Email = accountRequest.Email,
                Name = accountRequest.Name
            };
        }
    }
}
