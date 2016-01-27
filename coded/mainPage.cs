using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;

//-----------------------------------------------------------------------------
//главная страница с ссылкой для регистрации на которую необходимо нажать
//-----------------------------------------------------------------------------
namespace coded.pages
{
    public class mainPage :UITestControl
    {
        protected string pageURI = "http://s1-site06-stackteamc.rxnova.com/";
        BrowserWindow browser;
        // загрузка URL в браузер
        public mainPage launchPage()
        {
            browser = BrowserWindow.Launch(new Uri(this.pageURI));
            return this;
        }
        //ищем ссылочку
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
        //метод перехода на страницу для добавления нового пользователя
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
