using System;
using System.Collections.Generic;

namespace UserPostApi.Contracts
{
    public class PostResponse
    {
        public string Id { get; set; }
        public DateTime CreatedOn { get;  set; }
        public string ImageUrl { get; set; }
    }
}