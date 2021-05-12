using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UserPostApi.Common;
using UserPostApi.Common.Exceptions;

namespace UserPostApi.Web
{
    public static class ErrorHandler
    {
        public static void ToException(this ExecutionErrors errors)
        {
            var error = new BaseApplicationException(ErrorCodes.MultipleErrors, ErrorMessages.MultipleErrors, HttpStatusCode.BadRequest);
            if (errors != null)
            {
                foreach (var executionError in errors)
                {
                    if (executionError.InnerException != null)
                    {
                        var info = executionError.InnerException.ToErrorInfo();
                        if (info != null)
                        {
                            error.Infos.Add(info);
                        }
                    }
                }             
            }
            throw error;
        }

        private static Info ToErrorInfo(this Exception exception)
        {
            if (exception is BaseApplicationException baseApplicationException)
            {
                return new Info
                {
                    Code = baseApplicationException.ErrorCode,
                    Message = baseApplicationException.ErrorMessage,
                };
            }
          
            else
            {
                var applicationException = Errors.InternalServerError();
                return new Info
                {
                    Code = applicationException.ErrorCode,
                    Message = applicationException.ErrorMessage,
                };
            }
        }

    }
}
