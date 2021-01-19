using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WDriverB.Bus_object;

namespace WDriverB.PObg
{
    class CreateProduct
    {
   private IWebDriver driver;
   public Product TsProductCDR;
       
        public CreateProduct(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement searchMenu => driver.FindElement(By.XPath("//ul[@class='nav navbar-nav']//a[@href='/Product']"));
        private IWebElement SearchButtonCreate => driver.FindElement(By.XPath("//div[@class='container-fluid']/a[@href='/Product/Create']"));
        public void GetAllProducts()
        {
            searchMenu.Click();
            SearchButtonCreate.Click();
        }
        private IWebElement SearchEditfildProductName => driver.FindElement(By.XPath("//*[@id='ProductName']"));
        private IWebElement SearchdropdownCategoryId => driver.FindElement(By.XPath("//*[@id='CategoryId']"));
        private IWebElement SearchdropdownSupplierId => driver.FindElement(By.XPath("//*[@id='SupplierId']"));
        private IWebElement SearchEditfildUnitPrice => driver.FindElement(By.XPath("//*[@id='UnitPrice']"));
        private IWebElement SearchEditfildQuantityPerUnit => driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']"));
        private IWebElement SearchEditfildUnitsInStock => driver.FindElement(By.XPath("//*[@id='UnitsInStock']"));
        private IWebElement SearchEditfildUnitsOnOrder => driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']"));
        private IWebElement SearchEditfildReorderLevel => driver.FindElement(By.XPath("//*[@id='ReorderLevel']"));
        private IWebElement searchButtonsubmit => driver.FindElement(By.XPath("//div[@class='container-fluid']/form/input[@type='submit']"));
        public void CreateProd()
        {
            SearchEditfildProductName.SendKeys(TsProductCDR.ProductName_t);

            SearchdropdownCategoryId.SendKeys(TsProductCDR.CategoryId_t);

            SearchdropdownSupplierId.SendKeys(TsProductCDR.SupplierId_t);

            SearchEditfildUnitPrice.SendKeys(TsProductCDR.UnitPrice_t);

            SearchEditfildQuantityPerUnit.SendKeys(TsProductCDR.QuantityPerUnit_t);

            SearchEditfildUnitsInStock.SendKeys(TsProductCDR.UnitsInStock_t);

            SearchEditfildUnitsOnOrder.SendKeys(TsProductCDR.UnitsOnOrder_t);

            SearchEditfildReorderLevel.SendKeys(TsProductCDR.ReorderLevel_t);
            searchButtonsubmit.Click();

            Assert.AreEqual("All Products", driver.FindElement(By.XPath("//div[@class='container-fluid']/h2[text()='All Products']")).Text);
        }
    }  
}
