namespace GistBoard
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The PostForm window is shown to the user, so that he can
    /// enter the information required to create a new Gist.
    /// The information is sent to the server via the GistServer class
    /// if the user clicks on the Post button.
    /// </summary>
    public partial class PostForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the PostForm class.
        /// The Gist contents are read from the clipboard.
        /// </summary>
        public PostForm()
        {
            this.InitializeComponent();

            this.textContent.Text = Clipboard.GetText();
        }

        /// <summary>
        /// This method is called when the user clicks on the
        /// Post button. If all information is present, then the Gist
        /// is sent to the server.
        /// </summary>
        /// <param name="sender">Event sender (ignored).</param>
        /// <param name="e">Event arguments (ignored).</param>
        private void ButtonPost_Click(object sender, EventArgs e)
        {
            Gist gist = new Gist();
            gist.Filename = this.textFile.Text;
            gist.Contents = this.textContent.Text;
            gist.Private = this.checkPrivate.Checked;

            try
            {
                GistServer.Post(gist);
                this.DialogResult = DialogResult.OK;
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
