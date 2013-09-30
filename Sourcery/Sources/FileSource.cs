using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sourcery.Sources
{
    public class FileSource : ISource
    {
        private readonly string _path;

        public FileSource(string path)
        {
            _path = path;
        }

        public IEnumerable<string> ReadLines()
        {
            return File.ReadAllLines(_path);
        }

        public IEnumerable<T> ReadAllLinesAs<T>(Func<byte, T> converter)
        {
            return File.ReadAllBytes(_path)
                       .Select(converter);
        }
    }
}