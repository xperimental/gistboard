using System;
using System.Collections.Generic;
using System.Text;

namespace GistBoard
{
    static class GistServer
    {
        internal static void Post(Gist gist)
        {
            String user = Config.Instance.User;
            String token = Config.Instance.Token;

            if (user == null || token == null)
            {
                throw new ArgumentException("Need login data!");
            }

            throw new NotImplementedException("Not implemented!");
        }
    }
}
