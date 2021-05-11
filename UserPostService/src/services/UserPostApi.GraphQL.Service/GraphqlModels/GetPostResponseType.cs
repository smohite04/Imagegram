
using GraphQL.Types;
using UserPostApi.Contracts;
using UserPostApi.GraphQL.Service;

namespace UserPostApi.GraphQL.Service
{
    public class GetPostResponseType : ObjectGraphType //<PostResponse>
    {
        public GetPostResponseType(ContextServiceLocator contextServiceLocator)
        {
            Field<StringGraphType>("id","Id");
            Field<StringGraphType>("imageUrl");            
            Field<StringGraphType>("CreatedOn");
            Field<ListGraphType<CommentDetailsType>>("comments",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),                
                resolve: context =>
                {
                    var postId = (context.Source as PostResponse).Id;
                    return contextServiceLocator.ComemntService.GetCommentsBypostIdAsync(postId);
                },
                 description: "comments on given posts");

            Field<PaginatedCommentDetailsType>("result",
              arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" },
              new QueryArgument<IntGraphType> { Name = "pn" },
              new QueryArgument<IntGraphType> { Name = "ps" }),
              resolve: context =>
              {
                  var pageNumber = context.GetArgument<int>("pn");
                  var pageSize = context.GetArgument<int>("ps");                 
                      var req = new PaginationRequest { PageNumber = pageNumber, PageSize = pageSize };
                  var postId = (context.Source as PostResponse).Id;
                      var comments = contextServiceLocator.ComemntService.GetPaginatedCommentsBypostIdAsync(postId, req)
                      .ConfigureAwait(false).GetAwaiter().GetResult();
                      return comments;
                  
              },
               description: "comments on given posts");
        }
    }
}
