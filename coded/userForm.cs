using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coded
{

    public class userForm
    {
        BrowserWindow browser;
        public userForm(BrowserWindow aBrowser) {
            browser = aBrowser;
        }
        public HtmlDiv Div(string property, string value,UITestControl control)
        {
            HtmlDiv div = new HtmlDiv(control);
            div.SearchProperties[property] = value;
            return div;
        }
        
        
        public HtmlEdit getLoginEdit {
            get {
                
                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_txtUsername";
                return edit;
            }
            
        }
        public HtmlEdit getPasswdEdit
        {
            get {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_txtPassword";
                return edit;
            }
            
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
       
        public addEmail typeAndLoginClick(string name, string passwd) {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            addEmail goToEmailPage;
            var login = this.getLoginEdit;
            var pass = this.getPasswdEdit;
            login.Text=name;
            pass.Text = passwd;
            Mouse.Click(getCreateOneHere);
            browser.NavigateToUrl(new Uri("https://s1-site06-stackteamc.rxnova.com/en/Website-Sign-Up/"));
            goToEmailPage = new addEmail(browser);
            return goToEmailPage;
        }
    }
}
