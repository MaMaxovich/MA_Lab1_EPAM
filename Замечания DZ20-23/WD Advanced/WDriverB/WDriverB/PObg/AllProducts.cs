using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WDriverB.PObg
{
    class AllProducts
    {
        private IWebDriver driver;

        public AllProducts(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SerchremoveButton => driver.FindElement(By.XPath("//div[@class='container-fluid']/table/tbody/tr[79]//a[@data-remove]"));
        public void DeleteProduct()
        {
            
           Assert.AreEqual("All Products", driver.FindElement(By.XPath("//div[@class='container-fluid']/h2")).Text);
        
           SerchremoveButton.Click();
            
           driver.SwitchTo().Alert().Accept();
        }

    }

}
