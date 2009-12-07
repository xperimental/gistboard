namespace GistBoard
{
    using System;
    using System.Runtime.InteropServices;

    /// <summary>
    /// This class contains P/Invoke definitions for native methods used
    /// in the application.
    /// </summary>
    internal static class NativeMethods
    {
        /// <summary>
        /// Message ID of windows message sent when the clipboard contents change.
        /// </summary>
        public const int WM_DRAWCLIPBOARD = 0x308;

        [DllImport("user32.dll")]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
    }
}
