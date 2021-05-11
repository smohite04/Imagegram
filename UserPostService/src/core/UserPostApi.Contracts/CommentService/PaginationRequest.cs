using System.Collections.Generic;

namespace UserPostApi.Contracts
{
    public class PaginationRequest
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class PagingDetails
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
    public class PaginatedResponse<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public PagingDetails PageDetails { get; set; }
    }
}