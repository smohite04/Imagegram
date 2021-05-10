using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace AccountApi.Common
{
    [Serializable]
    public class CallContext : AmbientContextBase
    {
        public string UserId { get; private set; }
        public string Token { get; private set; }
        public Dictionary<string,string> Headers { get; } = new Dictionary<string, string>();
        public new static CallContext Current => (CallContext)AmbientContextBase.Current;

        public void SetUserId(string id)
        {
            UserId = id;
        }
        public void SetToken(string token)
        {
            Token = token;
        }
    }
}
