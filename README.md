# AssetManagement

AssetManagement is an **asset management system** developed in **.NET 8**, following **Domain-Driven Design (DDD)** principles and SOLID. The system allows registering, managing, and monitoring equipment, providing REST APIs for integration with front-end or other applications.

## Architecture

The project follows a **DDD** architecture with multiple layers:

* **Domain**: entities, aggregates, value objects, and business rules
* **Application**: use cases, application services, DTOs, and repository interfaces
* **Infrastructure**: repository implementations, persistence (Entity Framework Core), and external services
* **API**: presentation layer, REST controllers, Swagger, and system configuration

## Modules

* **Equipment**: register, update, list, and remove equipment
* **Auth (JWT)**: Authentication for protected API usage with user management - Claims: Admin and CommonUser

* Future modules may include:
  * Maintenance
  * Inventory
  * Suppliers
  * Financial / Costs
  * Real-time monitoring (IoT)
  * Reports and KPIs

## Technologies

* .NET 9
* C#
* Entity Framework Core
* SQL Server or SQLite (for testing)
* Swagger (for API documentation and testing)

## Folder Structure

```
AssetManagement/
├─ AssetManagement.Domain/
├─ AssetManagement.Application/
├─ AssetManagement.Infrastructure/
└─ AssetManagement.API/
```

## How to Run

1. Restore packages:

```bash
dotnet restore
```

2. Create migrations and update the database:

```bash
cd AssetManagement.Infrastructure
dotnet ef migrations add InitialCreate --startup-project ../AssetManagement.API
dotnet ef database update --startup-project ../AssetManagement.API
cd ..
```

3. Run the API:

```bash
cd AssetManagement.API
dotnet run
```

The API will be available at:

```
http://localhost:5000
https://localhost:5001
```

Swagger for testing and documentation:

```
https://localhost:5001/swagger
```

## Equipment Module Endpoints

* `GET /api/equipment` – List all equipment
* `GET /api/equipment/{id}` – Find equipment by ID
* `POST /api/equipment` – Create new equipment
* `PUT /api/equipment/{id}` – Update equipment
* `DELETE /api/equipment/{id}` – Remove equipment
