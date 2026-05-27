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
('Lucas Almeida', '12345678901', '1995-03-14', 'lucas.almeida@email.com'),
('Mariana Souza', '23456789012', '1992-07-22', 'mariana.souza@email.com'),
('Felipe Costa', '34567890123', '1988-11-05', 'felipe.costa@email.com'),
('Camila Ferreira', '45678901234', '1999-01-18', 'camila.ferreira@email.com'),
('Rafael Martins', '56789012345', '1990-09-30', 'rafael.martins@email.com'),
('Juliana Rocha', '67890123456', '1997-04-11', 'juliana.rocha@email.com'),
('Bruno Lima', '78901234567', '1985-06-27', 'bruno.lima@email.com'),
('Patricia Gomes', '89012345678', '1993-12-09', 'patricia.gomes@email.com'),
('André Carvalho', '90123456789', '1996-08-15', 'andre.carvalho@email.com'),
('Fernanda Ribeiro', '11223344590', '1991-05-02', 'fernanda.ribeiro@email.com'),
('Thiago Oliveira', '22334455601', '1987-10-19', 'thiago.oliveira@email.com'),
('Aline Barbosa', '33445566712', '2000-02-25', 'aline.barbosa@email.com'),
('Gabriel Mendes', '44556677823', '1994-07-08', 'gabriel.mendes@email.com'),
('Larissa Pinto', '55667788934', '1998-03-21', 'larissa.pinto@email.com'),
('Eduardo Nunes', '66778899045', '1989-09-13', 'eduardo.nunes@email.com'),
('Beatriz Melo', '77889900156', '1995-12-01', 'beatriz.melo@email.com'),
('Vinicius Teixeira', '88990011267', '1992-06-17', 'vinicius.teixeira@email.com'),
('Renata Dias', '99001122378', '1997-11-28', 'renata.dias@email.com'),
('Carlos Henrique', '10111233489', '1986-04-06', 'carlos.henrique@email.com'),
('Isabela Moraes', '21222344590', '1999-08-24', 'isabela.moraes@email.com');

INSERT INTO dividas (valor, pago, data_criacao, data_pagamento, id_cliente) VALUES
(350.00, true,  '2026-01-10', '2026-01-20', 1),
(180.00, true,  '2026-03-05', '2026-03-18', 1),
(500.00, false, '2026-05-12', NULL, 1),
(220.00, true,  '2026-02-01', '2026-02-10', 2),
(760.00, false, '2026-04-15', NULL, 2),
(150.00, true,  '2026-01-18', '2026-01-25', 3),
(300.00, true,  '2026-03-22', '2026-03-30', 3),
(450.00, false, '2026-05-01', NULL, 3),
(980.00, false, '2026-04-02', NULL, 4),
(120.00, true,  '2026-02-12', '2026-02-20', 4),
(250.00, true,  '2026-01-07', '2026-01-17', 5),
(330.00, true,  '2026-03-10', '2026-03-19', 5),
(640.00, false, '2026-05-22', NULL, 5),
(410.00, true,  '2026-02-15', '2026-02-28', 6),
(620.00, false, '2026-05-03', NULL, 6),
(210.00, true,  '2026-01-20', '2026-01-29', 6),
(140.00, true,  '2026-02-03', '2026-02-14', 7),
(270.00, true,  '2026-04-11', '2026-04-22', 7),
(380.00, false, '2026-05-23', NULL, 7),
(890.00, false, '2026-05-09', NULL, 8),
(320.00, true,  '2026-03-07', '2026-03-18', 8),
(110.00, true,  '2026-01-30', '2026-02-05', 9),
(200.00, true,  '2026-03-12', '2026-03-25', 9),
(760.00, false, '2026-05-15', NULL, 9),
(500.00, true,  '2026-02-22', '2026-03-02', 10),
(150.00, true,  '2026-04-01', '2026-04-10', 10),
(920.00, false, '2026-05-24', NULL, 10),
(300.00, true,  '2026-01-14', '2026-01-25', 11),
(950.00, false, '2026-05-18', NULL, 11),
(180.00, true,  '2026-02-09', '2026-02-19', 12),
(240.00, true,  '2026-03-28', '2026-04-06', 12),
(700.00, false, '2026-05-20', NULL, 12),
(620.00, false, '2026-04-29', NULL, 13),
(100.00, true,  '2026-01-11', '2026-01-19', 13),
(210.00, true,  '2026-03-04', '2026-03-13', 14),
(340.00, true,  '2026-04-14', '2026-04-24', 14),
(470.00, false, '2026-05-25', NULL, 14),
(870.00, false, '2026-05-08', NULL, 15),
(190.00, true,  '2026-02-17', '2026-02-26', 15),
(120.00, true,  '2026-01-05', '2026-01-12', 16),
(240.00, true,  '2026-03-09', '2026-03-20', 16),
(560.00, false, '2026-05-26', NULL, 16),
(150.00, true,  '2026-02-13', '2026-02-22', 17),
(280.00, true,  '2026-04-05', '2026-04-15', 17),
(200.00, true,  '2026-01-25', '2026-02-03', 18),
(310.00, true,  '2026-03-16', '2026-03-27', 18),
(130.00, true,  '2026-02-07', '2026-02-16', 19),
(450.00, true,  '2026-04-18', '2026-04-30', 19),
(175.00, true,  '2026-01-28', '2026-02-08', 20),
(390.00, true,  '2026-03-21', '2026-04-02', 20);






