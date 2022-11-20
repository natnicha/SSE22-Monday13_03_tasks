using System;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

namespace Task1
{
    /// <summary>
    /// A class for generating and parsing HTTP-URIs.
    /// </summary>
    public class Url
    {
        const string VALID_CHARACTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789$-_.~";

        public string Scheme = "";
        public string Host = "";
        public int Port = 80;
        public string Path = "";
        public string Query = "";
        public string FragmentId = "";

        /// <summary>
        /// Constructor for parsing URLs.
        /// </summary>
        public Url(string urlStr)
        {
            string urlRegex = @"^(http|https|sftp|mailto|JDBC)(:\/{2})([\w*.-]*\w*)(:\d*)?(\/\w*%\w*)*(\?(\w*[-&=\w]*)*)*([#]\w*)?";
            var match = Regex.Match(urlStr, urlRegex, RegexOptions.IgnorePatternWhitespace);
            if (match.Success)
            {
                this.Scheme = match.Groups[1].ToString();
                this.Host = match.Groups[3].ToString();
                if (match.Groups[4].ToString() != "")
                {
                    this.Port = int.Parse(match.Groups[4].ToString().Replace(":", ""));
                }
                this.Path = Decode(match.Groups[5].ToString());
                this.Query = match.Groups[6].ToString().Replace("?", "");
                this.FragmentId = match.Groups[8].ToString().Replace("#", "");
            }
            else
            {
                throw new FormatException("Could not parse URL: " + urlStr);
            }

        }

        /// <summary>
        /// Constructor for building URLs from their components.
        /// </summary>
        public Url(string scheme, string host, int port, string path, string query, string fragmentId)
        {
            this.Scheme = scheme;
            this.Host = host;
            this.Port = port;
            this.Path = path;
            this.Query = query;
            this.FragmentId = fragmentId;
        }

        /// <summary>
        /// Returns the string representation of the URL.
        /// </summary>
        public override string ToString()
        {
            string url = Scheme+"://"+Host+":"+Port+Encode(Path)+"?"+Query+"#"+FragmentId;

            return url;
        }

        /// <summary>
        /// Encodes any special characters in the URL with an escaping sequence.
        /// </summary>
        public static string Encode(string s)
        {
            string result = s.Replace(" ", "%20");

            return result;
        }

        /// <summary>
        /// Decodes any escaping sequence in the URL with the corresponding characters.
        /// </summary>
        public static string Decode(string s)
        {
            return s.Replace("%20"," ");
        }
    }
}
