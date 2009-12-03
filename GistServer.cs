namespace GistBoard
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web;

    static class GistServer
    {
        private const string PostUrl = "http://gist.github.com/gists";

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

        private static byte[] PrepareFormData(string user, string token, Gist gist)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("login", user);
            parameters.Add("token", token);
            parameters.Add("file_ext[gistfile1]", string.Empty);
            parameters.Add("file_name[gistfile1]", gist.Filename);
            parameters.Add("file_contents[gistfile1]", gist.Contents);
            if (gist.Private)
                parameters.Add("private", "on");

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
