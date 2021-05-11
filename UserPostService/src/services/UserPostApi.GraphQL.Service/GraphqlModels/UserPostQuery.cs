
using GraphQL;
using GraphQL.Types;

namespace UserPostApi.GraphQL.Service
{
    public class UserPostQuery : ObjectGraphType
    {
        public UserPostQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<GetPostResponseType>(
                "post", "get post by id with al comments",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                 resolve: context =>
                 {
                     var id = context.GetArgument<string>("id");                    
                     return contextServiceLocator.PostService.GetPostAsync(id);
                 });

            Field<GetPostResponseType>(
               "postWithPaginatedComments", "get post by id with comments in paginated format",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" },
                new QueryArgument<IntGraphType> { Name = "pagenumber" },
               new QueryArgument<IntGraphType> { Name = "pagesize" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    var number = context.GetArgument<int>("pagenumber");
                    return contextServiceLocator.PostService.GetPostAsync(id);
                });
        }
    }
}


 