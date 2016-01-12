using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coded.pages
{
    public class mainPage :UITestControl
    {
        protected string pageURI = "http://s1-site06-stackteamc.rxnova.com/";
        BrowserWindow browser;
        
        public mainPage launchPage()
        {
            //this.mainElement = (browser.CurrentDocumentWindow.GetChildren()[0] as UITestControl) as HtmlControl;
            browser = BrowserWindow.Launch(new Uri(this.pageURI));
            return this;
        }
        public HtmlHyperlink findHyperLink() {
            HtmlHyperlink link = new HtmlHyperlink(browser);
            link.SearchProperties["class"] = "toolbar-link";
            return link; 
        }
      
        public HtmlHyperlink getLink{
            get{
                return findHyperLink();
            }
        }
        public userForm goToRegistration()
        {
            userForm form;
            Mouse.Click(getLink);
            browser.NavigateToUrl(new Uri("https://s1-site06-stackteamc.rxnova.com/en/Website-Sign-Up/Login-Form/"));
            form = new userForm(browser);
            return form;
        }
    }
}
