using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace UserPostApi.Common
{
    public  class ErrorInfo
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public List<Info> Info { get; set; } = new List<Info>();
    }
    public class Info
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
}
