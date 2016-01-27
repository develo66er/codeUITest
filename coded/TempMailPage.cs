using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
//-----------------------------------------------------------------------------
//страница сервиса TempMail , где нужно нажать на ссылку для смены почтового адреса и создания нового аккаунта
//-----------------------------------------------------------------------------
namespace coded.pages
{
    public class TempMailPage
    {
        BrowserWindow browser;
        public TempMailPage(BrowserWindow abrowser) {
            browser = abrowser;
        }
        //получаем ссылочку для смены аккаунта
        public HtmlHyperlink changeMail()
        {
            HtmlHyperlink link = new HtmlHyperlink(browser);
            link.SearchProperties["id"] = "click-to-change";
            return link;
        }

        public HtmlHyperlink pressChangeMail
        {
            get
            {
                return changeMail();
            }
        }
        //переход на страницу создания почтового аккаунта
        public changeMailPage changeEmailClick()
        {
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            changeMailPage goToChangeMailPage;
            Mouse.Click(pressChangeMail);
            browser.NavigateToUrl(new Uri("http://temp-mail.org/en/option/change"));
            goToChangeMailPage = new changeMailPage(browser);
            return goToChangeMailPage;
        }
    }
}
