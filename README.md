Clean Architecture .NET 8 – Employee Management API
📌 Project Description

This project is a beginner-friendly implementation of Clean Architecture in .NET 8 using ASP.NET Core Web API and Entity Framework Core (InMemory database).

The purpose of this project is to demonstrate how to structure a real-world .NET application using Clean Architecture principles, focusing on separation of concerns, maintainability, testability, and scalability.

It includes a simple Employee CRUD API and follows industry-standard architectural practices used in enterprise applications.

🧱 Architecture Overview

The solution follows Clean Architecture, where:

Business logic is independent of frameworks

Dependencies always point inward

Infrastructure concerns are isolated

The application is easy to test and extend

API → Application → Domain
     → Infrastructure

📂 Project Structure
CleanArchitectureDemo
├── CleanArchitecture.Domain
│   └── Entities
│       └── Employee.cs
│
├── CleanArchitecture.Application
│   ├── DTOs
│   │   └── EmployeeDto.cs
│   ├── Interfaces
│   │   └── IEmployeeRepository.cs
│   └── Services
│       └── EmployeeService.cs
│
├── CleanArchitecture.Infrastructure
│   ├── Data
│   │   └── AppDbContext.cs
│   └── Repositories
│       └── EmployeeRepository.cs
│
└── CleanArchitecture.API
    ├── Controllers
    │   └── EmployeesController.cs
    └── Program.cs

🔑 Layer Responsibilities
Domain

Contains business entities

No dependency on frameworks or external libraries

Application

Contains business use cases

Defines interfaces and DTOs

Depends only on the Domain layer

Infrastructure

Contains EF Core DbContext

Implements repository interfaces

Handles database and external concerns

API

Entry point of the application

Configures dependency injection

Exposes REST endpoints

🚀 Technologies Used

.NET 8

ASP.NET Core Web API

Entity Framework Core (InMemory)

Clean Architecture

Dependency Injection

Swagger / OpenAPI

▶️ How to Run the Project
Prerequisites

Visual Studio 2022 (17.8+)

.NET 8 SDK

Steps

Clone the repository

Open the solution in Visual Studio

Set CleanArchitecture.API as the startup project

Press F5 to run the application

Swagger UI will open automatically

🔌 API Endpoints
Get All Employees
GET /api/employees

Create Employee
POST /api/employees


Request Body

{
  "name": "John Doe",
  "email": "john@test.com",
  "departmentId": 1
}

🧪 Data Storage

Uses EF Core InMemory Database

Pre-seeded with sample employee data on startup

No database setup required

✅ Benefits of This Architecture

Clear separation of concerns

Easy to unit test

Database independent

Enterprise-ready structure

Ideal for learning and interviews

🧠 Learning Goals

This project helps you understand:

Clean Architecture fundamentals

Dependency inversion

Repository pattern

DTO usage

Proper layering in .NET applications

🔮 Possible Enhancements

Add Update & Delete operations

Add Unit Testing (xUnit + Moq)

Introduce CQRS with MediatR

Switch to SQL Server

Add logging and global exception handling

📖 Ideal For

.NET beginners learning architecture

Developers preparing for interviews

Engineers moving toward Solution Architect roles

Clean Architecture reference project

👨‍💻 Author

Avijit Atta
.NET Developer | Clean Architecture Enthusiast

⭐ Final Note

If you find this project useful, consider giving it a ⭐ on GitHub!
