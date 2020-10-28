using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WordCounter.WinForms
{
    public partial class ParseFileDialog : Form
    {
        public ParseFileDialog(string path, Encoding encoding)
            : this(new MemoryEfficientParser(), path, encoding)
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

        public OrderedWordCounting OrderedWordCounting { get; private set; } = new OrderedWordCounting();

        private CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

        private void UpdateDialogTitle()
        {
            var fileInfo = new FileInfo(Path);
            Text += $" {fileInfo.Name}";
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            try
            {
                WordCounting counting = await Parser.ParseAsync(Path, Encoding, CancellationTokenSource.Token);
                OrderedWordCounting = OrderedWordCounting.OrderByWordCountDescending(counting);
                DialogResult = DialogResult.OK;
            }
            catch (OperationCanceledException)
            {
                DialogResult = DialogResult.Cancel;
            }

            Close();
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            CancellationTokenSource.Cancel();
        }
    }
}
