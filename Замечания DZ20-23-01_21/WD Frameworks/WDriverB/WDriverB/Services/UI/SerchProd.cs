using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using WDriverB.Bus_object;
using WDriverB.PObg;

namespace WDriverB.Services.UI
{
    class SerchProd
    {
        public void OpenProduct(Product prod, IWebDriver driver)
        {
            driver.FindElement(By.XPath("//div[@class='container-fluid']//a[contains(text(), '" + prod.ProductName_t + "')]")).Click();
        }
    }
}
