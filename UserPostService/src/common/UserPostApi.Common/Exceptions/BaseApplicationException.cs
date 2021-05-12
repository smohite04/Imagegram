using System;
using System.Collections.Generic;
using System.Net;

namespace UserPostApi.Common
{
    [Serializable]
    public class BaseApplicationException : Exception
    {
        public string ErrorCode { get; }
        public string ErrorMessage { get; }
        public HttpStatusCode HttpStatusCode { get; }
        public List<Info> Infos { get; set; } = new List<Info>();
        public BaseApplicationException(string errorCode, string errorMessage, HttpStatusCode httpStatusCode) : base(errorMessage)
        {
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
            this.HttpStatusCode = httpStatusCode;           
        }
        
        public BaseApplicationException(string message, string code, Exception inner) : base(message, inner)
        {
            this.ErrorCode = code;
            this.ErrorMessage = message;
        }
    }
}
