using System;
using System.Globalization;
using System.Windows.Forms;

namespace WordCounter.WinForms
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            CultureInfo.CurrentUICulture = CultureInfo.CurrentCulture;
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using var mainForm = new MainForm();
            Application.Run(mainForm);
        }
    }
}
