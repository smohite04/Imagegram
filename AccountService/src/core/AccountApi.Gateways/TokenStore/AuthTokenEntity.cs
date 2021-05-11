using System;

namespace AccountApi.Contracts
{
    public class AuthTokenEntity
    {
        public string UserId { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ExpiresOn { get; set; }
    }
}