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
        public IPostServiceAdapter PostService
        {
            get
            {
                return _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IPostServiceAdapter>();
            }
        }

        public ICommentServiceAdapter ComemntService
        {
            get
            {
                return _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<ICommentServiceAdapter>();
            }
        }
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ContextServiceLocator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}
