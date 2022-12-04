using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace SSE
{
    public class SoapClient
    {
        private SoapClient()
        {
        }

        public static async Task<object> Invoke(string url, string ns, string operationName, Dictionary<String,object> parameters)
        {
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "text/xml; charset=utf-8");
            string message = "<soap12:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap12=\"http://www.w3.org/2003/05/soap-envelope\"><soap12:Body>\n";

            // TODO: Complete message body
            message += " <" + operationName + " xmlns=\""+ ns + "\">\r\n ";
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                message += "<" + parameter.Key + ">" + parameter.Value + "</" + parameter.Key + ">\r\n";
            }
            message += " </" + operationName + ">\r\n";
            message += "</soap12:Body></soap12:Envelope>";

            headers.Add("Content-Length", message.Length.ToString());

            // TODO Send HTTP request
            HttpMessage answer = await HttpRequest.Post(url, message, headers);
            // TODO Parse response 
            return extractAnswer(operationName, answer.Content);
        }

        private static object extractAnswer(string operationName, string xmlResult)
        {
            if (xmlResult == null)
            {
                return "";
            }
            string answerRegex = "(?:<" + operationName + @"Result>)(?<answer>(.*))(<\/" + operationName + "Result>)";
            Match match = Regex.Match(xmlResult, answerRegex, RegexOptions.IgnorePatternWhitespace);
            if (match.Success)
            {
                return match.Groups["answer"].Value;
            }
            return "";
        }
    }
}