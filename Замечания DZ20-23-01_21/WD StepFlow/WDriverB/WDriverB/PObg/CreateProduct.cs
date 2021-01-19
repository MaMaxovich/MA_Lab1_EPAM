using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace WDriverB.PObg
{
    class CreateProduct
    {
        private IWebDriver driver;

        public string ProdN = "Côtes-du-rhône";

        public CreateProduct(IWebDriver driver)
        {
            this.driver = driver;

        }

        private IWebElement SearchMenu => driver.FindElement(By.XPath("//div[2]/div[1]/a"));
        private IWebElement SearchTexstbox2 => driver.FindElement(By.XPath("//div[1]/h2[text()='All Products']"));
        private IWebElement SearchMenu2 => driver.FindElement(By.XPath("//div[2]/a"));
        private IWebElement SearchEditfild => driver.FindElement(By.XPath("//*[@id='ProductName']"));
        private IWebElement Searchdropdown => driver.FindElement(By.XPath("//*[@id='CategoryId']"));
        private IWebElement Searchdropdown2 => driver.FindElement(By.XPath("//*[@id='SupplierId']"));
        private IWebElement SearchEditfild22 => driver.FindElement(By.XPath("//*[@id='UnitPrice']"));
        private IWebElement SearchEditfild3 => driver.FindElement(By.XPath("//*[@id='QuantityPerUnit']"));
        private IWebElement SearchEditfild4 => driver.FindElement(By.XPath("//*[@id='UnitsInStock']"));
        private IWebElement SearchEditfild5 => driver.FindElement(By.XPath("//*[@id='UnitsOnOrder']"));
        private IWebElement SearchEditfild6 => driver.FindElement(By.XPath("//*[@id='ReorderLevel']"));
        private IWebElement SearchButton2 => driver.FindElement(By.XPath("//div[2]/form/input[1]"));
        private IWebElement SearchTexstbox => driver.FindElement(By.XPath("//div[1]/h2[text()='All Products']"));
        private IWebElement searchNPr => driver.FindElement(By.XPath("//*[text()=\"Côtes-du-rhône\"]"));
        public void CreateProd()
        {
            SearchMenu.Click();

            Assert.AreEqual("All Products", SearchTexstbox2.Text);

            SearchMenu2.Click();

            SearchEditfild.SendKeys(ProdN);

            Searchdropdown.SendKeys("Beverages");

            Searchdropdown2.SendKeys("Aux joyeux ecclesiastiques");

            SearchEditfild22.SendKeys("750");

            SearchEditfild3.SendKeys("75");

            SearchEditfild4.SendKeys("100");

            SearchEditfild5.SendKeys("0");

            SearchEditfild6.SendKeys("11");

           
            Assert.AreEqual("All Products", SearchTexstbox.Text);

        }
        public void clickscreenbuttonCreatenew()
        {
            SearchMenu2.Click();
        }
        public void TypeProdN(string pName)
        {
            SearchEditfild.SendKeys(pName);
        }
        public void TypeCategoryName(string beverages)
        {
            Searchdropdown.SendKeys(beverages);
        }
        public void TypeSupplier(string SupplierN)
        {
            Searchdropdown2.SendKeys(SupplierN);
        }
        public void TypeUnitPrice(string uPrice)
        {
            SearchEditfild22.SendKeys(uPrice);
        }
        public void TypeQuantPerUn(string QuantityPUn)
        {
            SearchEditfild3.SendKeys(QuantityPUn);
        }
        public void TypeUnitsInStock(string UnInStock)
        {
            SearchEditfild4.SendKeys(UnInStock);
        }
        public void TypeReorderLevel(string ReorderL)
        {
            SearchEditfild5.SendKeys(ReorderL);
        }
        public void ClicSubmitButNP()
        {
            SearchButton2.Click();
        }
        public string SearchNewProd()
        {
            return searchNPr.Text;
        }
    }
}
