using System;
using System.Collections.Generic;

namespace UserPostApi.Contracts
{
    public class PostResponse
    {
        public string Id { get; set; }
        public AccountDetails Creator { get; }
        public DateTime CreatedOn { get;  set; }
        public string ImageUrl { get; set; }
      //  public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}