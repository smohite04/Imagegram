using System;
using System.Threading.Tasks;

namespace UserPostApi.Contracts
{
    /// <summary>
    /// Post service will deal with post related operations.
    /// </summary>
    public interface IPostService
    {
        Task<PostResponse> GetPostAsync(string postId);
    }
}
