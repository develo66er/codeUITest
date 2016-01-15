
using OpenPop.Mime;
using OpenPop.Mime.Header;
using OpenPop.Pop3;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace coded
{
    public class POP3client
    {
        string link { get; set; }
        List<string> seenUids;
        const string mail = "WhiteLabel Site06 <noreply@showsite.rxnova.com>";
        const string pattern = @"<a href=""(?<url>.*?)""></a>";
        const string patternOfDate = @"\w-\w[:](1)(?<month>.*?)/(?<day>.*?)/(?<year>.*?) \w*";
        string[] months = { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct" ,"Nov", "Dec"};
        Pop3Client client;
        Match match;
        RfcMailAddress from;
        Message message;
        
        MessagePart html;
        
        string currentDate;
        
        string currentUid;
        public POP3client(string host, int port, Boolean useSSL, string user, string pass) {
            client = new Pop3Client();

            client.Connect(host, port, useSSL);
            client.Authenticate(user, pass);
            seenUids = new List<string>(0);
            DateTime time = System.DateTime.Now;
            convertCurTimeToStr(time);
            link = null;
        }
        public string getLink {
            get{ return link; } }
        public void convertCurTimeToStr(DateTime time) {
            currentDate = String.Format("{0} {1}",
               months[time.Month-1],time.Year);
        } 
        public Boolean fetchMessages() {
            string dateOfMessage;
            MessageHeader header;
           
            List<string> uids;
            
           
                uids = client.GetMessageUids();
                for (int i = 0; i < uids.Count; i++) {
                    header = client.GetMessageHeaders(i+1);
                    from = header.From;
                    Console.WriteLine(from);
                    dateOfMessage = header.Date;
                    Console.WriteLine(dateOfMessage);
                    //Console.WriteLine(currentDate);
                if (!dateOfMessage.Contains(currentDate)) continue;
                    currentUid = uids[i];
                    //Console.WriteLine(currentUid);
                if (!seenUids.Contains(currentUid)) {
                        //Console.WriteLine(from);
                        getHeader(i+1);
                        seenUids.Add(currentUid);
                    Console.WriteLine("link:"+link);
                    if (link != null) return true;
                    }
                
                //client.Disconnect();
            }
            return false;
        }
        public void getHeader(int messageId)
        {

            Console.WriteLine(from);
            if (from.HasValidMailAddress && from.Address.Equals(mail))
                {
                message = client.GetMessage(messageId);
                //Console.WriteLine(message);
                html = message.FindFirstHtmlVersion();
                Console.WriteLine(html);
                if (html != null)
                    {
                        link = getTextOfLink(html.ToString());
                    }
                }
               
        }

        public string getTextOfLink(string toCheck) {
            match = Regex.Match(toCheck, pattern, RegexOptions.IgnoreCase| RegexOptions.Compiled,TimeSpan.FromSeconds(1));
            if (match.Groups.Count == 0) return null;
            Console.WriteLine("URL:"+match.Groups["url"]);
            return match.Groups["url"].ToString();
        }  
        
    }
}
