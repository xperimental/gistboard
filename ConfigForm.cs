namespace GistBoard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    internal partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();

            this.LoadValues();
        }

        private void LoadValues()
        {
            this.textUser.Text = Config.Instance.User;
            this.textToken.Text = Config.Instance.Token;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (this.textUser.Text.Length < 1)
            {
                MessageBox.Show(
                    "Please provide a user name!",
                    "GistBoard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (this.textToken.Text.Length != 32)
            {
                MessageBox.Show(
                    "Provided token has an invalid length!",
                    "GistBoard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            this.SaveValues();
            this.Close();
        }

        private void SaveValues()
        {
            Config.Instance.User = this.textUser.Text;
            Config.Instance.Token = this.textToken.Text;
            Config.Instance.Save();
        }
    }
}
