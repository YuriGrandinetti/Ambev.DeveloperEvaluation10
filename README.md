Criação do banco de das Tabelas no banco de Dados do Postgree

```sql
-- Remover o banco de dados "DeveloperEvaluation" caso já exista para evitar conflitos
DROP DATABASE IF EXISTS "DeveloperEvaluation";

-- Criar o banco de dados "DeveloperEvaluation"
CREATE DATABASE "DeveloperEvaluation";

-- Conectar ao banco de dados "DeveloperEvaluation"
\c DeveloperEvaluation

-- Remover as tabelas caso já existam para evitar conflitos
DROP TABLE IF EXISTS "ItensPedido";
DROP TABLE IF EXISTS "Pedido";
DROP TABLE IF EXISTS "Produto";
DROP TABLE IF EXISTS "Filial";
DROP TABLE IF EXISTS "Cliente";

-- Tabela Cliente: armazena os clientes
CREATE TABLE "Cliente" (
    "id" SERIAL PRIMARY KEY,
    "codigo" VARCHAR(50) NOT NULL,
    "nome" VARCHAR(100) NOT NULL
);

-- Tabela Filial: armazena as filiais
CREATE TABLE "Filial" (
    "id" SERIAL PRIMARY KEY,
    "codigo" VARCHAR(50) NOT NULL,
    "descricao" VARCHAR(100) NOT NULL
);

-- Tabela Produto: armazena os produtos e seus preços unitários
CREATE TABLE "Produto" (
    "id" SERIAL PRIMARY KEY,
    "codigo" VARCHAR(50) NOT NULL,
    "descricao" VARCHAR(100) NOT NULL,
    "precoUnitario" NUMERIC(10,2) NOT NULL
);

-- Tabela Pedido: armazena os pedidos (vendas)
CREATE TABLE "Pedido" (
    "id" SERIAL PRIMARY KEY,
    "numeroVenda" VARCHAR(50) NOT NULL,
    "dataVenda" DATE NOT NULL,
    "clienteId" INTEGER NOT NULL,
    "filialId" INTEGER NOT NULL,
    "valorTotalVenda" NUMERIC(10,2) NOT NULL,
    CONSTRAINT fk_cliente
        FOREIGN KEY ("clienteId") REFERENCES "Cliente"("id"),
    CONSTRAINT fk_filial
        FOREIGN KEY ("filialId") REFERENCES "Filial"("id")
);

-- Tabela ItensPedido: armazena os itens de cada pedido
CREATE TABLE "ItensPedido" (
    "id" SERIAL PRIMARY KEY,
    "pedidoId" INTEGER NOT NULL,
    "produtoId" INTEGER NOT NULL,
    "quantidade" INTEGER NOT NULL,
    "precoUnitario" NUMERIC(10,2) NOT NULL,
    "descontoItem" NUMERIC(10,2) DEFAULT 0,
    "valorTotalItem" NUMERIC(10,2) NOT NULL,
    "cancelado" BOOLEAN NOT NULL DEFAULT FALSE,
    CONSTRAINT fk_pedido
        FOREIGN KEY ("pedidoId") REFERENCES "Pedido"("id"),
    CONSTRAINT fk_produto
        FOREIGN KEY ("produtoId") REFERENCES "Produto"("id")
);
```

