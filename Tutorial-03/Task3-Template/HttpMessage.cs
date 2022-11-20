using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.Net.WebRequestMethods;

namespace SSE
{
    public class HttpMessage
    {
        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUT = "PUT";
        public const string DELETE = "DELETE";
        public const string HEAD = "HEAD";
        public const string OPTIONS = "OPTIONS";
        public const string TRACE = "TRACE";

        public string Method = "";
        public string Host = "";
        public string Resource = "";
        public Dictionary<string, string> Headers = new Dictionary<string, string>();
        public string Content = "";
        public string StatusCode = "";
        public string StatusMessage = "";

        /// <summary>
        /// Construct an HTTP request.
        /// </summary>
        public HttpMessage(string method, string host, string resource, Dictionary<string, string> headers, string content)
        {
            this.Method = method;
            this.Host = host;
            this.Resource = resource;
            this.Headers = headers;
            if (Headers == null)
                Headers = new Dictionary<string, string>();
            this.Content = content;
            StatusCode = null;
            StatusMessage = null;
        }

        /// <summary>
        /// Construct an HTTP response.
        /// </summary>        
        public HttpMessage(string statusCode, string statusMessage, Dictionary<string, string> headers, string content)
        {
            this.Method = null;
            this.Host = null;
            this.Resource = null;
            this.Headers = headers;
            if (Headers == null)
                Headers = new Dictionary<string, string>();
            this.Content = content;
            StatusCode = statusCode;
            StatusMessage = statusMessage;
        }

        /// <summary>
        /// Constructs an HTTP message by parsing a (received) string.
        /// </summary>
        /// <param name="message"></param>
        public HttpMessage(string message)
        {
            //Response
            string methodRegex = @"(GET|HEAD|POST|PUT|DELETE|OPTIONS|TRACE)";
            this.Method = matchRequest(methodRegex, message, 1);

            string contentTypeRegex = @"(Content-Type: )([\w*\/]*)";
            this.Headers.Add("Content-Type", matchRequest(contentTypeRegex, message, 2));

            string contentLengthRegex = @"(Content-Length: )(\d*)";
            this.Headers.Add("Content-Length", matchRequest(contentLengthRegex, message, 2));
            
            string contentRegex = @"(\n)?(([\w( )])*(\n)?)$";
            this.Content = matchRequest(contentRegex, message, 2);

            string statusCodeRegex = @"(HTTP\/\d.\d )(\d*)";
            this.StatusCode = matchRequest(statusCodeRegex, message, 2);

            string statusMessageRegex = @"(HTTP\/\d.\d \d* )(\w*)";
            this.StatusMessage = matchRequest(statusMessageRegex, message, 2);


            //Request
            string resourceRegex = @"(GET|HEAD|POST|PUT|DELETE|OPTIONS|TRACE) ([\w*\/]*)";
            this.Resource = matchRequest(resourceRegex, message, 2);

            string hostRegex = @"(Host: )([\w*\/.]*)(\n)";
            this.Host = matchRequest(hostRegex, message, 2);

        }

        private string matchRequest(string regexStr, string requestMsg, int valuePosition)
        {
            var match = Regex.Match(requestMsg, regexStr, RegexOptions.None);
            if (match.Success)
            {
                return match.Groups[valuePosition].ToString();
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the string representation of the message.
        /// </summary>        
        public override string ToString()
        {
            // TODO: construct HTTP request/response message
            string url = "";
            // Request
            if (this.Method != ""){
                url += this.Method;
                url += " " + this.Resource + " HTTP/1.1";
                url += "\nHost: " + this.Host;
            }
            // Response
            if (this.Method == "")
            {
                url += "HTTP/1.1 " + this.StatusCode;
                url += " " + this.StatusMessage;
                url += "\nContent-Type: " + this.Headers["Content-Type"];
            }
            url += "\nContent-Length: " + this.Headers["Content-Length"] + "\n";
            url += "\n" + this.Content;
            return url;
        }
    }
}
