using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
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

        private void OnParseButtonClick(object sender, EventArgs e)
        {
            using var openFileDialog = CreateOpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Encoding encoding = GetSelectedEncoding();
                using var parseFileDialog = new ParseFileDialog(openFileDialog.FileName, encoding);
                if (parseFileDialog.ShowDialog() == DialogResult.OK)
                {
                    orderedWordCounting = parseFileDialog.OrderedWordCounting;
                    UpdateFileTextBox(openFileDialog.FileName);
                    UpdateDataGridView();
                }
            }
        }

        private static OpenFileDialog CreateOpenFileDialog() =>
            new OpenFileDialog
            {
                Title = "Parse File",
                RestoreDirectory = true,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
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
