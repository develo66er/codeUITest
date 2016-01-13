﻿using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;


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
        public HtmlEdit getFirstNameEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtFirstname";
                return edit;
            }

        }
        public HtmlEdit getSurnameEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtSurname";
                return edit;
            }

        }
        public HtmlEdit getCompanyEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtCompany";
                return edit;
            }

        }
        public HtmlEdit getCityTownEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtCity";
                return edit;
            }

        }
        public HtmlEdit getStateProvinceEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtCounty";
                return edit;
            }

        }
        public HtmlComboBox getCountryCombo
        {
            get
            {
                HtmlComboBox combobox = new HtmlComboBox(browser);
                combobox.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_ddlCountries";
                return combobox;

            }

        }
        public HtmlEdit getPasswdEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtPassword";
                return edit;
            }

        }
        public HtmlEdit getConfirmPasswdEdit
        {
            get
            {

                HtmlEdit edit = new HtmlEdit(browser);
                edit.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_txtConfirmPassword";
                return edit;
            }

        }
        public HtmlComboBox getLanguageCombo
        {
            get
            {
                HtmlComboBox combobox = new HtmlComboBox(browser);
                combobox.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_ddlLanguages";
                return combobox;

            }

        }
        public HtmlCheckBox getGetNewsCheck
        {
            get
            {
                HtmlCheckBox check = new HtmlCheckBox(browser);
                check.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_chkOptOutShareDetailsWithAssociatedEvents";
                return check;

            }

        }
        public HtmlCheckBox getSharePersonalCheck
        {
            get
            {
                HtmlCheckBox check = new HtmlCheckBox(browser);
                check.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_UserPreferences_UserPreferenceRepeater_ctl00_UserPreference";
                return check;

            }

        }
        public HtmlCheckBox getAgreeCheck
        {
            get
            {
                HtmlCheckBox check = new HtmlCheckBox(browser);
                check.SearchProperties["id"] = "ctl00_centreContentPlaceHolder_ctlCreateProfile_chkTAndC";
                return check;

            }

        }
        public HtmlButton toSignUp()
        {
            HtmlButton button = new HtmlButton(browser);
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

        public void typeAndSignUpClick(string emailValue,string name,
                                        string surname, string company,
                                            string city, string province, 
                                                string country, string passwd,
                                                    string language, Boolean getNews, 
                                                        Boolean sharePersonal, Boolean agree)
        {
            BrowserWindow.ClearCookies();
            var mail = this.getEmailEdit;
            var uname = this.getFirstNameEdit;
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
            mail.Text = emailValue;
            
            Mouse.Click(nextPageButton);
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

    }

}