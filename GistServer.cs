using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Web;
using System.IO;

namespace GistBoard
{
    static class GistServer
    {

        private static readonly String PostUrl = "http://gist.github.com/gists";

        internal static void Post(Gist gist)
        {
            String user = Config.Instance.User;
            String token = Config.Instance.Token;

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
            Dictionary<String, String> parameters = new Dictionary<string, string>();
            parameters.Add("login", user);
            parameters.Add("token", token);
            parameters.Add("file_ext[gistfile1]", "");
            parameters.Add("file_name[gistfile1]", gist.Filename);
            parameters.Add("file_contents[gistfile1]", gist.Contents);
            if (gist.Private)
                parameters.Add("private", "on");

            String[] tokens = new String[parameters.Keys.Count];
            int idx = 0;
            foreach (String key in parameters.Keys)
            {
                tokens[idx] = key + "=" + HttpUtility.UrlEncode(parameters[key]);
                idx++;
            }

            String data = String.Join("&", tokens);

            return Encoding.ASCII.GetBytes(data);
        }
    }
}
