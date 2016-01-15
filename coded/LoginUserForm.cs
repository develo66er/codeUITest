using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;


namespace coded.pages
{
    public class LoginUserForm
    {
       
        BrowserWindow browser;
        
        public LoginUserForm( BrowserWindow abrowser) {
            browser = abrowser;
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
        public void typeAndLoginClick(string username, string passwd)
        {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            var user = this.getUserEdit;
            var pass = this.getPasswdEdit;
            user.Text = username;
            pass.Text = passwd;
            Mouse.Click(loginButton);
        }

    }
}
