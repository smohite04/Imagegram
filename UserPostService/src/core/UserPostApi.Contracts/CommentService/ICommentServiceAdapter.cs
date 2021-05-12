using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserPostApi.Contracts
{
    /// <summary>
    /// The adapter will connect with the actual comment api service to return the responses
    /// </summary>
    public interface ICommentServiceAdapter
    {
        Task<List<Comment>> GetCommentsBypostIdAsync(string postId);
        Task<PaginatedResponse<Comment>> GetPaginatedCommentsBypostIdAsync(string postId, PaginationRequest request);
    }
}
