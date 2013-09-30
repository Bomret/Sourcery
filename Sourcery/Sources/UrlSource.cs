using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Sourcery.Sources
{
    public class UrlSource : ISource
    {
        private readonly Uri _url;

        public UrlSource(Uri url)
        {
            _url = url;
        }

        public IEnumerable<string> ReadLines()
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(_url)
                                .Split(new[] {@"\n", @"\r\n", @"\r"}, StringSplitOptions.None);
            }
        }

        public IEnumerable<T> ReadAllLinesAs<T>(Func<byte, T> converter)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadData(_url)
                                .Select(converter);
            }
        }
    }
}