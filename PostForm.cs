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
            InitializeComponent();

            m_textContent.Text = Clipboard.GetText();
        }

        private void m_buttonPost_Click(object sender, EventArgs e)
        {
            Gist gist = new Gist();
            gist.Filename = m_textFile.Text;
            gist.Contents = m_textContent.Text;
            gist.Private = m_checkPrivate.Checked;

            try {
                GistServer.Post(gist);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Posting gist wasn't successful: " + ex.Message,
                    "GistBoard", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
