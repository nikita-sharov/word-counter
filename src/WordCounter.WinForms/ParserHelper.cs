using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter.WinForms
{
    internal static class ParserHelper
    {
        private static readonly IParser Parser = new HighPerformanceParser();

        public static async Task<OrderedWordCounting> ParseAsync(string path, Encoding encoding)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            try
            {
                Task<OrderedWordCounting> countingTask = Task.Run(() =>
                {
                    try
                    {
                        return Parser.ParseAsync(path, encoding, cancellationTokenSource.Token)
                            .ContinueWith(task => task.Result.ToOrderedWordCounting());
                    }
                    catch (OperationCanceledException ex)
                    {
                        return Task.FromCanceled<OrderedWordCounting>(ex.CancellationToken);
                    }
                });

                Task delayTask = Task.Delay(0);
                await Task.WhenAny(countingTask, delayTask);
                if (delayTask.IsCompleted)
                {
                    using var progressDialog = new ProgressDialog(countingTask, cancellationTokenSource);
                    progressDialog.ShowDialog();
                }

                return countingTask.Result;
            }
            finally
            {
                cancellationTokenSource.Dispose();
            }
        }
    }
}
