using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GistBoard
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            LoadValues();
        }

        private void LoadValues()
        {
            m_textUser.Text = Config.Instance.User;
            m_textToken.Text = Config.Instance.Token;
        }

        private void m_buttonSave_Click(object sender, EventArgs e)
        {
            if (m_textUser.Text.Length < 1)
            {
                MessageBox.Show("Please provide a user name!", "GistBoard",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (m_textToken.Text.Length != 32)
            {
                MessageBox.Show("Provided token has an invalid length!", "GistBoard",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveValues();
            this.Close();
        }

        private void SaveValues()
        {
            Config.Instance.User = m_textUser.Text;
            Config.Instance.Token = m_textToken.Text;
            Config.Instance.Save();
        }
    }
}
