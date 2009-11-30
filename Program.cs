using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GistBoard
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GistBoardIcon icon = new GistBoardIcon();
            Application.Run();
        }
    }
}
