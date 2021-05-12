using System;
using System.Threading.Tasks;

namespace UserPostApi.Contracts
{
    /// <summary>
    /// Post service adapter will be responsible to get the data from image post microservice
    /// </summary>
    public interface IPostServiceAdapter
    {
        Task<PostResponse> GetPostAsync(string Id);
    }
}
