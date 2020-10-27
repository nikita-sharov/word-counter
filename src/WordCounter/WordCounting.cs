using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter
{
    public class WordCounting : Dictionary<string, int>
    {
        public static WordCounting Parse(string path, Encoding encoding)
        {
            var counting = new WordCounting();
            using (var reader = new StreamReader(path, encoding))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] words = Regex.Split(line, @"\s+");
                    foreach (var word in words)
                    {
                        if (string.IsNullOrEmpty(word))
                        {
                            continue;
                        }

                        if (counting.ContainsKey(word))
                        {
                            counting[word] += 1;
                        }
                        else
                        {
                            counting.Add(word, 1);
                        }
                    }

                    line = reader.ReadLine();
                }
            }

            return counting;
        }

        public static async Task<WordCounting> ParseAsync(
            string path, Encoding encoding, CancellationToken cancellationToken)
        {
            var counting = new WordCounting();
            using (var reader = new StreamReader(path, encoding))
            {
                string line = await reader.ReadLineAsync();
                while (line != null)
                {
                    string[] words = Regex.Split(line, @"\s+");
                    foreach (var word in words)
                    {
                        if (string.IsNullOrEmpty(word))
                        {
                            continue;
                        }

                        if (counting.ContainsKey(word))
                        {
                            counting[word] += 1;
                        }
                        else
                        {
                            counting.Add(word, 1);
                        }
                    }

                    cancellationToken.ThrowIfCancellationRequested();
                    line = await reader.ReadLineAsync();
                }
            }

            return counting;
        }
    }
}
