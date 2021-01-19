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
        private CreateProduct createProduct;
        private MainPage mainPage;

        [Given(@"Я перехожу на ""(.+)"" страницу")]
        public void INavigateToUrl(string url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));

        }
        [When(@"Я ввожу в поле логина ""(.+)""")]
        public void WhenIinputintheloginfield(string loginputSF)
        {
            mainPage = new MainPage(driver);
                mainPage.TypeLogin(loginputSF);
        }

        [When(@"Я ввожу в поле пароля ""(.*)""")]
        public void WhenIinputinthepasswordfield(string passinputSF)
        {
            mainPage.TypePass(passinputSF);
        }

        [When(@"Я кликаю на экранную кнопку Отправить")]
        public void WhenIclickontheSubmitbutton()
        {
            mainPage.ClicSubmitBut();
        }


        [When(@"Я кликаю на экранное меню ""(.+)""")]
        public void WhenIclickontheOSD(string allprod)

        {
             mainPage.SearchMenu();
            
        }

        [When(@"Я кликаю на экранную кнопку 'Create new' на странице 'All Products'")]
        public void WhenIclickontheonscreenbuttononthepage()

        {
            createProduct = new CreateProduct(driver);
                createProduct.clickscreenbuttonCreatenew();
        }

        [When(@"Я ввожу в поле ProductName ""(.+)""")]
        public void WhenIinputintheProductNamefield(string pName)
        {
            createProduct.TypeProdN(pName);
        }

        [When(@"Я ввожу в поле CategoryName ""(.+)""")]
        public void WhenIinputintheCategoryNamefield(string beverages)
        {
            createProduct.TypeCategoryName(beverages);
        }

        [When(@"Я ввожу в поле SupplierName ""(.+)""")]
        public void WhenIinputintheSupplierNamefield(string SupplierN)
        {
            createProduct.TypeSupplier(SupplierN);
        }
        [When(@"Я ввожу в поле UnitPrice ""(.+)""")]
        public void WhenIinputintheUnitPricefield(string uPrice)
        {
            createProduct.TypeUnitPrice(uPrice);
        }

        [When(@"Я ввожу в поле QuantityPerUnit ""(.+)""")]
        public void WhenIinputintheQuantityPerUnitfield(string QuantityPUn)
        {
            createProduct.TypeQuantPerUn(QuantityPUn);
        }



        [When(@"Я ввожу в поле UnitsInStock ""(.+)""")]
        public void WhenIinputintheUnitsInStockfield(string UnInStock)
        {
            createProduct.TypeUnitsInStock(UnInStock);
        }

        [When(@"Я ввожу в поле ReorderLevel ""(.+)""")]
        public void WhenIinputintheReorderLevelfield(string ReorderL)
        {
            createProduct.TypeReorderLevel(ReorderL);
        }

        [When(@"Я кликаю на кнопку Отправить")]
        public void WhenIclickonthebuttonNP()
        {
            createProduct.ClicSubmitButNP();
        }


        [Then(@"В списке продуктов 'All Products' содержится ""(.+)""")]
        public void ThenTheProductShouldBe(string expectedProd)
        {
            Assert.AreEqual(expectedProd, createProduct.SearchNewProd());
        }

        [AfterScenario]
        public void CloseDriver()
        {
            driver.Close();
            driver.Quit();
        }

    }
}
