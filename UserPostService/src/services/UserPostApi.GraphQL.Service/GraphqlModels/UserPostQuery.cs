
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
                     try
                     {
                         return contextServiceLocator.PostService.GetPostAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
                     }
                     catch (BaseApplicationException ex)
                     {
                         var error = new ExecutionError(ex.ErrorMessage) { Code = ex.ErrorCode};
                         context.Errors.Add(error);
                     }
                     catch (Exception ex)
                     {
                         //Log error
                         var exception = Errors.InternalServerError();
                         var error = new ExecutionError(exception.ErrorMessage) { Code = exception.ErrorMessage };
                         context.Errors.Add(error);
                     }
                     return null;
                 });

            Field<GetPostResponseType>(
               "postWithPaginatedComments", "get post by id with comments in paginated format",
               arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<string>("id");
                    //try
                    //{
                        return contextServiceLocator.PostService.GetPostAsync(id).ConfigureAwait(false).GetAwaiter().GetResult();
                   // }
                    //catch (BaseApplicationException ex)
                    //{
                    //    var error = new ExecutionError(ex.ErrorMessage) { Code = ex.ErrorCode };
                    //    context.Errors.Add(error);
                    //    error.Data.Add("baseAppEx", "true");
                    //    error.Data.Add("httpstatuscode", ex.HttpStatusCode);
                    //}
                    //catch (Exception ex)
                    //{
                    //    //Log error
                    //    var exception = Errors.InternalServerError();
                    //    var error = new ExecutionError(exception.ErrorMessage) { Code = exception.ErrorMessage };
                    //    error.Data.Add("baseAppEx", "true");
                    //    error.Data.Add("httpstatuscode", exception.HttpStatusCode);
                    //    context.Errors.Add(error);
                    //}
                    //throw new Exception("test");
                    //return null;
                });
        }
    }
}


 