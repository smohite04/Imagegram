 using GraphQL.Types;
using UserPostApi.Contracts;

namespace UserPostApi.GraphQL.Service
{
    public class CommentDetailsType : ObjectGraphType<Comment>
    {
        public CommentDetailsType()
        {
            Field(x => x.Id);
            Field(x => x.Content);
            Field(x => x.Creator.UserId).Name("Creator");
            Field<StringGraphType>("CreatedOn", resolve: context => context.Source.CreatedOn.ToString());          
        }
    }

    public class PaginatedCommentDetailsType : ObjectGraphType<PaginatedResponse<Comment>>
    {
        public PaginatedCommentDetailsType()
        {
            Field<ListGraphType<CommentDetailsType>>("comments", resolve: context => context.Source.Data);
            Field<PagingDetailsType>("pageInfo", resolve: context => context.Source.PageDetails);
        }
    }

    public class PagingDetailsType :ObjectGraphType<PagingDetails>
    {
        public PagingDetailsType()
        {
            Field(x => x.PageNumber);
            Field(x => x.PageSize);
            Field(x => x.TotalCount);
        }
    }
}

 
