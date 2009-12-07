namespace GistBoard
{
    using System;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using GistBoard.Properties;

    /// <summary>
    /// This class contains the definition of the systray icon, which
    /// is the main user interface of this application.
    /// </summary>
    internal class GistBoardIcon
    {
        /// <summary>
        /// Pattern of a gist definition in the clipboard.
        /// </summary>
        private const string GistPattern = "\\[gist:([0-9a-z]+)\\]";

        /// <summary>
        /// Contains the context menu strip.
        /// </summary>
        private ContextMenuStrip contextMenu;

        /// <summary>
        /// Contains the context menu item used to post a Gist.
        /// </summary>
        private ToolStripMenuItem contextPostItem;

        /// <summary>
        /// Contains the context menu item used to download a Gist from the server.
        /// </summary>
        private ToolStripMenuItem contextDownloadItem;

        /// <summary>
        /// Contains the context menu item used to quit the application.
        /// </summary>
        private ToolStripMenuItem contextQuitItem;

        /// <summary>
        /// Contains the context menu item used to display the configuration window.
        /// </summary>
        private ToolStripMenuItem contextConfigItem;

        /// <summary>
        /// Contains the systray icon.
        /// </summary>
        private NotifyIcon trayIcon;

        /// <summary>
        /// Contains the windows control monitoring the clipboard contents.
        /// </summary>
        private ClipboardMonitor clipboardListener;

        /// <summary>
        /// Initializes a new instance of the GistBoardIcon class.
        /// </summary>
        public GistBoardIcon()
        {
            this.contextMenu = new ContextMenuStrip();
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);

            this.contextPostItem = new ToolStripMenuItem(Resources.Tray_Context_Post_Text);
            this.contextPostItem.Image = Resources.Tray_Context_Post_Icon;
            this.contextPostItem.Click += new EventHandler(this.ContextPostItem_Click);
            this.contextMenu.Items.Add(this.contextPostItem);

            this.contextDownloadItem = new ToolStripMenuItem(Resources.Tray_Context_Download_Text);
            this.contextDownloadItem.Image = Resources.Tray_Context_Download_Icon;
            this.contextDownloadItem.Click += new EventHandler(this.ContextDownloadItem_Click);
            this.contextMenu.Items.Add(this.contextDownloadItem);

            this.contextMenu.Items.Add(new ToolStripSeparator());

            this.contextConfigItem = new ToolStripMenuItem(Resources.Tray_Context_Config_Text);
            this.contextConfigItem.Image = Resources.Tray_Context_Config_Icon;
            this.contextConfigItem.Click += new EventHandler(this.ContextConfigItem_Click);
            this.contextMenu.Items.Add(this.contextConfigItem);

            this.contextQuitItem = new ToolStripMenuItem(Resources.Tray_Context_Quit_Text);
            this.contextQuitItem.Click += new EventHandler(this.ContextQuitItem_Click);
            this.contextMenu.Items.Add(this.contextQuitItem);

            this.trayIcon = new NotifyIcon();
            this.trayIcon.Icon = Resources.Tray_Icon;
            this.trayIcon.Text = Resources.Tray_Text;
            this.trayIcon.ContextMenuStrip = this.contextMenu;
            this.trayIcon.Visible = true;

            this.clipboardListener = new ClipboardMonitor();
            this.clipboardListener.ClipboardChanged += new EventHandler(this.OnClipboardChanged);

            Config.Init();
        }

        /// <summary>
        /// Shows a info balloon to the user.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="icon">Icon to use for balloon.</param>
        internal void ShowInfo(string text, ToolTipIcon icon)
        {
            this.trayIcon.ShowBalloonTip(1000, "GistBoard", text, icon);
        }

        /// <summary>
        /// This method is called when the user clicks on the download context
        /// menu item.
        /// </summary>
        /// <param name="sender">Event sender (ignored).</param>
        /// <param name="e">Event arguments (ignored).</param>
        private void ContextDownloadItem_Click(object sender, EventArgs e)
        {
            DownloadForm dlg = new DownloadForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                this.GetGist(dlg.GistId);
            }
        }

        /// <summary>
        /// Called, when the clipboard contents change.
        /// </summary>
        /// <param name="sender">Monitor object sending event (ignored).</param>
        /// <param name="e">Always null (ignored).</param>
        private void OnClipboardChanged(object sender, EventArgs e)
        {
            string contents = Clipboard.GetText();
            Regex gistRegex = new Regex(GistPattern);
            Match gistMatch = gistRegex.Match(contents);
            if (gistMatch.Success)
            {
                this.GetGist(gistMatch.Groups[1].Value);
            }
        }

        /// <summary>
        /// Download a gist with a specific id from the server and
        /// set the clipboard to its contents.
        /// </summary>
        /// <param name="id">Id of gist to download.</param>
        private void GetGist(string id)
        {
            Gist content = GistServer.Get((string)id);

            Clipboard.SetText(content.Contents);
            this.ShowInfo(String.Format(Resources.Info_Get, id), ToolTipIcon.Info);
        }

        /// <summary>
        /// This method is called when the user clicks the configuration
        /// context menu item.
        /// </summary>
        /// <param name="sender">Event sender (ignored).</param>
        /// <param name="e">Event arguments (ignored).</param>
        private void ContextConfigItem_Click(object sender, EventArgs e)
        {
            this.contextMenu.Enabled = false;

            ConfigForm dlg = new ConfigForm();
            dlg.ShowDialog();

            this.contextMenu.Enabled = true;
        }

        /// <summary>
        /// This method is called, when the user clicks on the
        /// context menu item used to quit the application.
        /// </summary>
        /// <param name="sender">Event sender (ignored).</param>
        /// <param name="e">Event arguments (ignored).</param>
        private void ContextQuitItem_Click(object sender, EventArgs e)
        {
            this.trayIcon.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// This method is called, when the user clicks on the context
        /// menu item which is used to post a new Gist to the server.
        /// </summary>
        /// <param name="sender">Event sender (ignored).</param>
        /// <param name="e">Event arguments (ignored).</param>
        private void ContextPostItem_Click(object sender, EventArgs e)
        {
            this.contextMenu.Enabled = false;

            PostForm postForm = new PostForm();
            if (postForm.ShowDialog() == DialogResult.OK)
            {
                this.ShowInfo(Resources.Info_Post, ToolTipIcon.Info);
            }

            this.contextMenu.Enabled = true;
        }

        /// <summary>
        /// This method is called before the context menu is displayed.
        /// It checks, if the clipboard contains content which can be sent
        /// to the server as a Gist and enables the Post item accordingly.
        /// </summary>
        /// <param name="sender">Event sender (ignored).</param>
        /// <param name="e">Event arguments (ignored).</param>
        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.contextPostItem.Enabled = Clipboard.ContainsText();
        }
    }
}
