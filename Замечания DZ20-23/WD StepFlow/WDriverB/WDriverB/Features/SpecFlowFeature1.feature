Feature: SpecFlowFeature1
	Срздание продукта в БД Northwind 
	ProductName - 
	CategoryName - 
    SupplierName - 
    QuantityPerUnit - 
    UnitPrice - 
    UnitsInStock - 
    ReorderLevel - 

Scenario: New product in Northwind
	Given Я перехожу на "http://localhost:5000/Account/Login" страницу
	When Я ввожу в поле логина "user"
	When Я ввожу в поле пароля "user"
	When Я кликаю на экранную кнопку Отправить
	When Я кликаю на экранное меню "All Products"
	Then Я запускаю создание нового продукта в БД Northwind 

