using AccountApi.Contracts;
using AccountApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountApi.AccountService
{
    public static class Translator
    {
        public static AccountResponse ToContract(this Account accout)
        {
            return new AccountResponse
            {
               Id = accout.Id,
               UserId = accout.UserId,
               Name = accout.Name
            };
        }
        public static AccountEntity ToEntity(this AccountRequest accountRequest)
        {
            return new AccountEntity
            {
                Name = accountRequest.Name,
                UserId = accountRequest.UserId,
                Email = accountRequest.Email
            };
        }
        public static Account ToDomainModel(this AccountEntity accountEntity)
        {
            return new Account(accountEntity.Id, accountEntity.UserId)
                       .WithName(accountEntity.Name);                       
        }
    }
}
