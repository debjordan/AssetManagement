# AssetManagement

AssetManagement é um sistema de **gestão de ativos** (Asset Management System) desenvolvido em **.NET 8**, seguindo os princípios do **Domain-Driven Design (DDD)** e SOLID. O sistema permite cadastrar, gerenciar e monitorar equipamentos, fornecendo APIs REST para integração com front-end ou outras aplicações.

## Arquitetura

O projeto segue uma arquitetura **DDD** com múltiplas camadas:

* **Domain**: entidades, agregados, value objects e regras de negócio.
* **Application**: casos de uso, serviços de aplicação, DTOs e interfaces de repositórios.
* **Infrastructure**: implementação de repositórios, persistência (Entity Framework Core) e serviços externos.
* **API**: camada de apresentação, controllers REST, Swagger e configuração do sistema.

## Módulos

* **Equipamentos (Equipment)**: cadastro, atualização, listagem e remoção de equipamentos.
* **Auth (JWT)**: Autenticação para uso protegido da API com gerenciamento de usuários - Claims: Admin e CommonUser.

* Futuramente podem ser adicionados módulos como:

  * Manutenção
  * Inventário
  * Fornecedores
  * Financeiro / Custos
  * Monitoramento em tempo real (IoT)
  * Relatórios e KPIs

## Tecnologias

* .NET 9
* C#
* Entity Framework Core
* SQL Server ou SQLite (para testes)
* Swagger (para documentação e teste da API)

## Estrutura de Pastas

```
AssetManagement/
├─ AssetManagement.Domain/
├─ AssetManagement.Application/
├─ AssetManagement.Infrastructure/
└─ AssetManagement.API/
```

## Como Rodar

1. Restaurar pacotes:

```bash
dotnet restore
```

2. Criar migrations e atualizar o banco:

```bash
cd AssetManagement.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../AssetManagement.API
dotnet ef database update --startup-project ../AssetManagement.API
cd ..
```

3. Rodar a API:

```bash
cd AssetManagement.API
dotnet run
```

A API estará disponível em:

```
http://localhost:5000
https://localhost:5001
```

O Swagger para testes e documentação:

```
https://localhost:5001/swagger
```

## Endpoints do módulo Equipamentos

* `GET /api/equipment` – Lista todos os equipamentos
* `GET /api/equipment/{id}` – Busca equipamento por ID
* `POST /api/equipment` – Cria novo equipamento
* `PUT /api/equipment/{id}` – Atualiza equipamento
* `DELETE /api/equipment/{id}` – Remove equipamento
