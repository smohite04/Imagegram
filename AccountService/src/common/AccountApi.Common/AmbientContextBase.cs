using System;
using System.Threading;

namespace AccountApi.Common
{
    [Serializable]
    public abstract class AmbientContextBase
    {
        private static readonly AsyncLocal<AmbientContextBase> _current = new AsyncLocal<AmbientContextBase>();

        public static AmbientContextBase Current
        {
            get
            {
                return _current.Value;
            }
            internal set
            {
                _current.Value = value;
            }
        }
    }
}
