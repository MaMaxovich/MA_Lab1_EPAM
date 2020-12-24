using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WDriverB.PObg
{
    class CreateProduct
    {
        private IWebDriver driver;

        public string ProdN = "Côtes-du-rhône";

        public CreateProduct(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement SearchMenu => driver.FindElement(By.XPath("//div[2]/div[1]/a"));
        private IWebElement SearchTexstbox2 => driver.FindElement(By.XPath("//div[1]/h2[text()='All Products']"));
        private IWebElement SearchMenu2 => driver.FindElement(By.XPath("//div[2]/a"));
        private IWebElement SearchEditfild => driver.FindElement(By.XPath("//*[@id='ProductName']"));
        private IWebElement Searchdropdown => driver.FindElement(By.XPath("//*[@id='CategoryId']"));
        private IWebElement Searchdropdown2 => driver.FindElement(By.XPath("//*[@id='SupplierId']"));
        private IWebElement SearchEditfild22 => driver.FindElement(By.XPath("//*[@id='UnitPrice']"));
        private IWebElement SearchEditfild3 => driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']"));
        private IWebElement SearchEditfild4 => driver.FindElement(By.XPath("//*[@id='UnitsInStock']"));
        private IWebElement SearchEditfild5 => driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']"));
        private IWebElement SearchEditfild6 => driver.FindElement(By.XPath("//*[@id='ReorderLevel']"));
        private IWebElement SearchButton2 => driver.FindElement(By.XPath("//div[2]/form/input[1]"));
        private IWebElement SearchTexstbox => driver.FindElement(By.XPath("//div[1]/h2[text()='All Products']"));
    
        public void CreateProd()
        {
            SearchMenu.Click();

            Assert.AreEqual("All Products", SearchTexstbox2.Text);

            SearchMenu2.Click();
            SearchEditfild.Click();
            SearchEditfild.SendKeys(ProdN);
            Searchdropdown.Click();
            Searchdropdown.SendKeys("Beverages");
            Searchdropdown2.Click();
            Searchdropdown2.SendKeys("Aux joyeux ecclesiastiques");
            SearchEditfild22.Click();
            SearchEditfild22.SendKeys("750");
            SearchEditfild3.Click();
            SearchEditfild3.SendKeys("75");
            SearchEditfild4.Click();
            SearchEditfild4.SendKeys("100");
            SearchEditfild5.Click();
            SearchEditfild5.SendKeys("0");
            SearchEditfild6.Click();
            SearchEditfild6.SendKeys("11");
            SearchButton2.Click();
           
            Assert.AreEqual("All Products", SearchTexstbox.Text);

        }

        
    }
}
