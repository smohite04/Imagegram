
using GraphQL;
using GraphQL.Types;
using System;
using UserPostApi.Common;

namespace UserPostApi.GraphQL.Service
{
    public class UserPostQuery : ObjectGraphType
    {
        public UserPostQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<GetPostResponseType>(
                "post", "get post by id with al comments",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                 resolve:  context =>
                 {
                     var id = context.GetArgument<string>("id");                    
                     return contextServiceLocator.PostService.GetPostAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();                   
                 });

            Field<GetPostResponseType>(
               "postWithPaginatedComments", "get post by id with comments in paginated format",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    return contextServiceLocator.PostService.GetPostAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
                   
                });
        }
    }
}


 