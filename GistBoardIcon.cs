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
            contextMenu = new ContextMenuStrip();
            contextMenu.Opening += new System.ComponentModel.CancelEventHandler(ContextMenu_Opening);

            contextPostItem = new ToolStripMenuItem(Resources.Tray_Context_Post_Text);
            contextPostItem.Image = Resources.Tray_Context_Post_Icon;
            contextPostItem.Click += new EventHandler(ContextPostItem_Click);
            contextMenu.Items.Add(contextPostItem);

            contextMenu.Items.Add(new ToolStripSeparator());

            contextConfigItem = new ToolStripMenuItem(Resources.Tray_Context_Config_Text);
            contextConfigItem.Image = Resources.Tray_Context_Config_Icon;
            contextConfigItem.Click += new EventHandler(ContextConfigItem_Click);
            contextMenu.Items.Add(contextConfigItem);

            contextQuitItem = new ToolStripMenuItem(Resources.Tray_Context_Quit_Text);
            contextQuitItem.Click += new EventHandler(ContextQuitItem_Click);
            contextMenu.Items.Add(contextQuitItem);

            trayIcon = new NotifyIcon();
            trayIcon.Icon = Resources.Tray_Icon;
            trayIcon.Text = Resources.Tray_Text;
            trayIcon.ContextMenuStrip = contextMenu;
            trayIcon.Visible = true;

            Config.Init();
        }

        void ContextConfigItem_Click(object sender, EventArgs e)
        {
            contextMenu.Enabled = false;

            ConfigForm dlg = new ConfigForm();
            dlg.ShowDialog();

            contextMenu.Enabled = true;
        }

        void ContextQuitItem_Click(object sender, EventArgs e)
        {
            trayIcon.Visible = false;
            Application.Exit();
        }

        void ContextPostItem_Click(object sender, EventArgs e)
        {
            contextMenu.Enabled = false;

            PostForm postForm = new PostForm();
            postForm.ShowDialog();

            contextMenu.Enabled = true;
        }

        void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            contextPostItem.Enabled = Clipboard.ContainsText();
        }
    }
}
