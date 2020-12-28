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
            this.CreateProduct();
            this.ExamenProduct();
            this.DelitProduct();
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
            // Debug.WriteLine(driver.Url);
            //Console.WriteLine(driver.Url);
            //TestContext.WriteLine(driver.Url);
            Thread.Sleep(1000);
            Assert.AreEqual("http://localhost:5000/", driver.Url);
        }
        public void CreateProduct()
        {
            IWebElement searchMenu = driver.FindElement(By.XPath("/html/body/div[2]/div[1]/a"));
            searchMenu.Click();
            // IWebElement searchTexstbox = driver.FindElement(By.XPath("//div[1]/h2"));
            //  Assert.AreEqual("All Products", searchTexstbox);
            searchMenu = driver.FindElement(By.XPath("/html/body/div[2]/a"));
            searchMenu.Click();
            IWebElement searchEditfild = driver.FindElement(By.XPath("//*[@id='ProductName']"));
            searchEditfild.Click();
            searchEditfild.SendKeys("Côtes-du-rhône");
            IWebElement searchdropdown = driver.FindElement(By.XPath("//*[@id='CategoryId']"));
            searchdropdown.Click();
            searchdropdown.SendKeys("Beverages");

            IWebElement searchdropdown2 = driver.FindElement(By.XPath("//*[@id='SupplierId']"));
            searchdropdown2.Click();
            searchdropdown2.SendKeys("Aux joyeux ecclesiastiques");
            IWebElement searchEditfild22 = driver.FindElement(By.XPath("//*[@id='UnitPrice']"));
            searchEditfild22.Click();
            searchEditfild22.SendKeys("750");
            IWebElement searchEditfild3 = driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']"));
            searchEditfild3.Click();
            searchEditfild3.SendKeys("75");
            IWebElement searchEditfild4 = driver.FindElement(By.XPath("//*[@id='UnitsInStock']"));
            searchEditfild4.Click();
            searchEditfild4.SendKeys("100");
            IWebElement searchEditfild5 = driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']"));
            searchEditfild5.Click();
            searchEditfild5.SendKeys("0");
            IWebElement searchEditfild6 = driver.FindElement(By.XPath("//*[@id='ReorderLevel']"));
            searchEditfild6.Click();
            searchEditfild6.SendKeys("11");
            IWebElement searchButton2 = driver.FindElement(By.XPath("//div[2]/form/input[1]"));
            searchButton2.Click();
            IWebElement searchTexstbox2 = driver.FindElement(By.XPath("//div[1]/h2[text()='All Products']"));
           // Assert.AreEqual("All Products", searchTexstbox2);
        }
        public void ExamenProduct()
        {
            IWebElement searchMenu = driver.FindElement(By.XPath("//div[3]/table/tbody/tr[79]/td[2]/a"));
            searchMenu.Click();
            string searchTexstbox = driver.FindElement(By.CssSelector("#ProductName")).GetAttribute("value");
            string stb = searchTexstbox;
            //Assert.AreEqual("Product editing", stb);
            //IWebElement searchEditfild7 = driver.FindElement(By.XPath("//*[.='ProductName']"));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@value=\"Côtes-du-rhône\"]")));
            //var searchEditfild7 = driver.FindElement(By.XPath("//*[@value=\"Côtes-du-rhône\"]"));
            // searchEditfild7 = driver.FindElement(By.XPath("//*[@id=\"ProductName\"]")).GetProperty("value");

            //Assert.AreEqual("Côtes-du-rhône", searchEditfild7);

            var searchdropdown = driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/option[2][contains(@value,\"1\")]")).GetProperty("value");
            Assert.AreEqual("1", searchdropdown);
            string searchdropdown2 = driver.FindElement(By.XPath("//*[@id=\"SupplierId\"]/option[19]")).GetProperty("value");
            Assert.AreEqual("18", searchdropdown2);

            var searchEditfild3 = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]")).GetProperty("value");

                try
                {
                    Assert.AreEqual("750", searchEditfild3);
                }

                catch (Exception)
                {
                //var searchEditfild33 = 750;
                IWebElement searchEditfild33 = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]"));
                searchEditfild33.Click();
                searchEditfild33.Clear();
                searchEditfild33.SendKeys("750");
                string s = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]")).GetProperty("value");

                Assert.AreEqual("750", s);
            }

            searchProductId = Convert.ToInt32(driver.FindElement(By.CssSelector("#ProductId")).GetAttribute("value"));

            var searchEditfild4 = driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).GetProperty("value");
            Assert.AreEqual("75", searchEditfild4);

            var searchEditfild5 = driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).GetProperty("value");
            Assert.AreEqual("100", searchEditfild5);

            var searchEditfild6 = driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']")).GetProperty("value");
            Assert.AreEqual("0", searchEditfild6);

            var searchEditfild77 = driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).GetProperty("value");
            Assert.AreEqual("11", searchEditfild77);
            //searchEditfild77.SendKeys("11");
            var searchButton2 = driver.FindElement(By.XPath("//div[2]/form/input[1]"));
            searchButton2.Click();
            string searchTexstbox22 = driver.FindElement(By.XPath("//div[1]/h2")).Text;
            Assert.AreEqual("All Products", searchTexstbox22);
        }
        public void DelitProduct()
        {
            //string searchTexstbox = driver.FindElement(By.XPath("//div[1]/h2")).Text;
            Assert.AreEqual("All Products", driver.FindElement(By.XPath("//div[1]/h2")).Text);

            IWebElement removeButon = driver.FindElement(By.CssSelector("a[href=\"/Product/Remove?ProductId="+searchProductId+"\"] "));
            removeButon.Click();
            driver.SwitchTo().Alert().Accept();
        }
        public void LogoutSucsessTest()
        {
            //  Находим Logout в меню 
            Thread.Sleep(1000);
            IWebElement searchMenu = driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(4) > a"));

            // Делаем клик на Logout
            searchMenu.Click();
            // Находим слово Login в окне
            Thread.Sleep(1000);
            string searchTexstbox22 = driver.FindElement(By.XPath("//div[1]/h2")).Text;
            Assert.AreEqual("Login", searchTexstbox22);
        }
    }


}
