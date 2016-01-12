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
        public HtmlDiv Div1() {
            HtmlDiv div = new HtmlDiv(browser);
            div.SearchProperties["class"] = "top-bar-wrapper";
            return div;
        }
        public HtmlDiv Div2()
        {
            HtmlDiv div = new HtmlDiv(Div1());
            div.SearchProperties["class"] = "top-bar clearfix centered-page";
            return div;
        }
        public HtmlHyperlink findHyperLink() {
            HtmlHyperlink link = new HtmlHyperlink(Div2());
            link.SearchProperties["class"] = "toolbar-link";
            
           // UITestControlCollection collection = control.FindMatchingControls();
            
            return link; 
        }
      
        public HtmlHyperlink getLink{
            get{
                return findHyperLink();
            }
        }
        public void goToRegistration()
        {
            Mouse.Click(getLink);
        }
    }
}
