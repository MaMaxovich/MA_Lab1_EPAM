using NUnit.Framework;
using OpenQA.Selenium;
using WDriverB.Bus_object;
using System;
using System.Collections.Generic;
using System.Text;

namespace WDriverB.PObg
{
    class AllProducts
    {
        private IWebDriver driver;
        private EditProduct product;

        public AllProducts(EditProduct product, IWebDriver driver)
        {
            this.driver = driver;
            this.product = product;
        }

        public void DeleteProduct()
        {

            Assert.AreEqual("All Products", driver.FindElement(By.XPath("//div[@class='container-fluid']/h2")).Text);
           // Находим элемент удаления продукта и кликаем по нему
            driver.FindElement(By.CssSelector("a[href=\"/Product/Remove?ProductId=" + product.ProductId_t + "\"] ")).Click();
            // Подтверждаем удаление в диалоговом окне
           driver.SwitchTo().Alert().Accept();
        }

    }

}
