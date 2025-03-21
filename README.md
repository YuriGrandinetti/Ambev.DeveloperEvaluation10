# 🧾 DeveloperEvaluation - Backend

Este projeto representa uma aplicação backend voltada para avaliação de desenvolvedores, estruturada com foco em boas práticas de arquitetura, testes, e organização de código. Ele foi construído com .NET, aplicando padrões de projeto modernos, integração com banco de dados e testes automatizados.

---

## 🚀 Como Executar o Projeto

1. **Clonar o repositório:**

```bash
git clone https://gitlab.com/seu-usuario/seu-repositorio.git
cd seu-repositorio
```

2. **Configurar o banco de dados:**

Certifique-se de que um banco PostgreSQL está ativo. Utilize o script SQL abaixo para criar o banco e as tabelas:

<details>
  <summary><strong>Script SQL - Criação de Tabelas</strong></summary>

```sql
-- Criar banco de dados
DROP DATABASE IF EXISTS "DeveloperEvaluation";
CREATE DATABASE "DeveloperEvaluation";
\c DeveloperEvaluation

-- Criar tabelas
DROP TABLE IF EXISTS "ItensPedido";
DROP TABLE IF EXISTS "Pedido";
DROP TABLE IF EXISTS "Produto";
DROP TABLE IF EXISTS "Filial";
DROP TABLE IF EXISTS "Cliente";

CREATE TABLE "Cliente" (
    "id" SERIAL PRIMARY KEY,
    "codigo" VARCHAR(50) NOT NULL,
    "nome" VARCHAR(100) NOT NULL
);

CREATE TABLE "Filial" (
    "id" SERIAL PRIMARY KEY,
    "codigo" VARCHAR(50) NOT NULL,
    "descricao" VARCHAR(100) NOT NULL
);

CREATE TABLE "Produto" (
    "id" SERIAL PRIMARY KEY,
    "codigo" VARCHAR(50) NOT NULL,
    "descricao" VARCHAR(100) NOT NULL,
    "precoUnitario" NUMERIC(10,2) NOT NULL
);

CREATE TABLE "Pedido" (
    "id" SERIAL PRIMARY KEY,
    "numeroVenda" VARCHAR(50) NOT NULL,
    "dataVenda" DATE NOT NULL,
    "clienteId" INTEGER NOT NULL,
    "filialId" INTEGER NOT NULL,
    "valorTotalVenda" NUMERIC(10,2) NOT NULL,
    CONSTRAINT fk_cliente FOREIGN KEY ("clienteId") REFERENCES "Cliente"("id"),
    CONSTRAINT fk_filial FOREIGN KEY ("filialId") REFERENCES "Filial"("id")
);

CREATE TABLE "ItensPedido" (
    "id" SERIAL PRIMARY KEY,
    "pedidoId" INTEGER NOT NULL,
    "produtoId" INTEGER NOT NULL,
    "quantidade" INTEGER NOT NULL,
    "precoUnitario" NUMERIC(10,2) NOT NULL,
    "descontoItem" NUMERIC(10,2) DEFAULT 0,
    "valorTotalItem" NUMERIC(10,2) NOT NULL,
    "cancelado" BOOLEAN NOT NULL DEFAULT FALSE,
    CONSTRAINT fk_pedido FOREIGN KEY ("pedidoId") REFERENCES "Pedido"("id"),
    CONSTRAINT fk_produto FOREIGN KEY ("produtoId") REFERENCES "Produto"("id")
);
```
</details>

3. **Executar a aplicação:**

```bash
dotnet build
cd src/DeveloperEvaluation.Api
dotnet run
```

A aplicação será iniciada na URL `https://localhost:5001` ou `http://localhost:5000`.

---

## 🧩 Abordagens Arquiteturais Utilizadas

### 🧱 Desenvolvimento Orientado a Domínio (DDD)
Modelagem centrada nas regras de negócio, promovendo encapsulamento e consistência.

### 🏛 Clean Architecture
Separando responsabilidades entre domínio, aplicação e infraestrutura, permite evolução e testes independentes.

### 🧪 Test-Driven Development (TDD)
Testes unitários implementados com apoio de Test Data Builders, garantindo qualidade e feedback rápido.

### ⚙️ Princípios SOLID
Responsabilidades bem definidas, métodos simples e coesos, respeitando a manutenção do sistema.

### 🧩 Injeção de Dependências (DI)
Uso de construtores para injetar dependências e promover desacoplamento.

### 🧠 Padrões de Design Aplicados
- `Command`
- `Mediator`
- `Repository`
- `Specification`
- `Null Object`
- `Test Data Builder`

---

## 🧠 Padrões de Projeto Utilizados

### ✅ Command Pattern
Encapsula a intenção de realizar uma ação (ex: `CreateSaleCommand`) separando responsabilidade da execução.

### ✅ Mediator Pattern
Comunicacão entre componentes feita via `IMediator`, reduzindo acoplamento.

### ✅ Repository Pattern
Interfaces como `ISaleRepository` isolam o acesso a dados da lógica de negócio.

### ✅ Specification Pattern
Regras complexas encapsuladas em especificações reutilizáveis (ex: `ActiveUserSpecification`).

### ✅ Test Data Builder Pattern
Classes auxiliares como `SaleTestData` e `UserTestData` geram cenários de teste de forma organizada.

### ✅ Null Object Pattern
Uso de `NullLogger<T>` evita verificacões nulas e facilita testes.

### ✅ Dependency Injection
Aplicada via construtor, melhora testabilidade e desacoplamento de componentes.

---

## ✅ Testes

- Utiliza **xUnit** para execução dos testes.
- Usa **NSubstitute** para mocks e isolamentos.
- Estruturado com base em classes de `TestData` reutilizáveis.

Para executar os testes:

```bash
cd tests/DeveloperEvaluation.Unit
dotnet test
```

---

## 📁 Estrutura de Pastas

```text
├── src
│   ├── DeveloperEvaluation.Api
│   ├── DeveloperEvaluation.Application
│   ├── DeveloperEvaluation.Domain
│   └── DeveloperEvaluation.Infrastructure
├── tests
│   ├── DeveloperEvaluation.Unit
│   └── DeveloperEvaluation.Integration (se houver)
└── README.md
```

---

## 🧾 Licença

Este projeto é apenas para fins de avaliação e estudo.

