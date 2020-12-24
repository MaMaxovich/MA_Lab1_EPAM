using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using WDriverB.PObg;

namespace WDriverB.Step_definition
{
    [Binding]
    class SFlowSteps
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [Given(@"Я перехожу на ""(.+)"" страницу")]
        public void INavigateToUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }
        [When(@"Я ввожу в поле логина ""(.+)""")]
        public void WhenЯВвожуВПолеЛогина(string loginputSF)
        {
            new MainPage(driver).TypeLogin(loginputSF);
        }

        [When(@"Я ввожу в поле пароля ""(.*)""")]
        public void WhenЯВвожуВПолеПароля(string passinputSF)
        {
            new MainPage(driver).TypePass(passinputSF);
        }

        [When(@"Я кликаю на экранную кнопку Отправить")]
        public void WhenЯКликаюНаЭкраннуюКнопку()
        {
            new MainPage(driver).ClicSubmitBut();
        }


        [When(@"Я кликаю на экранное меню ""(.+)""")]
        public void WhenЯКликаюНаЭкранноеМеню(string allprod)
        {
            new MainPage(driver).SearchMenu();
            
        }

        [When(@"Я кликаю на экранную кнопку 'Create new' на странице 'All Products'")]
        public void WhenЯКликаюНаЭкраннуюКнопкуНаСтранице()
        {
            new CreateProduct(driver).SearchMenu22();
        }

        [When(@"Я ввожу в поле ProductName ""(.+)""")]
        public void WhenЯВвожуВПолеProductName(string pName)
        {
            new CreateProduct(driver).TypeProdN(pName);
        }

        [When(@"Я ввожу в поле CategoryName ""(.+)""")]
        public void WhenЯВвожуВПолеCategoryName(string beverages)
        {
            new CreateProduct(driver).TypeBeverages(beverages);
        }

        [When(@"Я ввожу в поле SupplierName ""(.+)""")]
        public void WhenЯВвожуВПолеSupplierName(string SupplierN)
        {
            new CreateProduct(driver).TypeSupplier(SupplierN);
        }
        [When(@"Я ввожу в поле UnitPrice ""(.+)""")]
        public void WhenЯВвожуВПолеUnitPrice(string uPrice)
        {
            new CreateProduct(driver).TypeUnitPrice(uPrice);
        }

        [When(@"Я ввожу в поле QuantityPerUnit ""(.+)""")]
        public void WhenЯВвожуВПолеQuantityPerUnit(string QuantityPUn)
        {
            new CreateProduct(driver).TypeQuantPerUn(QuantityPUn);
        }



        [When(@"Я ввожу в поле UnitsInStock ""(.+)""")]
        public void WhenЯВвожуВПолеUnitsInStock(string UnInStock)
        {
            new CreateProduct(driver).TypeUnitsInStock(UnInStock);
        }

        [When(@"Я ввожу в поле ReorderLevel ""(.+)""")]
        public void WhenЯВвожуВПолеReorderLevel(string ReorderL)
        {
            new CreateProduct(driver).TypeReorderLevel(ReorderL);
        }

        [When(@"Я кликаю на кнопку Отправить")]
        public void WhenЯКликаюНаЭкраннуюКнопкуNP()
        {
            new CreateProduct(driver).ClicSubmitButNP();
        }


        [Then(@"В списке продуктов 'All Products' содержится ""(.+)""")]
        public void ThenTheProductShouldBe(string expectedProd)
        {
            Assert.AreEqual(expectedProd, new CreateProduct(driver).SearchNewProd());
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
