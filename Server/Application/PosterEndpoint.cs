using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Site.Server.Application
{
    public sealed record PosterEndpoint
    {
        public PosterEndpoint(string domain, string method, string token)
        {
            BaseUrl = $"https://{domain}.joinposter.com/api/";
            Method = method;
            Token = token;
            Params = new Dictionary<string, string>();
        }

        private string BaseUrl { get; }

        public string Method { get; set; }

        private string Token { get; }

        public Dictionary<string, string> Params { get; set; }

        public void AddParam(string key, string value)
        {
            Params[key] = value;
        }

        public override string ToString()
        {
            StringBuilder url = new StringBuilder($"{BaseUrl}{Method}?token={Token}");

            foreach (var param in Params)
            {
                url.Append($"&{param.Key}={param.Value}");
            }

            return url.ToString();
        }
    }
}