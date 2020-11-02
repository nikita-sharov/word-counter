using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WordCounter.WinForms
{
    internal static class ParserHelper
    {
        private static readonly IParser Parser = new HighPerformanceParser();
        private static readonly TimeSpan ProgressDialogDelay = TimeSpan.FromMilliseconds(300);

        public static async Task<OrderedWordCounting> ParseAsync(string path, Encoding encoding)
        {
            using var cancellationTokenSource = new CancellationTokenSource();
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

            Task progressDialogDelayTask = Task.Delay(ProgressDialogDelay);
            await Task.WhenAny(countingTask, progressDialogDelayTask);
            if (progressDialogDelayTask.IsCompleted)
            {
                using var progressDialog = new ProgressDialog(countingTask, cancellationTokenSource);
                progressDialog.ShowDialog();
            }

            return countingTask.Result;
        }
    }
}
