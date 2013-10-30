using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sourcery.Sources
{
    public sealed class UrlSource : ISource
    {
        private readonly Uri _url;

        public UrlSource(Uri url)
        {
            _url = url;
        }

        public string GetAsText()
        {
            return GetAsText(Encoding.UTF8);
        }

        public string GetAsText(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            using (var webClient = new WebClient())
            {
                var content = webClient.DownloadData(_url);

                return encoding.GetString(content);
            }
        }

        public Task<string> GetAsTextAsync()
        {
            return GetAsTextAsync(Encoding.UTF8);
        }

        public Task<string> GetAsTextAsync(Encoding encoding)
        {
            if (encoding == null)
            {
                throw new ArgumentNullException("encoding");
            }

            return Task.Factory.StartNew(() =>
            {
                using (var webClient = new WebClient())
                {
                    var content = webClient.DownloadData(_url);

                    return encoding.GetString(content);
                }
            });
        }

        public byte[] GetAsByteArray()
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadData(_url);
            }
        }

        public Task<byte[]> GetAsByteArrayAsync()
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadDataTaskAsync(_url);
            }
        }

        public Stream GetAsStream()
        {
            using (var webClient = new WebClient())
            {
                return webClient.OpenRead(_url);
            }
        }

        public Task<Stream> GetAsStreamAsync()
        {
            using (var webClient = new WebClient())
            {
                return webClient.OpenReadTaskAsync(_url);
            }
        }
    }
}