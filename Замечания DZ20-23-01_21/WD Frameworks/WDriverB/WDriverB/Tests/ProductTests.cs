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


        [Test, Order(1)]
        public void LoginSuccess()
        {
            loginPage = new LoginPage(driver);
            loginPage.LoginSuccess();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='container-fluid']/h2")));
            Assert.AreEqual("http://localhost:5000/", driver.Url);
        }


        [Test, Order(2)]
        public void CreateProd()
        {
            createProduct = new CreateProduct(driver);
            createProduct.GetAllProducts();
            createProduct.TsProductCDR = new Product("Côtes-du-rhône", "Beverages", "Aux joyeux ecclesiastiques", "750", "75", "100", "0", "11");
            createProduct.CreateProd();
        }


        [Test, Order(3)]
        public void ExamenProduct()
        {
            editProduct = new EditProduct(createProduct.TsProductCDR, driver);
            editProduct.OpenProduct(createProduct.TsProductCDR, driver);

            Assert.AreEqual(createProduct.TsProductCDR.ProductName_t, editProduct.ProductName);
            Assert.AreEqual(createProduct.TsProductCDR.CategoryId_t, editProduct.CategoryId);
            Assert.AreEqual(createProduct.TsProductCDR.SupplierId_t, editProduct.SupplierId);
            Assert.AreNotEqual(createProduct.TsProductCDR.UnitPrice_t, editProduct.UnitPrice);

            editProduct.EditProd();

            Assert.AreEqual(createProduct.TsProductCDR.UnitPrice_t, editProduct.UnitPrice);
            Assert.AreEqual(createProduct.TsProductCDR.QuantityPerUnit_t, editProduct.QuantityPerUnit);
            Assert.AreEqual(createProduct.TsProductCDR.UnitsInStock_t, editProduct.UnitsInStock);
            Assert.AreEqual(createProduct.TsProductCDR.ReorderLevel_t, editProduct.ReorderLevel);

            editProduct.FindProductId_t();
            editProduct.SubmitEditProd();

            Assert.AreEqual("All Products", driver.FindElement(By.XPath("//h2[text()='All Products']")).Text);

        }


        [Test, Order(4)]
        public void DeleteProduct()
        {
            allProducts = new AllProducts(editProduct, driver);
            allProducts.DeleteProduct();
        }

        [Test, Order(5)]
        public void LogoutSucsessTest()
        {
            //  Находим Logout в меню 
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[@href='/Account/Logout']")));
            //  Находим Logout в меню  Делаем клик на Logout
            driver.FindElement(By.CssSelector("#bs-example-navbar-collapse-1 > ul > li:nth-child(4) > a")).Click();
            // Находим слово Login в окне
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='container-fluid']/h2")));

            Assert.AreEqual("Login", driver.FindElement(By.XPath("//div[@class='container-fluid']/h2")).Text);
        }
    
    }


}
