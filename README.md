# Sistema de Gerenciamento de Dívidas

Sistema desenvolvido em C# com .NET 8 para gerenciamento de clientes e dívidas, utilizando Entity Framework Core e MySQL.

## Funcionalidades

- Cadastro de clientes
- Atualização de clientes
- Exclusão de clientes
- Busca de clientes por nome 
- Cadastro de dívidas
- Pagamento de dívidas
- Listagem de clientes
- Listagem de dívidas em aberto
- Ordenação por maior dívida
- Paginação em todas as listagens
- Integração com banco de dados MySQL
- Exibição de tabelas utilizando ConsoleTables

## Tecnologias Utilizadas

- C#
- .NET 8
- Entity Framework Core
- MySQL
- ConsoleTables

## Estrutura do Projeto

```text
projeto/
│
├── backend/
│   │
│   ├── SistemaDividasApi/
│   │   └── (em desenvolvimento)
│   │
│   ├── SistemaDividasConsole/
│   │   ├── Data/
│   │   ├── Dtos/
│   │   ├── Models/
│   │   ├── Services/
│   │   ├── Program.cs
│   │   ├── appsettings.Development.json
│   │   └── SistemaDividasConsole.csproj
│   │
│   ├── database/
│   │   └── script.sql
│   │
│   └── Sistema-dividas.sln
│
├── frontend/
│   └── (em desenvolvimento)
│
└── README.md
```

## Configuração do Banco de Dados

### 1. Criar banco no MySQL

```sql
CREATE DATABASE NOME_DO_BANCO;
```

### 2. Executar o script SQL

Execute o arquivo:

```text
database/script.sql
```

em um servidor MySQL utilizando a ferramenta de gerenciamento de banco de dados de sua preferência.

## Dados Iniciais

O projeto disponibiliza dados fictícios para testes através do arquivo:

```text
database/script.sql
```

Após a execução do script serão criados:

- Clientes cadastrados
- Dívidas em aberto
- Dívidas pagas
- Relacionamentos entre clientes e dívidas

Esses dados permitem testar todas as funcionalidades do sistema sem necessidade de cadastramento manual.

## Configuração da Aplicação

### 1. Criar arquivo `appsettings.Development.json`

Dentro do projeto `SistemaDividaConsole`, criar o arquivo:

```text
appsettings.Development.json
```

### 2. Adicionar a connection string

```json
{
  "ConnectionStrings": {
     "Default": "server=localhost;port=3306;database=NOME_DO_BANCO;user=SEU_USUARIO;password=SUA_SENHA"
  }
}
```

## Configuração do Git

Adicionar ao `.gitignore`:

```gitignore
appsettings.Development.json
```

## Como Executar o Projeto

### 1. Restaurar dependências

```bash
dotnet restore
```

### 2. Executar o projeto

```bash
dotnet run --project SistemaDividaConsole
```

## Pacotes Utilizados

### Entity Framework Core

```bash
dotnet add package Microsoft.EntityFrameworkCore
```

### MySQL Provider

```bash
dotnet add package Pomelo.EntityFrameworkCore.MySql
```

### ConsoleTables

```bash
dotnet add package ConsoleTables
```

## Regras de Negócio

- Cliente pode possuir múltiplas dívidas
- Cliente pode possuir apenas uma dívida em aberto por vez
- CPF deve conter apenas números
- Dívidas pagas registram automaticamente a data de pagamento
- Dívidas abertas são ordenadas por maior valor

## Autor

Luiz Felipe
Autor

Luiz Felipe
