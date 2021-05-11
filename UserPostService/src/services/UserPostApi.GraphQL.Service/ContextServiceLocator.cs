using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using UserPostApi.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace UserPostApi.GraphQL.Service
{
    public class ContextServiceLocator
    {
        public IPostService PostService
        {
            get
            {
                return _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IPostService>();
            }
        }

        public ICommentService ComemntService
        {
            get
            {
                return _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ICommentService>();
            }
        }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
