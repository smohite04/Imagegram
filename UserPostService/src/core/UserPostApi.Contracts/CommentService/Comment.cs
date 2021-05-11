using System;

namespace UserPostApi.Contracts
{
    public class Comment
    {
        public string Id { get; set; }
        public string PostId { get; set; }
        public string Content { get;  set; }        
        public AccountDetails Creator { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}