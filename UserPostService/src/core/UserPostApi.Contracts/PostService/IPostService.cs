using System;

namespace UserPostApi.Contracts
{
    public interface IPostService
    {
        PostResponse GetPostAsync(string postId);
    }
}
