namespace GistBoard
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// This class contains the entry point for the application.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            GistBoardIcon icon = new GistBoardIcon();
            Application.Run();
        }
    }
}
