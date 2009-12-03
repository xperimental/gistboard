namespace GistBoard
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// The ConfigForm enables the user to enter his login information for
    /// github.
    /// </summary>
    internal partial class ConfigForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the ConfigForm class.
        /// The current configuration values are loaded from the Config
        /// singleton instance, so the configuration has to be initialized
        /// before displaying this window.
        /// </summary>
        public ConfigForm()
        {
            this.InitializeComponent();

            this.LoadValues();
        }

        /// <summary>
        /// Load the values from the configuration object into the
        /// window controls.
        /// </summary>
        private void LoadValues()
        {
            this.textUser.Text = Config.Instance.User;
            this.textToken.Text = Config.Instance.Token;
        }

        /// <summary>
        /// This method is called when the user clicks on the Save button.
        /// </summary>
        /// <param name="sender">Event sender (ignored).</param>
        /// <param name="e">Event arguments (ignored).</param>
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

        /// <summary>
        /// This method saves the values from the window controls
        /// to the configuration object.
        /// </summary>
        private void SaveValues()
        {
            Config.Instance.User = this.textUser.Text;
            Config.Instance.Token = this.textToken.Text;
            Config.Instance.Save();
        }
    }
}
