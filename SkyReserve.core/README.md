# Flight Booking System

A console-based airline reservation system demonstrating **Clean Architecture** and advanced **C# concepts**.

## Why This Project?

This is a **learning project** created to practice professional C# development beyond simple CRUD apps. It simulates a real-world booking system with proper architecture, business logic, and state management.

### Learning Goals

Practice **OOP, LINQ, Async/Await, Collections, Nullable Types, SOLID Principles, Clean Architecture** (4 layers), **Repository Pattern**, manual **Dependency Injection**, proper **error handling**, and user-friendly **CLI design**.

## Features

✈️ Flight & seat management • 👤 Passenger registration • 🎫 Ticket booking with seat classes • 💳 Async payment processing with rollback • ❌ Cancellation system • ✅ Comprehensive validation

## Architecture

**Clean Architecture** with 4 layers: **Presentation** → **Application** → **Domain** ← **Infrastructure**

- **Domain** - Entities ([Flight](Domain/Entities/Flight.cs), [Ticket](Domain/Entities/Ticket.cs), [Passenger](Domain/Entities/Passenger.cs), [Seat](Domain/Entities/Seat.cs)), Enums, Interfaces
- **Application** - Business services ([BookingService](Application/Services/BookingService.cs), [FlightService](Application/Services/FlightService.cs), [PassengerService](Application/Services/PassengerService.cs))
- **Infrastructure** - In-memory repositories, [FakePaymentService](Infrastructure/Payment/FakePaymentService.cs), console helpers
- **Presentation** - [Program.cs](Program.cs) entry point, interactive menus

## Tech Stack & Concepts

**.NET 10.0** | **C# 10+** | **Nullable Reference Types** | **Async/Await** | **LINQ** | **Generics** | **Dependency Injection** | **xUnit (Unit Testing)**

**Patterns**: Repository • Service Layer • Factory • State Management  
**Principles**: SOLID (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion)

## Project Structure

```
SkyReserve/
├── SkyReserve.core/
│   ├── Program.cs                      # Entry point with manual DI
│   ├── Domain/                         # Entities, Enums, Interfaces
│   │   ├── Entities/                   # Flight, Passenger, Seat, Ticket
│   │   ├── Enums/                      # FlightStatus, SeatClass, TicketStatus
│   │   └── Interfaces/                 # Repository & service contracts
│   ├── Application/                    # Business logic layer
│   │   ├── DTOs/                       # Request models
│   │   ├── Extensions/                 # Mapping/helpers
│   │   └── Services/                   # BookingService, FlightService, PassengerService
│   └── Infrastructure/                 # Implementation details
│       ├── Repositories/               # In-memory storage
│       ├── Payment/                    # FakePaymentService
│       └── Persistence/                # Console helpers & menus
└── SkyReserve.Tests/                   # xUnit test project
   ├── Application/Services/           # Service-layer tests
   └── Domain/                         # Domain entity tests
```

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later

### Installation & Running

1. **Clone the repository**
   ```bash
   git clone <your-repo-url>
   cd PROJECT
   ```

2. **Build the project**
   ```bash
   dotnet build
   ```

3. **Run the application**
   ```bash
   dotnet run
   ```

### Unit Testing

This project uses **xUnit** for automated unit tests in the **SkyReserve.Tests** project.

Run tests with:

```bash
dotnet test
```

## Usage

Interactive menu provides options to view flights, book tickets, manage passengers, and handle cancellations.

**Booking Flow**: View Flights → Register Passenger → Select Flight & Seat → Process Payment → Get Confirmation

## Key Learnings

Layered architecture • Domain-driven design • Async patterns • SOLID principles • Manual dependency injection • Repository pattern • Error handling • Business logic separation


**Educational project** demonstrating C# and clean architecture best practices. In-memory storage and fake services are intentional design choices to focus on architecture over infrastructure.
