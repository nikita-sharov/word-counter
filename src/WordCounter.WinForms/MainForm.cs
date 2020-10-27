using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WordCounter.WinForms
{
    internal partial class MainForm : Form
    {
        private Dictionary<int, KeyValuePair<string, int>> dataStore = null;

        public MainForm()
        {
            InitializeComponent();
            dataGridView1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            encodingComboBox.DisplayMember = nameof(CustomEncodingInfo.DisplayName);
            encodingComboBox.Items.AddRange(SupportedEncoding.GetEncodings());
            encodingComboBox.SelectedItem = CustomEncodingInfo.ANSI;

            Text = ApplicationInfo.Title;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////using (var dialog = new ProgressDialog())
            ////{
            ////    DialogResult result = dialog.ShowDialog();
            ////    Task.Delay(2000);
            ////    dialog.Value = 18;
            ////    dialog.Close();
            ////    if (result == DialogResult.Cancel)
            ////    {
            ////    }
            ////}

            using var openFileDialog = CreateOpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Encoding encoding = GetSelectedEncoding();
                Dictionary<string, int> stats = CountWords(openFileDialog.FileName, encoding);
                dataStore = CreateDataStore(stats);
                fileTextBox.Text = openFileDialog.FileName;
                dataGridView1.Rows.Clear();
                dataGridView1.RowCount = dataStore.Count;
            }
        }

        private void DoStuff(string path)
        {
            Encoding encoding = GetSelectedEncoding();
            Dictionary<string, int> stats = CountWords(path, encoding);
            dataStore = CreateDataStore(stats);
            dataGridView1.Rows.Clear();
            dataGridView1.RowCount = dataStore.Count;
        }

        private static OpenFileDialog CreateOpenFileDialog() =>
            new OpenFileDialog
            {
                Title = "Parse File",
                InitialDirectory = Environment.CurrentDirectory,
                RestoreDirectory = true,
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                ////FilterIndex = 2,
                CheckFileExists = true
            };

        private Encoding GetSelectedEncoding()
        {
            return SupportedEncoding.GetEncoding(encodingComboBox.SelectedItem as CustomEncodingInfo);
        }

        private Dictionary<string, int> CountWords(string fileName, Encoding encoding)
        {
            string[] lines = File.ReadAllLines(fileName, encoding);
            return CountWords(lines);
        }

        public Dictionary<int, KeyValuePair<string, int>> CreateDataStore(Dictionary<string, int> stats)
        {
            int rowIndex = 0;
            var store = new Dictionary<int, KeyValuePair<string, int>>();
            IOrderedEnumerable<KeyValuePair<string, int>> pairs = stats.OrderByDescending(pair => pair.Value);
            foreach (var pair in pairs)
            {
                store.Add(rowIndex, pair);
                rowIndex += 1;
            }

            return store;
        }

        public DataTable CreateDataTable(Dictionary<string, int> stats)
        {
            var table = new DataTable();
            table.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("Word", typeof(string)),
                new DataColumn("Count", typeof(int))
            });

            foreach (KeyValuePair<string, int> pair in stats)
            {
                table.Rows.Add(new object[] { pair.Key, pair.Value });
            }

            return table;
        }

        private Dictionary<string, int> CountWords(string[] lines)
        {
            var stats = new Dictionary<string, int>();
            foreach (string line in lines)
            {
                //string trimmedLine = line.Trim();
                ////string[] tokens = Regex.Split(trimmedLine, @"\s");
                string[] tokens = Regex.Split(line, @"\s+");
                foreach (var token in tokens)
                {
                    string key = token.ToString();
                    if (stats.ContainsKey(key))
                    {
                        stats[key] += 1;
                    }
                    else
                    {
                        stats.Add(key, 1);
                    }
                }
            }

            return stats;
        }

        private void dataGridView1_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            KeyValuePair<string, int> pair = dataStore[e.RowIndex];
            if (e.ColumnIndex == 0)
            {
                e.Value = pair.Key;
            }
            else if (e.ColumnIndex == 1)
            {
                e.Value = pair.Value.ToString("N0");
            }
            else
            {
                Debug.Fail("Unexpected column index of ");
            }
        }

        private void encodingComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(fileTextBox.Text))
            {
                Encoding encoding = GetSelectedEncoding();
                Dictionary<string, int> stats = CountWords(fileTextBox.Text, encoding);
                dataStore = CreateDataStore(stats);
                dataGridView1.Rows.Clear();
                dataGridView1.RowCount = dataStore.Count;
            }
        }
    }
}
