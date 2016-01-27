using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

using System.Xml.Linq;

namespace coded
{

    public class HTTPWrapper
    {
        static string link;
        static string lastId;
        static string login;
        static string domain;
        static string md5Mail;
        static RCGenerator gen;
        const string pattern = "(.\\s\\S)*(\\s\\s)?(?<url>https?:\\/\\/[-\\w;/?:@&+$=_\\|.!~*\\|'()\\[\\]%#,]+[\\w/#])(\\s\\s)?(.\\s\\S)*";

        public static string[] Domains { get; private set; }
        public static string Mail
        {
            get; private set;
        }
        public static byte[] MailHash { get; private set; }
        public string MailHashString { get; private set; }
        static MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();


        public struct Letter
        {

            public string MailId;

            public string MailAddressId;

            public string MailFrom;

            public string MailText;

            public string MailHtml;

        }
        public HTTPWrapper()
        {
            link = null;
            lastId = null;
            login = null;
            gen = new RCGenerator();
            Mail = null;
            domain = null;
            md5Mail = null;
        }
        public static XDocument Get(string url, bool needtoSleep)
        {
            XDocument doc=null;
            HttpWebResponse resp;
            try
            {
                var req = (HttpWebRequest)HttpWebRequest.Create(url);
                req.AutomaticDecompression = DecompressionMethods.GZip;
                req.UserAgent = "CSWrap";
                using (resp = (HttpWebResponse)req.GetResponse())
                using (var s = resp.GetResponseStream())
                    doc = XDocument.Load(s);
                    resp.Close();
                    return doc;
            }
            catch (WebException e)
            {
                if ((e.Status & WebExceptionStatus.ProtocolError) == WebExceptionStatus.ProtocolError)
                    return null;
                throw;
            }
            catch { throw; }
            
        }
        public static void extractLink(string hash)
        {
            
            XDocument t;
            string url = string.Format("http://api.temp-mail.ru/request/mail/id/{0}/format/xml/", hash);
            t = Get(url, true);
            if (t == null){
                return;
            }
            var arr = t.Root.Elements().Reverse().ToArray();
            foreach (var x in arr)
            {
                string mailId = x.Element("mail_id").Value;
                if (lastId == mailId)
                {
                    link = null;
                    break;
                }

                if (!x.Element("mail_from").Value.Contains("noreply@showsite.rxnova.com")) continue;
                Console.WriteLine("mail_from :" + x.Element("mail_from").Value);
                MatchCollection matches = Regex.Matches(x.Element("mail_text_only").Value, pattern, RegexOptions.IgnoreCase);
                Console.WriteLine("matches.Count :" + matches.Count);
                if (matches.Count == 0)
                {
                    link = null;
                    continue;
                }
                List<string> listOfMatch = new List<string>();
                foreach (Match match in matches)
                {
                    listOfMatch.Add(match.Groups["url"].Value);
                }
                link = listOfMatch[0];
            };
            lastId = arr[0].Element("mail_id").Value;
        }
        public static string getLink()
        {
            return link;
        }

        public static string[] GetDomains()
        {
            var xml = Get("http://api.temp-mail.ru/request/domains/format/xml/",false);
            return xml.Root.Elements().Select(x => x.Value).ToArray();
        }

        public static string getlogin() {
            return login;
        }
        public static string getMail() {
            return Mail;
        }
        public static string getDomain() {
            return domain;
        }
        public static string getMD5() {
            return md5Mail;
        }
        public static void GetNewMail()
        {
            GetNewMail(gen.NextString());

        }
        public static void GetNewMail(string mailName)
        {
            Domains = GetDomains();
            domain = Domains[gen.Next(0, Domains.Length - 1)];
            login = mailName;
            Mail = mailName + domain;
            MailHash = md5.ComputeHash(Encoding.ASCII.GetBytes(Mail));
            StringBuilder sb = new StringBuilder(MailHash.Length * 2);
            for (int i = 0; i < MailHash.Length; i++)
            {
                sb.Append(MailHash[i].ToString("X2"));
            }
            md5Mail = sb.ToString().ToLower();
        }

    }
}
