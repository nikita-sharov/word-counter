using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace WordCounter.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Title = ApplicationInfo.Title;
            PopulateEncodingComboBox();
        }

        private void PopulateEncodingComboBox()
        {
            encodingComboBox.DisplayMemberPath = nameof(CustomEncodingInfo.DisplayName);
            IEnumerable<CustomEncodingInfo> encodings =
                SupportedEncoding.GetEncodings().OrderBy(e => e.DisplayName);

            foreach (CustomEncodingInfo encoding in encodings)
            {
                encodingComboBox.Items.Add(encoding);
            }

            encodingComboBox.SelectedItem = CustomEncodingInfo.ANSI;
        }

        private void OnParseButtonClick(object sender, RoutedEventArgs e)
        {
            var openFileDialog = CreateOpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Encoding encoding = GetSelectedEncoding();
                var parseFileDialog = new ParseFileDialog(openFileDialog.FileName, encoding);
                parseFileDialog.Owner = this;
                if (parseFileDialog.ShowDialog() == true)
                {
                    UpdateFileTextBox(openFileDialog.FileName);
                    dataGrid.ItemsSource = parseFileDialog.OrderedWordCounting;
                }
            }
        }

        private Encoding GetSelectedEncoding()
        {
            return SupportedEncoding.GetEncoding(encodingComboBox.SelectedItem as CustomEncodingInfo);
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

        private void UpdateFileTextBox(string path)
        {
            var fileInfo = new FileInfo(path);
            fileTextBox.Text = fileInfo.Name;
        }
    }
}
