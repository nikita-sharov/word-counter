using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;

namespace WordCounter.Wpf
{
    [SuppressMessage(
        "Security", "CA5392:Use DefaultDllImportSearchPaths attribute for P/Invokes",
        Justification = "Follows the Known DLLs mechanism")]
    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        public static void HideCloseButton(Window window)
        {
            // See: https://stackoverflow.com/a/958980/14273692
            const int GWL_STYLE = -16;
            const int WS_SYSMENU = 0x80000;
            IntPtr hwnd = new WindowInteropHelper(window).Handle;
            _ = SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);
        }
    }
}
