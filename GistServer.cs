namespace GistBoard
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web;

    /// <summary>
    /// This class provides the interface to the github server to save a Gist.
    /// </summary>
    internal static class GistServer
    {
        /// <summary>
        /// Contains the URL the Gists are sent to.
        /// </summary>
        private const string PostUrl = "http://gist.github.com/gists";

        /// <summary>
        /// Contains the URL-pattern for getting Gist contents.
        /// </summary>
        private const string GetUrl = "https://gist.github.com/{0}.txt";

        /// <summary>
        /// Send a new Gist to the server.
        /// </summary>
        /// <param name="gist">Gist to post on server.</param>
        /// <exception cref="ArgumentException">If the login data is missing.</exception>
        internal static void Post(Gist gist)
        {
            string user = Config.Instance.User;
            string token = Config.Instance.Token;

            if (user == null || token == null)
            {
                throw new ArgumentException("Need login data!");
            }

            byte[] data = PrepareFormData(user, token, gist);

            WebRequest request = WebRequest.Create(PostUrl);
            request.Method = "POST";
            request.ContentLength = data.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(data, 0, data.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine("Response code: " + ((HttpWebResponse)response).StatusCode);
        }

        /// <summary>
        /// Download a (single file) Gist from the github server.
        /// </summary>
        /// <param name="id">Id of Gist to download.</param>
        /// <returns>Gist object with contents set to Gist contents.</returns>
        internal static Gist Get(string id)
        {
            WebRequest request = WebRequest.Create(String.Format(GetUrl, id));
            WebResponse response = request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            StringBuilder sb = new StringBuilder();
            while (!reader.EndOfStream)
            {
                sb.AppendLine(reader.ReadLine());
            }

            string contents = sb.ToString();
            reader.Close();

            if (contents.Length > 0)
            {
                Gist result = new Gist();
                result.Contents = contents;

                return result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Prepares the urlencoded data sent to the server.
        /// </summary>
        /// <param name="user">Github user name.</param>
        /// <param name="token">Github API token.</param>
        /// <param name="gist">Object with Gist information.</param>
        /// <returns>Urlencoded data which will be sent to the server.</returns>
        private static byte[] PrepareFormData(string user, string token, Gist gist)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("login", user);
            parameters.Add("token", token);
            parameters.Add("file_ext[gistfile1]", string.Empty);
            parameters.Add("file_name[gistfile1]", gist.Filename);
            parameters.Add("file_contents[gistfile1]", gist.Contents);
            if (gist.Private)
            {
                parameters.Add("private", "on");
            }

            string[] tokens = new string[parameters.Keys.Count];
            int idx = 0;
            foreach (string key in parameters.Keys)
            {
                tokens[idx] = key + "=" + HttpUtility.UrlEncode(parameters[key]);
                idx++;
            }

            string data = string.Join("&", tokens);

            return Encoding.ASCII.GetBytes(data);
        }
    }
}
