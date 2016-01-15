using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;

namespace coded.pages
{

    public class userForm
    {
        BrowserWindow browser;
        Boolean userRegistered;
        public userForm(BrowserWindow aBrowser) {
            browser = aBrowser;
        }
 
        public HtmlHyperlink CreateOneHere()
        {
            HtmlHyperlink link = new HtmlHyperlink(browser);
            link.SearchProperties["class"] = "signupLink";
            return link;
        }
        public HtmlHyperlink getCreateOneHere {
            get {
                return CreateOneHere();
            }
            
        }
      
        public addEmail typeAndLoginClick() {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            addEmail goToEmailPage;
            Mouse.Click(getCreateOneHere);
            browser.NavigateToUrl(new Uri("https://s1-site06-stackteamc.rxnova.com/en/Website-Sign-Up/"));
            goToEmailPage = new addEmail(browser);
            return goToEmailPage;
        }
        
    }
}
