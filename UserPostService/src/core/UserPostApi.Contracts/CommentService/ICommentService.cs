using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UserPostApi.Contracts
{
    public interface ICommentService
    {
        Task<List<Comment>> GetCommentsBypostIdAsync(string postId);
        Task<PaginatedResponse<Comment>> GetPaginatedCommentsBypostIdAsync(string postId, PaginationRequest request);
    }
}
