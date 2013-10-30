using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sourcery
{
    public interface ISource
    {
        string GetAsText();
        string GetAsText(Encoding encoding);
        Task<string> GetAsTextAsync();
        Task<string> GetAsTextAsync(Encoding encoding);

        byte[] GetAsByteArray();
        Task<byte[]> GetAsByteArrayAsync();

        Stream GetAsStream();
        Task<Stream> GetAsStreamAsync();
    }
}