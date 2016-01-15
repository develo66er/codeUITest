
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
        const string mail = "noreply@showsite.rxnova.com";
        const string pattern = "(.\\s\\S)*(\\s\\s)?(?<url>https?:\\/\\/[-\\w;/?:@&+$=_\\|.!~*\\|'()\\[\\]%#,]+[\\w/#])(\\s\\s)?(.\\s\\S)*";
        const string patternOfDate = @"\w-\w[:](1)(?<month>.*?)/(?<day>.*?)/(?<year>.*?) \w*";
        string[] months = { "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct" ,"Nov", "Dec"};
        
        string html;
        string currentDate;
        string host;
        int port;
        Boolean useSSL;
        string user;
        string pass;
        public POP3client(string ahost, int aport, Boolean auseSSL, string auser, string apass) {
            //client = new Pop3Client();
            host = ahost;
            port = aport;
            useSSL = auseSSL;
            user = auser;
            pass = apass;
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
        public Boolean fetchAllMessages() {
            using (Pop3Client client = new Pop3Client()) {
                List<Message> messages = new List<Message>();
                client.Connect(host, port, useSSL);
                client.Authenticate(user, pass);
           
                int messagesCount = client.GetMessageCount();
                Console.WriteLine(messagesCount);
                for (int i =1; i <=messagesCount; i++){
                    getheaders(i);
                    if (link != null) return true;
                }
                return false;
            }
                

        }
        public void getheaders(int messageNumber) {
            using (Pop3Client client = new Pop3Client()){
                Console.WriteLine("message number : "+messageNumber);
                client.Connect(host, port, useSSL);
                client.Authenticate(user, pass);
                MessageHeader header = client.GetMessageHeaders(messageNumber);
                
                RfcMailAddress from = header.From;
                Console.WriteLine("from : "+from);
                
                string dateOfMessage = header.Date;
                if (dateOfMessage == null) dateOfMessage = currentDate;
                Console.WriteLine("date :"+dateOfMessage);
                if (!dateOfMessage.Contains(currentDate)) return;
                if (from.HasValidMailAddress && from.Address.Equals(mail))
                {
                    Message message = client.GetMessage(messageNumber);
                    
                    MessagePart part0 = message.FindFirstPlainTextVersion();
                    
                    if (part0 != null) {
                        
                        html = part0.GetBodyAsText();
                        
                        if (html != null)
                        {
                            link = getTextOfLink(html);
                        }
                    }
                        
                  
                }
            }

        }
      
        public string getTextOfLink(string toCheck) {
            List<string> listOfMatch = new List<string>();
            MatchCollection matches = Regex.Matches(toCheck, pattern,RegexOptions.IgnoreCase|RegexOptions.Multiline);
            if (matches.Count == 0) return null;
            foreach (Match match in matches) {
                listOfMatch.Add(match.Groups["url"].Value);
            }
            return listOfMatch[0];
        }  
        
    }
}
