using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WDriverB.Bus_object;

namespace WDriverB.PObg
{
    class LoginPage
    {
        private Login_t useruser = new Login_t("user", "user");
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement loginput => driver.FindElement(By.CssSelector("#Name"));

        private IWebElement passwdinput => driver.FindElement(By.CssSelector("#Password"));

        private IWebElement searchButton => driver.FindElement(By.CssSelector("form[action='/Account/Login'] input[type='submit']"));

       // public void LoginSuccess();

      //   {

        //     loginput.SendKeys(useruser.Loginput_t);

        //      passwdinput.SendKeys(useruser.Passinput_t);

        //     searchButton.Click();
        //  }
        public void TypeLogin(string loginputSF)
        {
            loginput.SendKeys(loginputSF);
        }
        public void TypePass(string passinputSF)
        {
            passwdinput.SendKeys(passinputSF);
        }
        public void ClicSubmitBut()
        {
            searchButton.Click();
        }
        private IWebElement searchMenu => driver.FindElement(By.XPath("//div[2]/div[1]/a"));
        public void SearchMenu()
        {
            searchMenu.Click();
        }

    }
}
