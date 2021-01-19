using System;
using System.Collections.Generic;
using System.Text;

namespace WDriverB.Bus_object
{
    class Product
    {
        public Product(string productName_t, string categoryId_t, string supplierId_t, string unitPrice_t, string quantityPerUnit_t, string unitsInStock_t, string unitsOnOrder_t, string reorderLevel_t)
        {
            ProductName_t = productName_t;
            CategoryId_t = categoryId_t;
            SupplierId_t = supplierId_t;
            UnitPrice_t = unitPrice_t;
            QuantityPerUnit_t = quantityPerUnit_t;
            UnitsInStock_t = unitsInStock_t;
            UnitsOnOrder_t = unitsOnOrder_t;
            ReorderLevel_t = reorderLevel_t;
        }
        public string ProductName_t { get; set; }
        public string CategoryId_t { get; set; }
        public string SupplierId_t { get; set; }
        public string UnitPrice_t { get; set; }
        public string QuantityPerUnit_t { get; set; }
        public string UnitsInStock_t { get; set; }
        public string UnitsOnOrder_t { get; set; }
        public string ReorderLevel_t { get; set; }
    }
}
