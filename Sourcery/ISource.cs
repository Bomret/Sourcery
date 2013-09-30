using System;
using System.Collections.Generic;

namespace Sourcery
{
    public interface ISource
    {
        IEnumerable<string> ReadLines();

        IEnumerable<T> ReadAllLinesAs<T>(Func<byte, T> converter);
    }
}