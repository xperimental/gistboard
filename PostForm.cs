namespace GistBoard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public partial class PostForm : Form
    {
        public PostForm()
        {
            this.InitializeComponent();

            m_textContent.Text = Clipboard.GetText();
        }

        private void ButtonPost_Click(object sender, EventArgs e)
        {
            Gist gist = new Gist();
            gist.Filename = this.m_textFile.Text;
            gist.Contents = this.m_textContent.Text;
            gist.Private = this.m_checkPrivate.Checked;

            try
            {
                GistServer.Post(gist);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Posting gist wasn't successful: " + ex.Message,
                    "GistBoard",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
