namespace GistBoard
{
    using System;
    using System.Windows.Forms;

    public partial class PostForm : Form
    {
        public PostForm()
        {
            this.InitializeComponent();

            this.textContent.Text = Clipboard.GetText();
        }

        private void ButtonPost_Click(object sender, EventArgs e)
        {
            Gist gist = new Gist();
            gist.Filename = this.textFile.Text;
            gist.Contents = this.textContent.Text;
            gist.Private = this.checkPrivate.Checked;

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
