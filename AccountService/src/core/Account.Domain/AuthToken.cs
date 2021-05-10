using System;

namespace AccountApi.Domain
{
    /// <summary>
    /// The AuthToken is the entity relates to token issued against the valid user
    /// </summary>
    public class AuthToken
    {
        public AuthToken(string userId)
        {
            userId.ShouldNotBeNullOrEmpty(nameof(userId), nameof(AuthToken));          
        }
        
        public string UserId { get; }
        public string Value { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime ExpiresOn { get; private set; }
        public AuthToken WithCreatedOn(DateTime dateTime)
        {           
                dateTime.ShouldBeAValidDate(nameof(dateTime), nameof(AuthToken), nameof(WithCreatedOn));
                this.CreatedOn = dateTime;           
            return this;
        }
        public AuthToken WithExpiresOn(DateTime dateTime)
        {
            dateTime.ShouldBeAValidDate(nameof(dateTime), nameof(AuthToken), nameof(WithExpiresOn));
            dateTime.ShouldBeGreaterThan(this.CreatedOn, nameof(dateTime), nameof(AuthToken), nameof(WithExpiresOn));
            this.ExpiresOn = dateTime;
            return this;
        }
        public AuthToken WithAuthTokenValue(string value)
        {
            value.ShouldNotBeNullOrEmpty(nameof(value), nameof(AuthToken));
            return this;
        }        
    }
}
