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
