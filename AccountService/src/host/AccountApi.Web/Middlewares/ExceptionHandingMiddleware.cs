using AccountApi.Common;
using AccountApi.Common.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AccountApi.Web
{

    public class ExceptionHandlerMiddleware
    {
        readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
    

            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(exception, httpContext);
            }
        }

        public async Task HandleExceptionAsync(Exception exception, HttpContext context)
        {
            // Translate to generic error for exception shielding
            ErrorInfo errorInfo = null;
            if (exception is BaseApplicationException appEx)
            {
                errorInfo = GetErrorInfo(appEx);
                context.Response.StatusCode = (int)appEx.HttpStatusCode;             
            }
            else
            {
                errorInfo = GetInternalServerError();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.Response.ContentType = "application/json";
            var setting = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),               
            };
            var content = JsonConvert.SerializeObject(errorInfo, setting);
            await context.Response.WriteAsync(content);

        }

        public static ErrorInfo GetErrorInfo(BaseApplicationException ex)
        {
            var error = new ErrorInfo {
                Code = ex.ErrorCode,
                Message = ex.ErrorMessage
            };            
            return error;
        }
        private ErrorInfo GetInternalServerError()
        {
            return new ErrorInfo {Code = ErrorCodes.InternalServerError, Message= ErrorMessages.InternalServerError };
        }
    }

    public static class ExceptionMiddlerWareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }


    }

}
