Feature: SpecFlowFeature1
	Срздание продукта в БД Northwind по параметрам:
	ProductName - 
	CategoryName - 
    SupplierName - 
    QuantityPerUnit - 
    UnitPrice - 
    UnitsInStock - 
    ReorderLevel - 

@mytag
Scenario: New product in Northwind
	Given Я перехожу на "http://localhost:5000/Account/Login" страницу
	When Я ввожу в поле логина "user"
	And Я ввожу в поле пароля "user"
	And Я кликаю на экранную кнопку Отправить
	And Я кликаю на экранное меню "All Products"
	And Я кликаю на экранную кнопку 'Create new' на странице 'All Products'
	And Я ввожу в поле ProductName "Côtes-du-rhône"
	And Я ввожу в поле CategoryName "Beverages"
	And Я ввожу в поле SupplierName "Aux joyeux ecclesiastiques"
	And Я ввожу в поле UnitPrice "750"
	And Я ввожу в поле QuantityPerUnit "75"
	And Я ввожу в поле UnitsInStock "100"
	And Я ввожу в поле ReorderLevel "11"
	And Я кликаю на кнопку Отправить
	Then В списке продуктов 'All Products' содержится "Côtes-du-rhône"
