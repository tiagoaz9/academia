CREATE DATABASE DynamicAcademia

USE DynamicAcademia

CREATE TABLE Products (
    ProductID INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL
);

INSERT INTO Products (Name, Description, Price, StockQuantity) VALUES 
('Whey Protein', 'Proteinas', 80.90, 100),
('Ômega 3', 'Oléo de Peixe', 80.90, 100),
('Creatina Monohidratada', 'Suplemento para força', 80.90, 100),
('Glutamina', 'Glutamina', 80.90, 100),
('Pré-treino', 'Pré Treino', 80.90, 100),
('Barra de Proteína', 'Barra de Protéina', 80.90, 100),
('Hiper Calórico', 'Hiper Calórico', 80.90, 100),
('Camiseta', 'Camiseta', 80.90, 100);
