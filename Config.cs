using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace GistBoard
{
    [XmlRoot()]
    public class Config
    {
        private static Config instance;
        private static readonly String ConfigFile = "GistBoard.config.xml";

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

        private static Config Load(string ConfigFile)
        {
            FileStream stream = new FileStream(ConfigFile, FileMode.Open);
            XmlSerializer seria = new XmlSerializer(typeof(Config));
            Config result = (Config)seria.Deserialize(stream);
            stream.Close();
            return result;
        }

        private String user;
        private String token;

        [XmlElement()]
        public String User
        {
            get { return user; }
            set { user = value; }
        }

        [XmlElement()]
        public String Token
        {
            get { return token; }
            set { token = value; }
        }

        internal void Save()
        {
            FileStream stream = new FileStream("GistBoard.config.xml", FileMode.Create);
            XmlSerializer seria = new XmlSerializer(typeof(Config));
            seria.Serialize(stream, this);
            stream.Close();
        }
    }
}
