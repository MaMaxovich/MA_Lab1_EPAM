using NUnit.Framework;
using NUnit.Framework.Internal;
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

        [TestFixture]
        public class SuccessTests
        {
            private ChromeDriver driver;
            private WebDriverWait wait;
            private int searchProductId;
            private string prdName = "Côtes-du-rhône";
            private string categID = "Beverages";
            private string categorId = "1";
            private string SupplierId = "Aux joyeux ecclesiastiques";
            private string SuppId = "18";
            private string unitPrice = "750";
            private string quantityPerUnit = "75";
            private string unitsInStock = "100";
            private string unitsOnOrder = "0";
            private string reorderLevel = "11";

            [OneTimeSetUp]
            public void Setup()
            {
                driver = new ChromeDriver();
                driver.Navigate().GoToUrl("http://localhost:5000/Account/Login");
                driver.Manage().Window.Maximize();
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            }

            [OneTimeTearDown]
            public void CloseDriver()
            {
                driver.Close();
                driver.Quit();
            }

            [Test, Order(1)]
            public void LoginSuccess()
            {

                driver.FindElement(By.CssSelector("#Name")).SendKeys("user");
                driver.FindElement(By.CssSelector("#Password")).SendKeys("user");
                driver.FindElement(By.CssSelector("form[action='/Account/Login'] input[type='submit']")).Click();

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='container-fluid']/h2")));
                Assert.AreEqual("http://localhost:5000/", driver.Url);
            }

            [Test, Order(2)]
            public void CreateProd()
            {

                driver.FindElement(By.XPath("//ul[@class='nav navbar-nav']//a[@href='/Product']")).Click();

                string searchTexstboxAll_Products = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2[text()='All Products']")).Text;
                Assert.AreEqual("All Products", searchTexstboxAll_Products);

                driver.FindElement(By.XPath("//div[@class='container-fluid']/a[@href='/Product/Create']")).Click();
                driver.FindElement(By.XPath("//*[@id='ProductName']")).SendKeys(prdName);
                driver.FindElement(By.XPath("//*[@id='CategoryId']")).SendKeys(categID);
                driver.FindElement(By.XPath("//*[@id='SupplierId']")).SendKeys(SupplierId);
                driver.FindElement(By.XPath("//*[@id='UnitPrice']")).SendKeys(unitPrice);
                driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).SendKeys(quantityPerUnit);
                driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).SendKeys(unitsInStock);
                driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).SendKeys(unitsOnOrder);
                driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).SendKeys(reorderLevel);
                driver.FindElement(By.XPath("//div[@class='container-fluid']/form/input[@type='submit']")).Click();
 
                Assert.AreEqual("All Products", searchTexstboxAll_Products);
            }

            [Test, Order(3)]
            public void ExamenProduct()
            {

                driver.FindElement(By.XPath("//div[@class='container-fluid']//a[contains(text(), '" + prdName + "')]")).Click();

                Assert.AreEqual("Product editing", driver.FindElement(By.CssSelector("body > div:nth-child(3) > h2")).Text);

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@value='" + prdName + "']")));

                Assert.AreEqual(prdName, driver.FindElement(By.XPath("//*[@id=\"ProductName\"]")).GetProperty("value"));
                Assert.AreEqual(categorId, driver.FindElement(By.XPath("//*[@id='CategoryId']/option[contains(@value, '" + categorId + "')]")).GetProperty("value"));
                Assert.AreEqual(SuppId , driver.FindElement(By.XPath("//*[@id='SupplierId']/option[@value='" + SuppId + "']")).GetProperty("value"));

                Assert.AreNotEqual(unitPrice, driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]")).GetProperty("value"));

                IWebElement searchEditfildUnitPriceCorr = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]"));

                searchEditfildUnitPriceCorr.Clear();
                searchEditfildUnitPriceCorr.SendKeys(unitPrice);
                string searchEditfildUnitPriceNw = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]")).GetProperty("value");
                Assert.AreEqual(unitPrice, searchEditfildUnitPriceNw);

                //Для строки 128
               searchProductId = Convert.ToInt32(driver.FindElement(By.CssSelector("#ProductId")).GetAttribute("value"));

                Assert.AreEqual(quantityPerUnit, driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).GetProperty("value"));

                Assert.AreEqual(unitsInStock, driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).GetProperty("value"));

                Assert.AreEqual(unitsOnOrder, driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).GetProperty("value"));

                Assert.AreEqual(reorderLevel, driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).GetProperty("value"));

                driver.FindElement(By.XPath("//input[@type='submit']")).Click();
                Assert.AreEqual("All Products", driver.FindElement(By.XPath("//h2[text()='All Products']")).Text);
            }

            [Test, Order(4)]
            public void DeleteProduct()
            {
                Assert.AreEqual("All Products", driver.FindElement(By.XPath("//h2[text()='All Products']")).Text);

                driver.FindElement(By.CssSelector("a[href=\"/Product/Remove?ProductId=" + searchProductId + "\"] ")).Click();
                driver.SwitchTo().Alert().Accept();
            }

            [Test, Order(5)]
            public void LogoutSucsessTest()
            {
                //  Ждём появления элемента
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/Account/Logout']")));
 
                //  Находим Logout в меню  Делаем клик на Logout
                driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(4) > a")).Click();

                // Ждём появления элемента Находим слово Login в окне
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='container-fluid']/h2")));
                Assert.AreEqual("Login", driver.FindElement(By.XPath("//div[@class='container-fluid']/h2")).Text);
            }
        }

    }
}
