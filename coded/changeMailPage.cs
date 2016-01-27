using coded.pages;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;

//-----------------------------------------------------------------------------
//Страница TempMail с формой для создания нового аккаунта
//-----------------------------------------------------------------------------
namespace coded
{
    public class changeMailPage
    {
        BrowserWindow browser;
        HTTPWrapper wrapper;
        string email;
        
        public changeMailPage(BrowserWindow abrowser) {
            browser = abrowser;
            wrapper = new HTTPWrapper();
        }
        // получение поля ввода для логина
        public HtmlEdit getLoginEdit
        {
            get
            {
                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["name"] = "mail";
                return edit;
            }

        }
        // получение комбо для выбора нужного домена
        public HtmlComboBox getDomainCombo
        {
            get
            {
                HtmlComboBox combobox = new HtmlComboBox(browser);
                combobox.SearchProperties["name"] = "domain";
                return combobox;

            }

        }
        // получение кнопки сохранения
        public HtmlButton doSavePage()
        {
            HtmlButton button = new HtmlButton(browser);
            button.SearchProperties["id"] = "postbut";
            return button;
        }
        public HtmlButton saveButton
        {
            get
            {
                return doSavePage();
            }

        }
        // переход на страницу сохранения пользовательских данных сайта s1-site06-stackteamc.rxnova.com
        public addEmail goToAddEmail() {
            HTTPWrapper.GetNewMail();
            var login = this.getLoginEdit;
            var domain = this.getDomainCombo;
            // email и domain генерируются случайным образом
            email = HTTPWrapper.getlogin();
            domain.SelectedItem = HTTPWrapper.getDomain();
            login.Text = email; 
            Mouse.Click(saveButton);
            browser.NavigateToUrl(new Uri("https://s1-site06-stackteamc.rxnova.com/en/Website-Sign-Up/"));
            return new addEmail(browser,HTTPWrapper.getMD5(),HTTPWrapper.getMail());
        }
    }
}
