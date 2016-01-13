using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coded
{
    public class RegistrationForm
    {
        BrowserWindow browser;
        public RegistrationForm(BrowserWindow aBrowser)
        {
            browser = aBrowser;
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
        public void typeAndSygnUpClick(string name, string surname, string company, string city, string province, string country) {
           
            var uname = this.getFirstNameEdit;
            var usurname = this.getSurnameEdit;
            var ucompany = this.getCompanyEdit;
            var ucity = this.getCityTownEdit;
            var uprovince = this.getStateProvinceEdit;
            var ucountry = this.getCountryCombo;
            uname.Text = name;
            usurname.Text = surname;
            ucompany.Text = name;
            ucity.Text = city;
            uprovince.Text = province;
            ucountry.SelectedItem = country;
            
        }
    }
}
