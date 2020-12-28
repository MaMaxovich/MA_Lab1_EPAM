using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using WDriverB.Bus_object;
using WDriverB.PObg;
using WDriverB.Services.UI;
using WDriverB;

namespace WDriverB
{
    public class Tests: BaseTests
    {
 
        private int searchProductId;
        private LoginPage loginPage;
        private CreateProduct createProduct;
        private EditProduct editProduct;
        private AllProducts allProducts;
        private IWebElement searchButtonCreate;
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [Test]
        public void Test1()
        {
            this.LoginSuccess();
            this.CreateProd();
            this.EditProduct();
            this.DeleteProduct();
            this.LogoutSucsessTest();
        }

        public void LoginSuccess()
        {
            loginPage = new LoginPage(driver);
       //     loginPage.LoginSuccess();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='container-fluid']/h2")));
            Assert.AreEqual("http://localhost:5000/", driver.Url);
        }
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
        public void EditProduct()
        {
            editProduct = SerchProd.OpenProduct(CreateProduct.TsProductCDR, driver);
         
            Assert.AreEqual(CreateProduct.TsProductCDR.ProductName_t, editProduct.ProductName);
            Assert.AreEqual(CreateProduct.TsProductCDR.CategoryId_t, editProduct.CategoryId);
            Assert.AreEqual(CreateProduct.TsProductCDR.SupplierId_t, editProduct.SupplierId);
            Assert.AreNotEqual(CreateProduct.TsProductCDR.UnitPrice_t, editProduct.UnitPrice);

            editProduct.EditProd();

            Assert.AreEqual(CreateProduct.TsProductCDR.UnitPrice_t, editProduct.UnitPrice);
            Assert.AreEqual(CreateProduct.TsProductCDR.QuantityPerUnit_t, editProduct.QuantityPerUnit);
           Assert.AreEqual(CreateProduct.TsProductCDR.UnitsInStock_t, editProduct.UnitsInStock);
           Assert.AreEqual(CreateProduct.TsProductCDR.ReorderLevel_t, editProduct.ReorderLevel);

            editProduct.SubmitEditProd();

            string searchTexstboxAllProducts = driver.FindElement(By.XPath("//h2[text()='All Products']")).Text;
            Assert.AreEqual("All Products", searchTexstboxAllProducts);
        }
        public void DeleteProduct()
        {
           
            allProducts.DeleteProduct();

        }
        public void LogoutSucsessTest()
        {
            //  Находим Logout в меню 
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/Account/Logout']")));
            IWebElement searchMenu = driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(4) > a"));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/Account/Logout']")));
            // Делаем клик на Logout
            searchMenu.Click();
            // Находим слово Login в окне
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='container-fluid']/h2")));
            string searchTexstboxLogin = driver.FindElement(By.XPath("//div[@class='container-fluid']/h2")).Text;
            Assert.AreEqual("Login", searchTexstboxLogin);
        }
    }


}
