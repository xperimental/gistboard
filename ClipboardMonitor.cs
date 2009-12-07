namespace GistBoard
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// This class contains a definition for a simple windows forms control,
    /// which registers itself as a clipboard monitor on creation.
    /// It raises an event, when the clipboard contents change.
    /// </summary>
    internal class ClipboardMonitor : Control
    {
        /// <summary>
        /// Contains the handle of the next clipboard monitor in the chain.
        /// </summary>
        private IntPtr? nextClipboardViewer = null;

        /// <summary>
        /// Initializes a new instance of the ClipboardMonitor class. The created
        /// control is added as a clipboard monitor.
        /// </summary>
        public ClipboardMonitor()
            : base()
        {
            this.CreateControl();

            this.nextClipboardViewer = NativeMethods.SetClipboardViewer(this.Handle);
        }

        /// <summary>
        /// This event is raised, when the clipboard contents change.
        /// </summary>
        public event EventHandler ClipboardChanged;

        /// <summary>
        /// Windows message handling routine.
        /// </summary>
        /// <param name="m">Reference to windows message.</param>
        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_DRAWCLIPBOARD:
                    if (this.ClipboardChanged != null)
                    {
                        this.ClipboardChanged.BeginInvoke(this, null, null, null);
                    }

                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        /// <summary>
        /// Called, when the control is destroyed. This unregisters the clipboard
        /// monitor.
        /// </summary>
        /// <param name="e">Event arguments (ignored).</param>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (this.nextClipboardViewer != null)
            {
                NativeMethods.ChangeClipboardChain(this.Handle, this.nextClipboardViewer.Value);
                this.nextClipboardViewer = null;
            }

            base.OnHandleDestroyed(e);
        }
    }
}
