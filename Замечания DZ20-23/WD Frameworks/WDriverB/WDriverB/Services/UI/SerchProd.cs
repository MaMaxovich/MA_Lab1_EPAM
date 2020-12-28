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

        public static EditProduct OpenProduct(Product product, IWebDriver driver)
        {
            EditProduct editProduct = new EditProduct(driver);
            editProduct.OpenProduct(product, driver);
            return editProduct;
        }

    }
}
