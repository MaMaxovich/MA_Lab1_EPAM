using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WDriverB.Bus_object;

namespace WDriverB.PObg
{
    class EditProduct
    {

        private IWebDriver driver;
        private int productId_t;
        public Product TsProductCDR;
        public EditProduct(Product tsProductCDR, IWebDriver driver)
        {
            this.driver = driver;
            this.TsProductCDR = tsProductCDR;
        }
        private IWebElement searchEditfildUnitPrice => driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]"));
        private IWebElement searchButtonSubmit => driver.FindElement(By.XPath("//div[2]/form/input[1]"));
        public void OpenProduct(Product prod, IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div[@class='container-fluid']//a[contains(text(), '" + prod.ProductName_t + "')]")).Click();
        }
        public string ProductName
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='ProductName'][@value]")).GetProperty("value");
            }
        }
        public string CategoryId
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/option[2][contains(@value,\"1\")]")).GetProperty("text");
            }
        }
        public string SupplierId
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='SupplierId']/option[@value='18']")).GetProperty("text");
            }
        }
        public string UnitPrice
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]")).GetProperty("value");
            }
        }
        public void EditProd()
        {
            searchEditfildUnitPrice.Clear();
            searchEditfildUnitPrice.SendKeys(TsProductCDR.UnitPrice_t);
        }
        public string QuantityPerUnit
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']")).GetProperty("value");
            }
        }
        public string UnitsInStock
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='UnitsInStock']")).GetProperty("value");
            }
        }
        public string ReorderLevel
        {
            get
            {
                return driver.FindElement(By.XPath("//*[@id='ReorderLevel']")).GetProperty("value");
            }
        }
        public int ProductId_t
        {
            get
            {
                return productId_t;
            }
            set
            {
                productId_t = value;
            }
        }
        public void FindProductId_t()
        {
            productId_t = Convert.ToInt32(driver.FindElement(By.CssSelector("#ProductId")).GetAttribute("value"));
        }
        public void SubmitEditProd()
        {
            searchButtonSubmit.Click();
        }
    }
}