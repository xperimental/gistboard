using System;
using System.Windows.Forms;
using GistBoard.Properties;
using System.Threading;

namespace GistBoard
{
    internal class GistBoardIcon
    {

        ContextMenuStrip m_contextMenu;
        ToolStripMenuItem m_contextPostItem;
        ToolStripMenuItem m_contextQuitItem;
        ToolStripMenuItem m_contextConfigItem;
        NotifyIcon m_trayIcon;

        public GistBoardIcon()
        {
            m_contextMenu = new ContextMenuStrip();
            m_contextMenu.Opening += new System.ComponentModel.CancelEventHandler(ContextMenu_Opening);

            m_contextPostItem = new ToolStripMenuItem(Resources.Tray_Context_Post_Text);
            m_contextPostItem.Image = Resources.Tray_Context_Post_Icon;
            m_contextPostItem.Click += new EventHandler(ContextPostItem_Click);
            m_contextMenu.Items.Add(m_contextPostItem);

            m_contextMenu.Items.Add(new ToolStripSeparator());

            m_contextConfigItem = new ToolStripMenuItem(Resources.Tray_Context_Config_Text);
            m_contextConfigItem.Image = Resources.Tray_Context_Config_Icon;
            m_contextConfigItem.Click += new EventHandler(ContextConfigItem_Click);
            m_contextMenu.Items.Add(m_contextConfigItem);

            m_contextQuitItem = new ToolStripMenuItem(Resources.Tray_Context_Quit_Text);
            m_contextQuitItem.Click += new EventHandler(ContextQuitItem_Click);
            m_contextMenu.Items.Add(m_contextQuitItem);

            m_trayIcon = new NotifyIcon();
            m_trayIcon.Icon = Resources.Tray_Icon;
            m_trayIcon.Text = Resources.Tray_Text;
            m_trayIcon.ContextMenuStrip = m_contextMenu;
            m_trayIcon.Visible = true;

            Config.Init();
        }

        void ContextConfigItem_Click(object sender, EventArgs e)
        {
            m_contextMenu.Enabled = false;

            ConfigForm dlg = new ConfigForm();
            dlg.ShowDialog();

            m_contextMenu.Enabled = true;
        }

        void ContextQuitItem_Click(object sender, EventArgs e)
        {
            m_trayIcon.Visible = false;
            Application.Exit();
        }

        void ContextPostItem_Click(object sender, EventArgs e)
        {
            m_contextMenu.Enabled = false;

            PostForm postForm = new PostForm();
            postForm.ShowDialog();

            m_contextMenu.Enabled = true;
        }

        void ContextMenu_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            m_contextPostItem.Enabled = Clipboard.ContainsText();
        }

    }
}
