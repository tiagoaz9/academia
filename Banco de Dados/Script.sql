CREATE DATABASE DynamicAcademia;

USE DynamicAcademia;

CREATE TABLE Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    StockQuantity INT NOT NULL,
    Image VARCHAR(200) NOT NULL
);

INSERT INTO Products (Name, Description, Price, StockQuantity, Image) VALUES 
('Whey Protein', 'Proteinas', 80.90, 100, '/img/produtos/produto-1.png'),
('Ômega 3', 'Oléo de Peixe', 80.90, 100, '/img/produtos/produto-2.png'),
('Creatina Monohidratada', 'Suplemento para força', 80.90, 100, '/img/produtos/produto-3.png'),
('Glutamina', 'Glutamina', 80.90, 100, '/img/produtos/produto-4.png'),
('Pré-treino', 'Pré Treino', 80.90, 100, '/img/produtos/produto-5.png'),
('Barra de Proteína', 'Barra de Protéina', 80.90, 100, '/img/produtos/produto-6.png'),
('Hiper Calórico', 'Hiper Calórico', 80.90, 100, '/img/produtos/produto-7.png'),
('Camiseta', 'Camiseta', 80.90, 100, '/img/produtos/produto-8.png');


CREATE TABLE Aulas (
	Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Image VARCHAR(200) NOT NULL
);

INSERT INTO Aulas (Name, Description, Image) VALUES
('Musculação', 'Levantamento de Pesos', '/img/classes/class-1.jpg'),
('Funcional', 'Versatilidade Física', '/img/classes/class-2.jpg'),
('FitDance', 'Dança Fitness', '/img/classes/class-3.jpg');

CREATE TABLE Planos (
	Id INT AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Price DECIMAL(10, 2) NOT NULL
);

INSERT INTO Planos (Name, Price) VALUES
('Mensalidade', 90),
('Gympass', 49),
('Aula Avulsa', 10);
