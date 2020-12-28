using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;


namespace WDriverB
{
    public class Tests
    {
 
        private IWebDriver driver;
        private WebDriverWait wait;
        private int searchProductId;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [Test]
        public void Test1()
        {
            this.LoginSuccess();
            this.CreateProd();
            this.ExamenProduct();
            this.DeleteProduct();
            this.LogoutSucsessTest();
        }
        [TearDown]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }
        public void LoginSuccess()
        {

           driver.FindElement(By.CssSelector("#Name")).SendKeys("user");
           driver.FindElement(By.CssSelector("#Password")).SendKeys("user");
           driver.FindElement(By.CssSelector("form[action='/Account/Login'] input[type='submit']")).Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='container-fluid']/h2")));
            Assert.AreEqual("http://localhost:5000/", driver.Url);
        }
        public void CreateProd()
        {


            IWebElement searchMenu = driver.FindElement(By.XPath("//ul[@class='nav navbar-nav']//a[@href='/Product']"));
            searchMenu.Click();
            
            string searchTexstboxAll_Products = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2[text()='All Products']")).Text;
            Assert.AreEqual("All Products", searchTexstboxAll_Products);

            searchMenu = driver.FindElement(By.XPath("//div[@class='container-fluid']/a[@href='/Product/Create']"));
            searchMenu.Click();
            IWebElement searchEditfildProductName = driver.FindElement(By.XPath("//*[@id='ProductName']"));
            searchEditfildProductName.Click();
            searchEditfildProductName.SendKeys("Côtes-du-rhône");
            IWebElement searchdropdownCategoryId = driver.FindElement(By.XPath("//*[@id='CategoryId']"));
            searchdropdownCategoryId.Click();
            searchdropdownCategoryId.SendKeys("Beverages");

            IWebElement searchdropdownSupplierId = driver.FindElement(By.XPath("//*[@id='SupplierId']"));
            searchdropdownSupplierId.Click();
            searchdropdownSupplierId.SendKeys("Aux joyeux ecclesiastiques");
            IWebElement searchEditfildUnitPrice = driver.FindElement(By.XPath("//*[@id='UnitPrice']"));
            searchEditfildUnitPrice.Click();
            searchEditfildUnitPrice.SendKeys("750");
            IWebElement searchEditfildQuantityPerUnit = driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']"));
            searchEditfildQuantityPerUnit.Click();
            searchEditfildQuantityPerUnit.SendKeys("75");
            IWebElement searchEditfildUnitsInStock = driver.FindElement(By.XPath("//*[@id='UnitsInStock']"));
            searchEditfildUnitsInStock.Click();
            searchEditfildUnitsInStock.SendKeys("100");
            IWebElement searchEditfildUnitsOnOrder = driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']"));
            searchEditfildUnitsOnOrder.Click();
            searchEditfildUnitsOnOrder.SendKeys("0");
            IWebElement searchEditfildReorderLevel = driver.FindElement(By.XPath("//*[@id='ReorderLevel']"));
            searchEditfildReorderLevel.Click();
            searchEditfildReorderLevel.SendKeys("11");
            IWebElement searchButtonsubmit = driver.FindElement(By.XPath("//div[@class='container-fluid']/form/input[@type='submit']"));
            searchButtonsubmit.Click();
            searchTexstboxAll_Products = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2[text()='All Products']")).Text;
             Assert.AreEqual("All Products", searchTexstboxAll_Products);
        }
        public void ExamenProduct()
        {

             IWebElement searchMenu = driver.FindElement(By.XPath("//div[@class='container-fluid']//a[contains(text(), 'Côtes-du-rhône')]"));
               searchMenu.Click();
              string searchTexstboxProduct_Editing = driver.FindElement(By.CssSelector("body > div:nth-child(3) > h2")).Text;

              Assert.AreEqual("Product editing", searchTexstboxProduct_Editing);

            string searchEditfildProductName = driver.FindElement(By.XPath("//*[@id=\"ProductName\"]")).GetProperty("value");

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@value=\"Côtes-du-rhône\"]")));

            Assert.AreEqual("Côtes-du-rhône", searchEditfildProductName);

            var searchdropdownCategoryId = driver.FindElement(By.XPath("//*[@id='CategoryId']/option[contains(@value,'1')]")).GetProperty("value");
            Assert.AreEqual("1", searchdropdownCategoryId);
            string searchdropdownSupplierId = driver.FindElement(By.XPath("//*[@id='SupplierId']/option[@value='18']")).GetProperty("value");
            Assert.AreEqual("18", searchdropdownSupplierId);

            var searchEditfildUnitPrice = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]")).GetProperty("value");

            Assert.AreNotEqual("750", searchEditfildUnitPrice);
               
                IWebElement searchEditfildUnitPriceCorr = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]"));
            searchEditfildUnitPriceCorr.Click();
            searchEditfildUnitPriceCorr.Clear();
            searchEditfildUnitPriceCorr.SendKeys("750");
                string searchEditfildUnitPriceNw = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]")).GetProperty("value");
                Assert.AreEqual("750", searchEditfildUnitPriceNw);

            //Для строки 158
           searchProductId = Convert.ToInt32(driver.FindElement(By.CssSelector("#ProductId")).GetAttribute("value"));


            var searchEditfildQuantityPerUnit = driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).GetProperty("value");
            Assert.AreEqual("75", searchEditfildQuantityPerUnit);

            var searchEditfildUnitsInStock = driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).GetProperty("value");
            Assert.AreEqual("100", searchEditfildUnitsInStock);

            var searchEditfildUnitsOnOrder = driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).GetProperty("value");
            Assert.AreEqual("0", searchEditfildUnitsOnOrder);

            var searchEditfildReorderLevel = driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).GetProperty("value");
            Assert.AreEqual("11", searchEditfildReorderLevel);

            var searchButtonSubmit = driver.FindElement(By.XPath("//input[@type='submit']"));
            searchButtonSubmit.Click();
            string searchTexstboxAll_Products = driver.FindElement(By.XPath("//h2[text()='All Products']")).Text;
            Assert.AreEqual("All Products", searchTexstboxAll_Products);
        }
        public void DeleteProduct()
        {


             Assert.AreEqual("All Products", driver.FindElement(By.XPath("//h2[text()='All Products']")).Text);

              IWebElement removeButon = driver.FindElement(By.CssSelector("a[href=\"/Product/Remove?ProductId="+searchProductId+"\"] "));
              removeButon.Click();
              driver.SwitchTo().Alert().Accept();
        }
        public void LogoutSucsessTest()
        {
            //  Находим Logout в меню 
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/Account/Logout']")));
            IWebElement searchMenu = driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(4) > a"));

            // Делаем клик на Logout
            searchMenu.Click();

            // Находим слово Login в окне
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='container-fluid']/h2")));
            string searchTexstboxLogin = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2")).Text;
            Assert.AreEqual("Login", searchTexstboxLogin);
        }
    }


}
