using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPostApi.Contracts;

namespace UserPostApi.Service.Mock
{
    public class MockCommentService : ICommentServiceAdapter
    {
        private static List<Comment> comments = new List<Comment> {
            new Comment{
                Id = "1",
               PostId = "2",
               Content = "test comment 1 by user",
               Creator = new AccountDetails{ UserId = "user2"},
               CreatedOn = DateTime.UtcNow.AddDays(-1)
            },
          new Comment{
                Id = "2",
               PostId = "2",
               Content = "test comment 2 by user",
               Creator = new AccountDetails{ UserId = "user1"},
               CreatedOn = DateTime.UtcNow.AddDays(-2)
            },
            new Comment{
                Id = "3",
               PostId = "1",
               Content = "test comment by user",
               Creator = new AccountDetails{ UserId = "user1"},
               CreatedOn = DateTime.UtcNow.AddDays(-1)
            },
            new Comment{
               Id = "4",
               PostId = "1",
               Content = "test comment 4 by user",
               Creator = new AccountDetails{ UserId = "user1"},
               CreatedOn = DateTime.UtcNow.AddDays(-2)
            },
             new Comment{
               Id = "5",
               PostId = "1",
               Content = "test comment 5 by user",
               Creator = new AccountDetails{ UserId = "user2"},
               CreatedOn = DateTime.UtcNow.AddDays(-3)
            },
        };

        public async Task<List<Comment>> GetCommentsBypostIdAsync(string postId)
        {
            return comments.FindAll(x => x.PostId.Equals(postId));
        }

        public async Task<PaginatedResponse<Comment>> GetPaginatedCommentsBypostIdAsync(string postId, PaginationRequest request)
        {
           var allComments = comments.FindAll(x => x.PostId.Equals(postId));
            if (allComments == null || allComments.Count == 0)
                return new PaginatedResponse<Comment> { PageDetails = new PagingDetails() };
            var orderedComments = allComments.OrderByDescending(x => x.CreatedOn).ToList();
            var totalCount = orderedComments.Count;
            var response = new PaginatedResponse<Comment> {PageDetails = new PagingDetails {TotalCount = totalCount } };
            if (request == null)
            {
                response.Data = orderedComments;
                response.PageDetails.PageNumber = 1;
                response.PageDetails.PageSize = totalCount;
                return response;
            }
            if (request.PageNumber <= 0)
                request.PageNumber = 1;

            //tODO: move it to keystore
            if (request.PageSize <= 0)
                request.PageSize = 10;
            
            var totalPages = (int)Math.Ceiling((decimal)totalCount / (decimal)request.PageSize);
            if (request.PageNumber > totalPages)
                request.PageNumber = totalPages;
                var data =  orderedComments.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToList();
            return new PaginatedResponse<Comment> { Data =data, PageDetails = new PagingDetails {
                PageNumber = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount =totalCount } };
        }
    }
}
