using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCounter.WinForms
{
    internal partial class ProgressDialog : Form
    {
        private static readonly TimeSpan MinDisplayDuration = TimeSpan.FromMilliseconds(500);

        private readonly Task _task;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public ProgressDialog(Task task, CancellationTokenSource cancellationTokenSource)
        {
            _task = task;
            _cancellationTokenSource = cancellationTokenSource;
            InitializeComponent();
        }

        private async void OnLoad(object sender, EventArgs e)
        {
            await Task.Delay(MinDisplayDuration);
            try
            {
                await _task;
            }
            catch (TaskCanceledException)
            {
                // ignore
            }

            Close();
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
            cancelButton.Enabled = false;
#pragma warning disable CA1303 // Do not pass literals as localized parameters
            Text = "Canceling";
#pragma warning restore CA1303 // Do not pass literals as localized parameters
        }
    }
}
