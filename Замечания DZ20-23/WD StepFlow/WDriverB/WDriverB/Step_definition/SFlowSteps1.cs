using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using WDriverB.Bus_object;
using WDriverB.PObg;

namespace WDriverB.Step_definition
{
    [Binding]
    class SFlowSteps1
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        private LoginPage loginPage;
        private CreateProduct createProduct;
        private AllProducts allProducts;
        private IWebElement searchButtonCreate;


        [Given(@"Я перехожу на ""(.+)"" страницу")]
        public void INavigateToUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }
        [When(@"Я ввожу в поле логина ""(.+)""")]
        public void Ienterintheloginfield(string loginputSF)
        {
            new LoginPage(driver).TypeLogin(loginputSF);
        }

        [When(@"Я ввожу в поле пароля ""(.*)""")]
        public void Ienterinthepassfield(string passinputSF)
        {
            new LoginPage(driver).TypePass(passinputSF);
        }

        [When(@"Я кликаю на экранную кнопку Отправить")]
        public void IclickontheSubmitbutton()
        {
            new LoginPage(driver).ClicSubmitBut();
        }


        [When(@"Я кликаю на экранное меню ""(.+)""")]
        public void IclickontheOSD(string allprod)
        {
            new LoginPage(driver).SearchMenu();

        }


        [Then(@"Я запускаю создание нового продукта в БД Northwind")]
        public void CreateProd()
        {
            createProduct = new CreateProduct(driver);

            IWebElement searchMenu = driver.FindElement(By.XPath("//ul[@class='nav navbar-nav']//a[@href='/Product']"));
            searchMenu.Click();
            allProducts = new AllProducts(driver);
            string searchTexstboxAll_Products = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2[text()='All Products']")).Text;
            Assert.AreEqual("All Products", searchTexstboxAll_Products);
            searchButtonCreate = driver.FindElement(By.XPath("//div[@class='container-fluid']/a[@href='/Product/Create']"));
            searchButtonCreate.Click();

            createProduct.CreateProd();


            searchTexstboxAll_Products = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2[text()='All Products']")).Text;
            Assert.AreEqual("All Products", searchTexstboxAll_Products);


        }

    }
 }
