using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;

//-----------------------------------------------------------------------------
//Страница с формой заполнения для создания нового пользователя 
//-----------------------------------------------------------------------------
namespace coded.pages
{
    public class addEmail
    {
        BrowserWindow browser;
        string hashedEmail;
        string email;
        public addEmail(BrowserWindow aBrowser, string aHashedEmail, string aEmail)
        {
            browser = aBrowser;
            hashedEmail = aHashedEmail;
            email = aEmail;
        }
        public HtmlDiv RootDiv
        {
            get
            {
                HtmlDiv div = new HtmlDiv(browser);
                div.SearchProperties["id"] = "content";
                return div;
            }

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
            HtmlButton button = new HtmlButton(RootDiv);
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
        public HtmlEdit getFirstNameEdit
        {
            get
            {
                HtmlEdit edit = new HtmlEdit(RootDiv);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtFirstname";
                return edit;
            }

        }
        public HtmlEdit getSurnameEdit
        {
            get
            {
                HtmlEdit edit = new HtmlEdit(RootDiv);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtSurname";
                return edit;
            }

        }
        public HtmlEdit getCompanyEdit
        {
            get
            {
                HtmlEdit edit = new HtmlEdit(RootDiv);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtCompany";
                return edit;
            }

        }
        public HtmlEdit getCityTownEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(RootDiv);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtCity";
                return edit;
            }

        }
        public HtmlEdit getStateProvinceEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(RootDiv);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtCounty";
                return edit;
            }

        }
        public HtmlComboBox getCountryCombo
        {
            get
            {
                HtmlComboBox combobox = new HtmlComboBox(RootDiv);
                combobox.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_ddlCountries";
                return combobox;

            }

        }
        public HtmlEdit getPasswdEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(RootDiv);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtPassword";
                return edit;
            }

        }
        public HtmlEdit getConfirmPasswdEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(RootDiv);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtConfirmPassword";
                return edit;
            }

        }
        public HtmlComboBox getLanguageCombo
        {
            get
            {
                HtmlComboBox combobox = new HtmlComboBox(RootDiv);
                combobox.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_ddlLanguages";
                return combobox;

            }

        }
        public HtmlCheckBox getGetNewsCheck
        {
            get
            {
                HtmlCheckBox check = new HtmlCheckBox(RootDiv);
                check.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_chkOptOutShareDetailsWithAssociatedEvents";
                return check;

            }

        }
        public HtmlCheckBox getSharePersonalCheck
        {
            get
            {
                HtmlCheckBox check = new HtmlCheckBox(RootDiv);
                check.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_UserPreferences_UserPreferenceRepeater_ctl00_UserPreference";
                return check;

            }

        }
        public HtmlCheckBox getAgreeCheck
        {
            get
            {
                HtmlCheckBox check = new HtmlCheckBox(RootDiv);
                check.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_chkTAndC";
                return check;

            }

        }
        public HtmlButton toSignUp()
        {
            HtmlButton button = new HtmlButton(RootDiv);
            button.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_submitButton";
            return button;
        }
        public HtmlButton SignUpButton
        {
            get
            {
                return toSignUp();
            }

        }


        public userForm typeAndSignUpClick(string name,
                                        string surname, string company,
                                            string city, string province,
                                                string country, string passwd,
                                                    string language, Boolean getNews,
                                                        Boolean sharePersonal, Boolean agree)
        {
            
            string fetchResult = null;
            BrowserWindow.ClearCookies();
            BrowserWindow.ClearCache();
            var mail = this.getEmailEdit;
            var uname = this.getFirstNameEdit;
            mail.Text = email;
            Mouse.Click(nextPageButton);
            if (uname.Exists){
                var usurname = this.getSurnameEdit;
                var ucompany = this.getCompanyEdit;
                var ucity = this.getCityTownEdit;
                var uprovince = this.getStateProvinceEdit;
                var ucountry = this.getCountryCombo;
                var upasswd = this.getPasswdEdit;
                var uconfirmPasswd = this.getConfirmPasswdEdit;
                var ulang = this.getLanguageCombo;
                var ugetNews = this.getGetNewsCheck;
                var usharePersonal = this.getSharePersonalCheck;
                var uagree = this.getAgreeCheck;
                uname.Text = name;
                usurname.Text = surname;
                ucompany.Text = name;
                ucity.Text = city;
                uprovince.Text = province;
                ucountry.SelectedItem = country;
                upasswd.Text = passwd;
                uconfirmPasswd.Text = passwd;
                ulang.SelectedItem = language;
                ugetNews.Checked = getNews;
                usharePersonal.Checked = sharePersonal;
                uagree.Checked = agree;
                Mouse.Click(SignUpButton);
             }
            int i = 0;
            System.Threading.Thread.Sleep(150000);
            do {
                i++;
                HTTPWrapper.extractLink(hashedEmail);
                fetchResult = HTTPWrapper.getLink();
            } while ((fetchResult==null)&&(i<400));
            if(fetchResult == null) {
                browser.NavigateToUrl(new Uri("https://s1-site06-stackteamc.rxnova.com/en/Website-Sign-Up/Login-Form/"));
                return new userForm(browser);
            }
            else {
                browser.NavigateToUrl(new Uri(fetchResult));
                Console.WriteLine("link received :" + fetchResult);
                return new userForm(browser,email);
            }
         
        }
     }

  }

