using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace UserPostApi.Common
{
    [Serializable]
    public class BadRequestException : BaseApplicationException
    {
        public BadRequestException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message,httpStatusCode) {

        }
        public BadRequestException(string code, string message) : base(code, message, HttpStatusCode.BadRequest)
        {

        }
    }
}
