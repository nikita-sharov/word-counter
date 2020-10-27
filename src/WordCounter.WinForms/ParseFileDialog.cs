using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCounter.WinForms
{
    public partial class ParseFileDialog : Form
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public ParseFileDialog(string path, Encoding encoding)
        {
            Path = path;
            Encoding = encoding;
            InitializeComponent();
        }

        public string Path { get; private set; }

        public Encoding Encoding { get; private set; }

        public WordCounting WordCounting { get; private set; } = new WordCounting();

        private async void OnLoad(object sender, EventArgs e)
        {
            try
            {
                WordCounting = await WordCounting.ParseAsync(Path, Encoding, cancellationTokenSource.Token);
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
            cancellationTokenSource.Cancel();
        }
    }
}
