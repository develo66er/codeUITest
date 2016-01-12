using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coded
{
    public class addEmail
    {
        BrowserWindow browser;
        public addEmail(BrowserWindow aBrowser)
        {
            browser = aBrowser;
        }
        public HtmlEdit getEmailEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlSignUp_txtEmail";
                return edit;
            }

        }
        public HtmlButton goNextPage()
        {
            HtmlButton button = new HtmlButton(browser);
            button.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlSignUp_submitButton";
            return button;
        }
        public HtmlButton nextPageButton
        {
            get
            {
                return goNextPage();
            }

        }
        public void typeAndNextClick(string emailValue)
        {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            var mail = this.getEmailEdit;

            mail.Text = emailValue;
          
            Mouse.Click(nextPageButton);

        }

    }

}