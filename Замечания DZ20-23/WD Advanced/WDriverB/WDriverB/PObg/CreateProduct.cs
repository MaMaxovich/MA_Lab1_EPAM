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
        public static Product TsProductCDR = new Product("Côtes-du-rhône", "Beverages", "Aux joyeux ecclesiastiques", "750", "75", "100", "0", "11");

        public CreateProduct(IWebDriver driver)
        {
            this.driver = driver;

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

            SearchEditfildProductName.Click();
            SearchEditfildProductName.SendKeys(TsProductCDR.ProductName_t);
            SearchdropdownCategoryId.Click();
            SearchdropdownCategoryId.SendKeys(TsProductCDR.CategoryId_t);
            SearchdropdownSupplierId.Click();
            SearchdropdownSupplierId.SendKeys(TsProductCDR.SupplierId_t);
            SearchEditfildUnitPrice.Click();
            SearchEditfildUnitPrice.SendKeys(TsProductCDR.UnitPrice_t);
            SearchEditfildQuantityPerUnit.Click();
            SearchEditfildQuantityPerUnit.SendKeys(TsProductCDR.QuantityPerUnit_t);
            SearchEditfildUnitsInStock.Click();
            SearchEditfildUnitsInStock.SendKeys(TsProductCDR.UnitsInStock_t);
            SearchEditfildUnitsOnOrder.Click();
            SearchEditfildUnitsOnOrder.SendKeys(TsProductCDR.UnitsOnOrder_t);
            SearchEditfildReorderLevel.Click();
            SearchEditfildReorderLevel.SendKeys(TsProductCDR.ReorderLevel_t);
            searchButtonsubmit.Click();


        }

        
    }
}
