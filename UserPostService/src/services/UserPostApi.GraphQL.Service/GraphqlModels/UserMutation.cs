using GraphQL.Types;

namespace UserPostApi.GraphQL.Service
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(ContextServiceLocator contextServiceLocator)
        {
            Field<DeletePostResponseType>(
                  "deletePostsByUser", "delete posts by userId with all comments",
                  arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                   resolve: context =>
                   {
                       var id = context.GetArgument<string>("id");
                       var data = contextServiceLocator.PostService.DeletePostbyUserIdAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
                       return new DeleteResponse
                       {
                           Success = data ? "deleted" : "failed",
                           Id = id
                       };
                   });

        }
    }
}