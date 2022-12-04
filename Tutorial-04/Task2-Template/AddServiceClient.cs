using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SSE
{
    public class AddServiceClient
    {
        private readonly string _serviceLocation;
        
        public AddServiceClient(string serviceLocation)
        {
            _serviceLocation = serviceLocation;
        }

        /// <summary>
        /// Sends a SOAP request via HTTP to a Web service endpoint.
        /// </summary>
        public async Task<int> Add(int a, int b)
        {
            // TODO: create and send SOAP message
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Content-Type", "text/xml; charset=utf-8");
            string content = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n" +
                "<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n" +
                "  <soap:Body>\r\n" +
                "    <Add xmlns=\"http://vsr-demo.informatik.tu-chemnitz.de/webservices/SoapWebService/\">\r\n" +
                "      <a>"+a+"</a>\r\n" +
                "      <b>"+b+"</b>\r\n" +
                "    </Add>\r\n" +
                "  </soap:Body>\r\n" +
                "</soap:Envelope>";

            headers.Add("Content-Length", content.Length.ToString());
            HttpMessage answer = await HttpRequest.Post(_serviceLocation, content, headers);

            return extractAnswer(answer.Content);
        }

        private int extractAnswer(string xmlResult) {
            if (xmlResult == null)
            {
                return 0;
            }

            string answerRegex = @"(?:<AddResult>)(?<answer>\d)(<\/AddResult>)";
            Match match = Regex.Match(xmlResult, answerRegex, RegexOptions.IgnorePatternWhitespace);
            if (match.Success)
            {
                return int.Parse(match.Groups["answer"].Value);
            }
            return 0;
        }
    }
}