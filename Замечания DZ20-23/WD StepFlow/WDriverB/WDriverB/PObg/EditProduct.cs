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
        
        public EditProduct(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement searchEditfildUnitPrice => driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]"));
        
        private IWebElement searchButtonSubmit => driver.FindElement(By.XPath("//div[2]/form/input[1]"));

     public void OpenProduct(Product prod, IWebDriver driver)
        {
            IWebElement searchMenu = driver.FindElement(By.XPath("//div[@class='container-fluid']//a[contains(text(), '" + prod.ProductName_t +"')]"));
            searchMenu.Click();
        }  
        public string ProductName

        {
            get
            {
                IWebElement productName = driver.FindElement(By.XPath("//*[@id='ProductName'][@value]")) ;
                return productName.GetProperty("value");
            }
        }

        public string CategoryId

        {
            get
            {
                IWebElement categoryId = driver.FindElement(By.XPath("//*[@id=\"CategoryId\"]/option[2][contains(@value,\"1\")]"));
                return categoryId.GetProperty("text");
            }
        }
        public string SupplierId

        {
            get
            {
                IWebElement supplierId = driver.FindElement(By.XPath("//*[@id='SupplierId']/option[@value='18']"));
                return supplierId.GetProperty("text");
            }
        }

        public string UnitPrice

        {
            get
            {
                IWebElement unitPrice = driver.FindElement(By.XPath("//*[@id=\"UnitPrice\"]"));
                return unitPrice.GetProperty("value");
            }
        }



        public void EditProd()
        {
            searchEditfildUnitPrice.Click();
            searchEditfildUnitPrice.Clear();
            searchEditfildUnitPrice.SendKeys("750");
            }
      
            public string QuantityPerUnit

              {
                  get
                   {
                      IWebElement quantityPerUnit = driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']"));
                      return quantityPerUnit.GetProperty("value");
                  }
              }

        public string UnitsInStock

        {
            get
            {
                IWebElement unitsInStock = driver.FindElement(By.XPath("//*[@id='UnitsInStock']"));
                return unitsInStock.GetProperty("value");
            }
        }

        public string ReorderLevel

        {
            get
            {
                IWebElement reorderLevel = driver.FindElement(By.XPath("//*[@id='ReorderLevel']"));
                return reorderLevel.GetProperty("value");
            }
        }

        public void SubmitEditProd()
        {
            searchButtonSubmit.Click();
        }

   

        }
}
