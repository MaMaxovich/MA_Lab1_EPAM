using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WDriverB.Bus_object;

namespace WDriverB.PObg
{
    class MainPage
    {
        private Login_t useruser = new Login_t("user", "user");
        private IWebDriver driver;
        public MainPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement loginput => driver.FindElement(By.CssSelector("#Name"));

        private IWebElement passwdinput => driver.FindElement(By.CssSelector("#Password"));

        private IWebElement searchButton => driver.FindElement(By.CssSelector("form[action='/Account/Login'] input[type='submit']"));

        public void LoginSuccess()
        //public void LoginSuccess(string login, string pass)
        {

            loginput.SendKeys(useruser.Loginput_t);
           // loginput.SendKeys(login);
            passwdinput.SendKeys(useruser.Passinput_t);
          //  passwdinput.SendKeys(pass);
            searchButton.Click();
        }
       


    }
}
