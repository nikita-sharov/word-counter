using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace WordCounter.WinForms
{
    internal partial class MainForm : Form
    {
        private OrderedWordCounting wordCounting;

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

        private void OnParseButtonClick(object sender, EventArgs e)
        {
            using var openFileDialog = CreateOpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Encoding encoding = GetSelectedEncoding();
                using var parsingFileDialog = new ParseFileDialog(openFileDialog.FileName, encoding);
                if (parsingFileDialog.ShowDialog() == DialogResult.OK)
                {
                    wordCounting = OrderedWordCounting.OrderByWordCountDescending(parsingFileDialog.WordCounting);
                    fileTextBox.Text = openFileDialog.FileName;
                    UpdateDataGridView();
                }
            }
        }

        private static OpenFileDialog CreateOpenFileDialog() =>
            new OpenFileDialog
            {
                Title = "Parse File",
                ////InitialDirectory = Environment.CurrentDirectory,
                RestoreDirectory = true,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                Multiselect = false,
                CheckFileExists = true
            };

        private void UpdateDataGridView()
        {
            dataGridView.Rows.Clear();
            dataGridView.RowCount = wordCounting.Count;
        }

        private Encoding GetSelectedEncoding()
        {
            return SupportedEncoding.GetEncoding(encodingComboBox.SelectedItem as CustomEncodingInfo);
        }

        private void OnDataGridViewCellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            KeyValuePair<string, int> wordCount = wordCounting[e.RowIndex];
            if (e.ColumnIndex == 0)
            {
                e.Value = wordCount.Key;
            }
            else if (e.ColumnIndex == 1)
            {
                e.Value = wordCount.Value.ToString("N0");
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
                ////Encoding encoding = GetSelectedEncoding();
                ////Dictionary<string, int> stats = CountWords(fileTextBox.Text, encoding);
                ////dataStore = CreateDataStore(stats);
                ////dataGridView.Rows.Clear();
                ////dataGridView.RowCount = dataStore.Count;
            }
        }
    }
}
