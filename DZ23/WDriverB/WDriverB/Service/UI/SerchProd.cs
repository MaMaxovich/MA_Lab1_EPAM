using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WDriverB.Bus_object;

namespace WDriverB.Service.UI
{
    class SerchProd
    {
        public void OpenProduct(Product prod, IWebDriver driver)
        {
        IWebElement searchMenu = driver.FindElement(By.XPath("//div[3]/table/tbody/tr[79]/td[2]/a"));
        searchMenu.Click();
        string searchTexstbox = driver.FindElement(By.CssSelector("body > div:nth-child(3) > h2")).Text;
        Assert.AreEqual("Product editing", searchTexstbox);
        }


    }
}
