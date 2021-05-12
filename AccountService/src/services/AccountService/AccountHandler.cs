using AccountApi.Common;
using AccountApi.Contracts;
using AccountApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountApi.AccountService
{
   
    public static class AccountHandler
    {

        public static void EnsureCreatedSuccessfully(this AccountEntity entity)
        {
            if (entity == null || string.IsNullOrEmpty(entity.Id) == true)
                throw Errors.AccountCreationError();
        }
        public static void EnsureValid(this AccountEntity entity, string id)
        {
            if (entity == null || string.IsNullOrEmpty(entity.Id) == true)
                throw Errors.ValueDoesNotExist("account", id);
        }
        public static void EnsureDeleted(this bool value)
        {
            if (value == false)
                throw Errors.InternalServerError();
        }
    }
}
