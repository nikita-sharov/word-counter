using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace WordCounter.Wpf
{
    public partial class ParseFileDialog : Window
    {
        public ParseFileDialog(string path, Encoding encoding)
            : this(new HighPerformanceParser(), path, encoding)
        {
        }

        public ParseFileDialog(IParser parser, string path, Encoding encoding)
        {
            Parser = parser;
            Path = path;
            Encoding = encoding;
            InitializeComponent();
            UpdateDialogTitle();
        }

        public IParser Parser { get; private set; }

        public string Path { get; private set; }

        public Encoding Encoding { get; private set; }

        public IEnumerable<KeyValuePair<string, int>> OrderedWordCounting { get; private set; } =
            new List<KeyValuePair<string, int>>();

        private CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

        private void UpdateDialogTitle()
        {
            var fileInfo = new FileInfo(Path);
            Title += $" {fileInfo.Name}";
        }

        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            NativeMethods.HideCloseButton(this);
            try
            {
                OrderedWordCounting = await Task.Run(() =>
                {
                    try
                    {
                        return Parser.ParseAsync(Path, Encoding, CancellationTokenSource.Token)
                            .ContinueWith(task => task.Result.OrderByWordCountDescending(), TaskScheduler.Default);
                    }
                    catch (OperationCanceledException ex)
                    {
                        return Task.FromCanceled<IOrderedEnumerable<KeyValuePair<string, int>>>(ex.CancellationToken);
                    }
                });

                DialogResult = true;
            }
            catch (OperationCanceledException)
            {
                DialogResult = false;
            }

            Close();
        }

        private void OnCancelButtonClick(object sender, RoutedEventArgs e)
        {
            CancellationTokenSource.Cancel();
            cancelButton.IsEnabled = false;
            Title = "Canceling";
        }

        private void OnClosed(object sender, EventArgs e)
        {
            CancellationTokenSource.Dispose();
        }
    }
}
