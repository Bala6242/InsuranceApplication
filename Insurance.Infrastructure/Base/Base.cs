using System;

namespace Insurance.Infrastructure.Base
{
    public interface IBase
    {
    }

    public abstract class Base : IBase
    {
        protected void ThrowIfNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));
        }
    }
}
