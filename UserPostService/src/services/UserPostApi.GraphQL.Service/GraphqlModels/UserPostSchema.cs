using System;
using GraphQL;
using GraphQL.Types;

namespace UserPostApi.GraphQL.Service
{
    public class UserPostSchema : Schema
    {
        public UserPostSchema(IDependencyResolver dependencyResolver) : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<UserPostQuery>();
        }
    }
}


 