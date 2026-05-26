CREATE DATABASE emporio CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci;

USE emporio;

CREATE TABLE clientes (
id INT AUTO_INCREMENT PRIMARY KEY,
nome VARCHAR(100) NOT NULL,
cpf VARCHAR(14) NOT NULL UNIQUE,
data_nascimento DATETIME NOT NULL,
email VARCHAR(255) NOT NULL
);

CREATE TABLE dividas (
id INT AUTO_INCREMENT PRIMARY KEY,
id_cliente INT NOT NULL,
valor DECIMAL(10,2) NOT NULL,
pago BOOLEAN NOT NULL,
data_criacao DATETIME NOT NULL,
data_pagamento DATETIME,
FOREIGN KEY(id_cliente) REFERENCES clientes(id)
);

INSERT INTO clientes (nome, cpf, data_nascimento, email) VALUES
('Lucas Almeida', '123.456.789-01', '1995-03-14', 'lucas.almeida@email.com'),
('Mariana Souza', '234.567.890-12', '1992-07-22', 'mariana.souza@email.com'),
('Felipe Costa', '345.678.901-23', '1988-11-05', 'felipe.costa@email.com'),
('Camila Ferreira', '456.789.012-34', '1999-01-18', 'camila.ferreira@email.com'),
('Rafael Martins', '567.890.123-45', '1990-09-30', 'rafael.martins@email.com'),
('Juliana Rocha', '678.901.234-56', '1997-04-11', 'juliana.rocha@email.com'),
('Bruno Lima', '789.012.345-67', '1985-06-27', 'bruno.lima@email.com'),
('Patricia Gomes', '890.123.456-78', '1993-12-09', 'patricia.gomes@email.com'),
('André Carvalho', '901.234.567-89', '1996-08-15', 'andre.carvalho@email.com'),
('Fernanda Ribeiro', '112.233.445-90', '1991-05-02', 'fernanda.ribeiro@email.com'),
('Thiago Oliveira', '223.344.556-01', '1987-10-19', 'thiago.oliveira@email.com'),
('Aline Barbosa', '334.455.667-12', '2000-02-25', 'aline.barbosa@email.com'),
('Gabriel Mendes', '445.566.778-23', '1994-07-08', 'gabriel.mendes@email.com'),
('Larissa Pinto', '556.677.889-34', '1998-03-21', 'larissa.pinto@email.com'),
('Eduardo Nunes', '667.788.990-45', '1989-09-13', 'eduardo.nunes@email.com'),
('Beatriz Melo', '778.899.001-56', '1995-12-01', 'beatriz.melo@email.com'),
('Vinicius Teixeira', '889.900.112-67', '1992-06-17', 'vinicius.teixeira@email.com'),
('Renata Dias', '990.011.223-78', '1997-11-28', 'renata.dias@email.com'),
('Carlos Henrique', '101.112.334-89', '1986-04-06', 'carlos.henrique@email.com'),
('Isabela Moraes', '212.223.445-90', '1999-08-24', 'isabela.moraes@email.com');