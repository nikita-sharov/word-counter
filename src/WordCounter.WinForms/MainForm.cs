using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordCounter.WinForms
{
    internal partial class MainForm : Form
    {
        private OrderedWordCounting orderedWordCounting;

        public MainForm()
        {
            InitializeComponent();
            SetFormTitle();
            PopulateEncodingComboBox();
            CustomizeDataGridView();
        }

        private void SetFormTitle()
        {
            Text = ApplicationInfo.Title;
        }

        private void PopulateEncodingComboBox()
        {
            encodingComboBox.DisplayMember = nameof(CustomEncodingInfo.DisplayName);
            encodingComboBox.Items.AddRange(SupportedEncoding.GetEncodings());
            encodingComboBox.SelectedItem = CustomEncodingInfo.ANSI;
        }

        private void CustomizeDataGridView()
        {
            dataGridView.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private async void OnParseButtonClick(object sender, EventArgs e)
        {
            using var openFileDialog = CreateOpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Encoding encoding = GetSelectedEncoding();
                try
                {
                    orderedWordCounting = await ParserHelper.ParseAsync(openFileDialog.FileName, encoding);
                    UpdateFileTextBox(openFileDialog.FileName);
                    UpdateDataGridView();
                }
                catch (AggregateException aggregateException)
                {
                    aggregateException.Handle(innerException => innerException is OperationCanceledException);
                }
            }
        }

        private static OpenFileDialog CreateOpenFileDialog() =>
            new OpenFileDialog
            {
                Title = "Parse File",
                RestoreDirectory = true,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                Multiselect = false,
                CheckFileExists = true
            };

        private Encoding GetSelectedEncoding()
        {
            return SupportedEncoding.GetEncoding(encodingComboBox.SelectedItem as CustomEncodingInfo);
        }

        private void UpdateFileTextBox(string path)
        {
            var fileInfo = new FileInfo(path);
            fileTextBox.Text = fileInfo.Name;
        }

        private void UpdateDataGridView()
        {
            dataGridView.Rows.Clear();
            dataGridView.RowCount = orderedWordCounting.Count;
        }

        private void OnDataGridViewCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            KeyValuePair<string, int> wordCount = orderedWordCounting[e.RowIndex];
            if (e.ColumnIndex == 0)
            {
                e.Value = wordCount.Key;
            }
            else if (e.ColumnIndex == 1)
            {
                e.Value = wordCount.Value.ToString("N0", CultureInfo.CurrentCulture);
            }
            else
            {
                Debug.Fail($"Unexpected column index of {e.ColumnIndex}.");
            }
        }

        private void OnEncodingComboBoxSelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileTextBox.Text))
            {
                // re-open / re-parse file with the selected encoding
            }
        }
    }
}
