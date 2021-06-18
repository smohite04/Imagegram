using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserPostApi.Common;
using UserPostApi.Contracts;

namespace UserPostApi.Service.Mock
{
    public class MockPostService : IPostServiceAdapter
    {
        private static List<PostResponse> postResponses = new List<PostResponse> {
            new PostResponse{
                Id = "1",
                ImageUrl = "www.test.com/1.jpg",
                CreatedOn = DateTime.UtcNow.AddDays(-1)
            },
            new PostResponse{
                Id = "2",
                ImageUrl = "www.test.com/2.jpg",
                CreatedOn = DateTime.UtcNow.AddDays(-1)
            },
            new PostResponse{
                Id = "3",
                ImageUrl = "www.test.com/3.jpg",
                CreatedOn = DateTime.UtcNow.AddDays(-1)
            },
            new PostResponse{
                Id = "4",
                ImageUrl = "www.test.com/4.jpg",
                CreatedOn = DateTime.UtcNow.AddDays(-1)
            }
        };

        public async Task<bool> DeletePostbyUserIdAsync(string userId)
        {
            return true;
        }

        public async Task<PostResponse> GetPostAsync(string postId)
        {
            var response = postResponses.Find(x => x.Id.Equals(postId, StringComparison.OrdinalIgnoreCase));
            if (response == null)
                throw Errors.ValueDoesNotExist("post", postId);
            return response;
        }
    }
}
