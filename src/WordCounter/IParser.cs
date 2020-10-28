using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public interface IParser
    {
        Task<WordCounting> ParseAsync(string path, Encoding encoding, CancellationToken cancellationToken);
    }
}
