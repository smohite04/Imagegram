using System;

namespace AccountApi.Domain
{
    public class Account
    {
        public Account(string id, string name)
        {
            id.ShouldNotBeNullOrEmpty(nameof(id), nameof(Account));
            name.ShouldNotBeNullOrEmpty(nameof(id), nameof(Account));
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
