using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public interface IParser
    {
        /// <summary>
        /// Counts word occurencies in the given text file.
        /// </summary>
        Task<WordCounting> ParseAsync(string path, Encoding encoding, CancellationToken cancellationToken = default);
    }
}
