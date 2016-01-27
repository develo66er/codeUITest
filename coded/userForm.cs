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
        public userForm(BrowserWindow aBrowser) {
            browser = aBrowser;
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
