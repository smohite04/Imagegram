using System;

namespace UserPostApi.Domain
{
    public class Account
    {
        public Account(string id,string userId)
        {
            id.ShouldNotBeNullOrEmpty(nameof(id), nameof(Account));
            userId.ShouldNotBeNullOrEmpty(nameof(userId), nameof(Account));
            Id = id;
            UserId = userId;
        }
        public string Id { get; private set; }
        public string Name { get; private set; }
        /// <summary>
        /// UserId represents the id associated with user logged-in and who's account needs to be created.
        /// </summary>
        public string UserId { get; }
        public Account WithName(string name)
        {
            name.ShouldNotBeNullOrEmpty(nameof(name), nameof(Account), nameof(WithName));
            Name = name;
            return this;
        }
    }
}
