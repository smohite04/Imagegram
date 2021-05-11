using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace AccountApi.Common
{
    [Serializable]
    public class CallContext : ContextBase
    {
        public string UserId { get; private set; }
        public string AuthenticationToken { get; private set; }
        public Dictionary<string,string> Headers { get; } = new Dictionary<string, string>();
        public new static CallContext Current => (CallContext)ContextBase.Current;
        public CallContext(Dictionary<string,string> headers = null)
        {
            if (headers != null)
                Headers = headers;
        }
        public void SetUserId(string id)
        {
            UserId = id;
        }
        public void SetToken(string token)
        {
            AuthenticationToken = token;
        }
    }
}
