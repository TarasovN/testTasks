CREATE TABLE Products(
 	Id int NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	Name nvarchar(300) NOT NULL
);

CREATE TABLE Categories(
	Id int NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Name nvarchar(300) NOT NULL
);

CREATE TABLE ProductsCategories(
	ProductId int NOT NULL,
	CategoryId int NOT NULL,
	FOREIGN KEY (ProductId) REFERENCES Products(Id),
	FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
	UNIQUE(ProductId, CategoryId)
);