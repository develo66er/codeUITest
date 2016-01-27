using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;


namespace coded.pages
{
    public class LoginUserForm
    {
       
        BrowserWindow browser;
        string email;
        public LoginUserForm( BrowserWindow abrowser, string uEmail) {
            browser = abrowser;
            email = uEmail;
        }
        public LoginUserForm(BrowserWindow abrowser)
        {
            browser = abrowser;
            email = null;
        }
        public HtmlEdit getUserEdit
        {
            get
            {
                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_txtUsername";
                return edit;
            }

        }
        public HtmlEdit getPasswdEdit
        {
            get
            {
                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_txtPassword";
                return edit;
            }

        }
        public HtmlButton doLoginPage()
        {
            HtmlButton button = new HtmlButton(browser);
            button.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_btnLogin";
            return button;
        }
        public HtmlButton loginButton
        {
            get
            {
                return doLoginPage();
            }

        }
        public void typeAndLoginClick(string passwd)
        {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            if (email != null) {
                var user = this.getUserEdit;
                var pass = this.getPasswdEdit;
                user.Text = email;
                pass.Text = passwd;
                Mouse.Click(loginButton);
            }
            
        }

    }
}
