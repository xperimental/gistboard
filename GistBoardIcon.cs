namespace GistBoard
{
    using System;
    using System.Windows.Forms;
    using GistBoard.Properties;

    internal class GistBoardIcon
    {
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem contextPostItem;
        private ToolStripMenuItem contextQuitItem;
        private ToolStripMenuItem contextConfigItem;
        private NotifyIcon trayIcon;

        public GistBoardIcon()
        {
            this.contextMenu = new ContextMenuStrip();
            this.contextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenu_Opening);

            this.contextPostItem = new ToolStripMenuItem(Resources.Tray_Context_Post_Text);
            this.contextPostItem.Image = Resources.Tray_Context_Post_Icon;
            this.contextPostItem.Click += new EventHandler(this.ContextPostItem_Click);
            this.contextMenu.Items.Add(this.contextPostItem);

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

            Config.Init();
        }

        private void ContextConfigItem_Click(object sender, EventArgs e)
        {
            this.contextMenu.Enabled = false;

            ConfigForm dlg = new ConfigForm();
            dlg.ShowDialog();

            this.contextMenu.Enabled = true;
        }

        private void ContextQuitItem_Click(object sender, EventArgs e)
        {
            this.trayIcon.Visible = false;
            Application.Exit();
        }

        private void ContextPostItem_Click(object sender, EventArgs e)
        {
            this.contextMenu.Enabled = false;

            PostForm postForm = new PostForm();
            postForm.ShowDialog();

            this.contextMenu.Enabled = true;
        }

        private void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.contextPostItem.Enabled = Clipboard.ContainsText();
        }
    }
}
