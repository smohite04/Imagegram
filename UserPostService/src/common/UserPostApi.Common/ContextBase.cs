using System;
using System.Threading;

namespace UserPostApi.Common
{
    [Serializable]
    public abstract class ContextBase
    {
        private static readonly AsyncLocal<ContextBase> _current = new AsyncLocal<ContextBase>();

        public static ContextBase Current
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

    public sealed class ContextScope : IDisposable
    {
        private bool _disposed;
        private readonly ContextBase _originalContext;
        private readonly ContextBase _currentContext;

        public ContextScope(ContextBase context)
        {
            _originalContext = ContextBase.Current;
            ContextBase.Current = context;
            _currentContext = context;
        }
        
        public void Dispose()
        {
            if (_disposed)
                return;

            _disposed = true;           
            ContextBase.Current = _originalContext;
        }
    }
}
