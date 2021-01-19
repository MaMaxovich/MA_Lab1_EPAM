using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WDriverB.PObg
{
    class DelProduct
    {
        private IWebDriver driver;

        public DelProduct(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement serchremoveButton => driver.FindElement(By.XPath("//*[text()='Côtes-du-rhône']/../following-sibling::td[10]/a"));
        public void DeleteProduct()
        {
            
           Assert.AreEqual("All Products", driver.FindElement(By.XPath("//div[1]/h2")).Text);
        
           serchremoveButton.Click();
            
           driver.SwitchTo().Alert().Accept();
        }

    }
        

}
