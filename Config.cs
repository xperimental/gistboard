namespace GistBoard
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    [XmlRoot()]
    public class Config
    {
        private static readonly string ConfigFile = "GistBoard.config.xml";

        private static Config instance;

        private string user;
        private string token;

        public static Config Instance
        {
            get { return instance; }
        }

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

        [XmlElement()]
        public string User
        {
            get { return this.user; }
            set { this.user = value; }
        }

        [XmlElement()]
        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }

        internal void Save()
        {
            FileStream stream = new FileStream("GistBoard.config.xml", FileMode.Create);
            XmlSerializer seria = new XmlSerializer(typeof(Config));
            seria.Serialize(stream, this);
            stream.Close();
        }

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
