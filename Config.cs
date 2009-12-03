namespace GistBoard
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    /// This singleton class contains the application configuration.
    /// It also provides methods to load and save the configuration
    /// from / to a file.
    /// </summary>
    [XmlRoot()]
    public class Config
    {
        /// <summary>
        /// Default configuration file.
        /// </summary>
        private static readonly string ConfigFile = "GistBoard.config.xml";

        /// <summary>
        /// Contains the singleton instance once its initialized.
        /// </summary>
        private static Config instance;

        /// <summary>
        /// Contains the github user name.
        /// </summary>
        private string user;

        /// <summary>
        /// Contains the github API token.
        /// </summary>
        private string token;

        /// <summary>
        /// Gets the singleton instance once it has been initialized.
        /// </summary>
        public static Config Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Gets or sets the github user name.
        /// </summary>
        [XmlElement()]
        public string User
        {
            get { return this.user; }
            set { this.user = value; }
        }

        /// <summary>
        /// Gets or sets the github API token.
        /// </summary>
        [XmlElement()]
        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }

        /// <summary>
        /// Initializes the configuration. If a configuration file exists, the
        /// file will be read. Otherwise a new configuration is created.
        /// </summary>
        public static void Init()
        {
            try
            {
                instance = Load(ConfigFile);
            }
            catch (Exception)
            {
                instance = new Config();
            }
        }

        /// <summary>
        /// Saves the configuration to the default configuration file.
        /// </summary>
        internal void Save()
        {
            FileStream stream = new FileStream("GistBoard.config.xml", FileMode.Create);
            XmlSerializer seria = new XmlSerializer(typeof(Config));
            seria.Serialize(stream, this);
            stream.Close();
        }

        /// <summary>
        /// Loads a configuration object from the specified file.
        /// </summary>
        /// <param name="configFile">File to load configuration from.</param>
        /// <returns>Configuration object read from file.</returns>
        private static Config Load(string configFile)
        {
            FileStream stream = new FileStream(configFile, FileMode.Open);
            XmlSerializer seria = new XmlSerializer(typeof(Config));
            Config result = (Config)seria.Deserialize(stream);
            stream.Close();
            return result;
        }
    }
}
