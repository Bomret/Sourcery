using System;
using System.IO;
using Sourcery.Sources;

namespace Sourcery
{
    public static class Source
    {
        public static ISource FromFile(string path)
        {
            return new FileSource(path);
        }

        public static ISource FromUri(Uri url)
        {
            return new UrlSource(url);
        }

        public static ISource FromStream(Stream stream)
        {
            return new StreamSource(stream);
        }
    }
}