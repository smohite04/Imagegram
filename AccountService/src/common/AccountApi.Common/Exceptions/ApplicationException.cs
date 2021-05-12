using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace AccountApi.Common
{
    [Serializable]
    public class ApplicationException : BaseApplicationException
    {
        public ApplicationException(string code, string message, HttpStatusCode httpStatusCode) : base(code, message,httpStatusCode) {

        }
        public ApplicationException(string code, string message) : base(code, message, HttpStatusCode.InternalServerError)
        {

        }
    }
}
