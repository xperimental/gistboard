namespace GistBoard
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// This form contains a simple input box to enable the user
    /// to enter a id of a Gist he wants to download.
    /// </summary>
    internal partial class DownloadForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the DownloadForm class.
        /// </summary>
        public DownloadForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Gets the gist id entered in the dialog.
        /// </summary>
        public string GistId
        {
            get { return this.textId.Text; }
        }

        /// <summary>
        /// Called, when the user clicks the ok button or presses return.
        /// </summary>
        /// <param name="sender">Event sender (ignored).</param>
        /// <param name="e">Event arguments (ignored).</param>
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
