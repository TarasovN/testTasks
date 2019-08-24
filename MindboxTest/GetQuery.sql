SELECT Products.Name, Categories.Name FROM Products
LEFT JOIN ProductsCategories as pc on pc.ProductId = Products.Id
LEFT JOIN Categories on Categories.Id = pc.CategoryId