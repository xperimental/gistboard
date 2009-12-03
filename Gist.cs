namespace GistBoard
{
    internal class Gist
    {
        private string fileName;
        private string contents;
        private bool privateGist;

        public string Filename
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        public string Contents
        {
            get { return this.contents; }
            set { this.contents = value; }
        }

        public bool Private
        {
            get { return this.privateGist; }
            set { this.privateGist = value; }
        }
    }
}
