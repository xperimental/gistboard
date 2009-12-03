namespace GistBoard
{
    /// <summary>
    /// This class represents a Gist which should be sent to the server.
    /// </summary>
    internal class Gist
    {
        /// <summary>
        /// Contains the name of the code snippet.
        /// </summary>
        private string fileName;

        /// <summary>
        /// Contains the gist data.
        /// </summary>
        private string contents;

        /// <summary>
        /// True, if the gist should be marked private.
        /// </summary>
        private bool privateGist;

        /// <summary>
        /// Gets or sets the gist name.
        /// </summary>
        public string Filename
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        /// <summary>
        /// Gets or sets the gist contents.
        /// </summary>
        public string Contents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the gist
        /// should be marked private.
        /// </summary>
        public bool Private
        {
            get { return this.privateGist; }
            set { this.privateGist = value; }
        }
    }
}
