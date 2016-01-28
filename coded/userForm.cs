using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;

namespace coded.pages
{
    //-----------------------------------------------------------------------------
    //Страница с формой пользователя и ссылкой для создания нового пользователя
    //-----------------------------------------------------------------------------
    public class userForm
    {
        BrowserWindow browser;
        string email;
        public userForm(BrowserWindow aBrowser) {
            browser = aBrowser;
            email = null;
        }
        public userForm(BrowserWindow abrowser, string uEmail)
        {
            browser = abrowser;
            email = uEmail;
        }
        // получение ссылки создания нового пользователя
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
        //метод для заполнения пользовательской формы с логином и паролем
        public void formComplete(string passwd)
        {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            if (email != null)
            {
                var user = this.getUserEdit;
                var pass = this.getPasswdEdit;
                user.Text = email;
                pass.Text = passwd;
                Mouse.Click(loginButton);
            }
        }

  // метод перехода на страницу для создания нового почтового аккаунта   
        public TempMailPage typeAndLoginClick() {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            TempMailPage goToTempMailPage;
            Mouse.Click(getCreateOneHere);
            browser.NavigateToUrl(new Uri("http://temp-mail.org/"));
            goToTempMailPage = new TempMailPage(browser);
            return goToTempMailPage;
        }
        
    }
}
