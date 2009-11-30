using System;
using System.Collections.Generic;
using System.Text;

namespace GistBoard
{
    internal class Gist
    {

        private String m_fileName;
        private String m_contents;
        private bool m_private;

        public String Filename
        {
            get { return m_fileName; }
            set { m_fileName = value; }
        }

        public String Contents
        {
            get { return m_contents; }
            set { m_contents = value; }
        }

        public bool Private
        {
            get { return m_private; }
            set { m_private = value; }
        }

    }
}
