using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace coded
{
    public class POP3client
    {
        string link { get; set; }
        public POP3client() {
            link = null;
        }
        public void getHeaders(string host, int port, Boolean useSSL,
            string user, string pass, int messageId, string mail){

            using (Pop3Client client = new Pop3Client())
            {
                client.Connect(host, port, useSSL);
                client.Authenticate(user, pass);
                MessageHeader header = client.GetMessageHeaders(messageId);
                RfcMailAddress from = header.From;
                if (from.HasValidMailAddress && from.Address.Equals(mail))
                {
                    Message message = client.GetMessage(messageId);
                    MessagePart html = message.FindFirstHtmlVersion();
                    if (html != null)
                    {
                        link = getTextOfLink(html.ToString());
                    }
                }
            }
        }

        public string getTextOfLink(string toCheck) {
            string pattern = @"<a href=""(?<url>.*?)""></a>";
            Match match;
            match = Regex.Match(toCheck, pattern, RegexOptions.IgnoreCase| RegexOptions.Compiled,TimeSpan.FromSeconds(1));
            Console.WriteLine("URL:"+match.Groups["url"]);
            return match.Groups["url"].ToString();
        }  
        
    }
}
