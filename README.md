# TableFlow

**TableFlow** is a full-stack reservation management platform for restaurants, bars, and nightclubs.

The goal is to make table reservations easier for customers while giving venues a centralized system to manage availability, seating arrangements, bookings, and guests.

> **Project Status: Active Development — Milestone 2: Core Domain & Persistence**
>
> **Completed:**
> - **TF-001 — Project Foundation:** ASP.NET Core 10 backend, React + TypeScript frontend, layered backend architecture, and successful build verification.
> - **TF-002 — Core Venue Domain Model:** Implemented the `Venue` entity with identity validation, name normalization, venue types, IANA time zone validation, and controlled updates.
> - **Automated Testing:** Added an xUnit test project with 31 passing test cases.
>
> **Current Focus:** Expanding the domain model with additional hospitality concepts before introducing database persistence.
>
> **Next:** TF-003 — Next domain development ticket.
>
> **Note:** The backend API and frontend are currently starter applications. Domain modeling is underway, but reservation workflows, PostgreSQL persistence, authentication, and venue-management interfaces have not yet been implemented.

---

## Planned Features

### Customer Platform

- Discover participating restaurants, bars, and nightclubs.
- Search for available tables by date, time, and party size.
- View interactive floor plans and seating zones.
- Reserve available tables online.
- Receive reservation confirmations.
- View and manage existing reservations.

### Venue Management Platform

- Create and manage restaurant or nightclub profiles.
- Configure seating zones and tables.
- Manage reservations through a centralized dashboard.
- Register phone reservations and walk-ins.
- Manage nightclub events and VIP table bookings.
- Monitor availability and reservation statuses.

### Core Engineering Features

- Concurrency-safe reservation processing.
- Prevention of overlapping bookings.
- Authentication and role-based authorization.
- PostgreSQL persistence with Entity Framework Core.
- Real-time availability updates using SignalR.
- Automated testing and CI/CD.

The features above represent the long-term product roadmap. Not all are implemented yet.

---

## Technology Stack

| Layer | Technology | Status |
|---|---|---|
| Frontend | React, TypeScript, Vite | Initialized |
| Backend | C#, ASP.NET Core 10 Web API | Initialized |
| Architecture | Clean Architecture-inspired layered design | Implemented |
| Domain Modeling | C# entities, enums, validation | In progress |
| Unit Testing | xUnit, Microsoft.NET.Test.Sdk | Implemented |
| Code Coverage | coverlet.collector | Configured |
| Database | PostgreSQL | Planned |
| ORM | Entity Framework Core | Planned |
| Authentication | ASP.NET Core Identity | Planned |
| Real-time Communication | SignalR | Planned |
| CI/CD | GitHub Actions | Planned |
| Version Control | Git, GitHub | Implemented |

---

## Project Architecture

TableFlow is being developed as a **modular monolith** with a layered backend architecture.

The backend separates business rules, application workflows, infrastructure concerns, and HTTP communication.

### Backend Projects

#### 1. TableFlow.Api

The entry point of the backend application.

**Responsibilities:**
- Expose HTTP endpoints.
- Handle incoming requests and outgoing responses.
- Configure middleware and dependency injection.
- Connect application functionality to external clients.

**Current status:** ASP.NET Core 10 Web API initialized with template endpoints.

#### 2. TableFlow.Application

Coordinates application use cases and workflows.

**Responsibilities:**
- Implement application use cases.
- Define interfaces for external dependencies.
- Coordinate business operations.
- Handle application-level validation and DTOs.

**Current status:** Project initialized. Application use cases are planned.

#### 3. TableFlow.Domain

Contains the core business concepts and rules.

**Responsibilities:**
- Define entities, enums, and value objects.
- Enforce domain invariants.
- Protect business rules through encapsulation.
- Remain independent of the API, database, and external services.

**Currently implemented:**

**Venue**
- Validates venue and organization identifiers.
- Stores a normalized venue name between 3 and 100 characters.
- Supports controlled venue-name updates.
- Rejects undefined venue types.
- Validates venue time zone identifiers using .NET's time zone functionality.
- Prevents unrestricted modification of important properties.

**VenueType**
- Restaurant
- Bar
- Nightclub

**Current status:** Initial Venue domain model implemented and tested.

#### 4. TableFlow.Infrastructure

Implements technical integrations required by the application.

**Planned responsibilities:**
- Database persistence using EF Core and PostgreSQL.
- Repository implementations where appropriate.
- Database configuration and migrations.
- External service integrations such as email and payments.

**Current status:** Project initialized. Infrastructure functionality is not yet implemented.

#### 5. TableFlow.Domain.Tests

Contains automated unit tests for domain behavior.

**Responsibilities:**
- Verify business rules and invariants.
- Test valid and invalid inputs.
- Test domain boundary conditions.
- Ensure invalid operations do not corrupt entity state.
- Detect regressions when domain code changes.

**Currently implemented:**

`VenueTests.cs` covers:
- Valid Venue creation.
- Invalid venue and organization identifiers.
- Name validation and boundary values.
- Name normalization.
- Valid and invalid name updates.
- Preservation of existing state after invalid updates.
- Supported and unsupported venue types.
- Valid and invalid time zone identifiers.

**Latest verified result: 31 tests passed, 0 failed.**

---

## Dependency Structure

The backend uses the following project references:

| Project | References |
|---|---|
| TableFlow.Api | Application, Infrastructure |
| TableFlow.Application | Domain |
| TableFlow.Infrastructure | Application, Domain |
| TableFlow.Domain | None |
| TableFlow.Domain.Tests | Domain |

The dependency structure follows these principles:

1. The **Domain layer** is independent of other application projects.
2. The **Application layer** depends on Domain, not Infrastructure.
3. The **Infrastructure layer** implements technical concerns required by the application.
4. The **API layer** serves as the entry point and composition root.
5. The **test project** references the production code it tests.

This separation improves testability, maintainability, and flexibility as the platform grows.

---

## Repository Structure

```text
TableFlow/
├── backend/
│   ├── TableFlow.sln
│   │
│   ├── TableFlow.Api/
│   │   ├── Controllers/
│   │   │   └── WeatherForecastController.cs
│   │   ├── Properties/
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   └── TableFlow.Api.csproj
│   │
│   ├── TableFlow.Application/
│   │   └── TableFlow.Application.csproj
│   │
│   ├── TableFlow.Domain/
│   │   ├── Venue.cs
│   │   ├── VenueType.cs
│   │   └── TableFlow.Domain.csproj
│   │
│   ├── TableFlow.Infrastructure/
│   │   └── TableFlow.Infrastructure.csproj
│   │
│   └── TableFlow.Domain.Tests/
│       ├── VenueTests.cs
│       └── TableFlow.Domain.Tests.csproj
│
├── frontend/
│   ├── public/
│   ├── src/
│   │   ├── assets/
│   │   ├── App.tsx
│   │   └── main.tsx
│   ├── package.json
│   ├── package-lock.json
│   ├── tsconfig.json
│   └── vite.config.ts
│
├── .gitignore
├── LICENSE
└── README.md
```

This is a simplified overview of the main source files. Generated build output and some supporting files are omitted.

---

## Getting Started

### Prerequisites

Install the following tools:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) and npm, using a Node.js version compatible with the installed Vite release
- [Git](https://git-scm.com/)
- Visual Studio or Visual Studio Code

PostgreSQL is not required for the current development stage.

### 1. Clone the Repository

```bash
git clone https://github.com/Lukanoid/TableFlow.git
cd TableFlow
```

### 2. Restore and Build the Backend

From the repository root:

```bash
dotnet restore backend/TableFlow.sln
dotnet build backend/TableFlow.sln
```

This builds all backend projects, including the domain unit test project.

### 3. Run the Backend API

From the repository root:

```bash
dotnet run --project backend/TableFlow.Api --launch-profile https
```

Alternatively, open `backend/TableFlow.sln` in a compatible version of Visual Studio and run the API project.

With the current launch settings, the development API is available at:

```text
https://localhost:7295
```

The template-generated test endpoint is:

```text
https://localhost:7295/weatherforecast
```

The port may vary depending on local settings.

The WeatherForecast endpoint is temporary and will be replaced with TableFlow-specific endpoints.

### 4. Install Frontend Dependencies

Open a separate terminal.

From the repository root:

```bash
cd frontend
npm ci
```

### 5. Run the Frontend

From the `frontend` directory:

```bash
npm run dev
```

Vite will display a development URL, typically:

```text
http://localhost:5173
```

The frontend currently displays the starter interface. TableFlow-specific UI components will be developed in future tickets.

### 6. Build the Frontend

From the `frontend` directory:

```bash
npm run build
```

This command runs TypeScript compilation followed by a Vite production build.

Generated output is placed in `frontend/dist/`, which is excluded from version control.

---

## Running Automated Tests

TableFlow uses **xUnit** for backend unit testing.

The initial test suite verifies the behavior of the Venue domain entity.

### Run All Backend Tests

From the repository root:

```bash
dotnet test backend/TableFlow.sln
```

Alternatively, navigate to the backend directory:

```bash
cd backend
dotnet test TableFlow.sln
```

### Run Only Domain Tests

From the repository root:

```bash
dotnet test backend/TableFlow.Domain.Tests/TableFlow.Domain.Tests.csproj
```

### Run Tests in Visual Studio

1. Open `backend/TableFlow.sln`.
2. Select **Test → Test Explorer**.
3. Select **Run All Tests**.
4. Inspect individual results and failures.

### Testing Conventions

- Use descriptive test method names.
- Follow the Arrange–Act–Assert pattern.
- Use `[Fact]` for individual scenarios.
- Use `[Theory]` and `[InlineData]` for parameterized scenarios.
- Test both valid and invalid inputs.
- Include boundary value tests.
- Verify state preservation after rejected operations.
- Keep tests independent of one another.

### Latest Verified Test Result

```text
Total tests: 31
Passed:      31
Failed:       0
Skipped:      0
```

These results reflect the latest locally verified test run, not an automatically updated CI status.

---

## Development Guidelines

### Architecture

- Keep the Domain layer independent of infrastructure and presentation concerns.
- Preserve the established project-reference direction.
- Put entity-specific business invariants inside domain entities.
- Keep database access and external integrations out of the Domain project.
- Introduce abstractions only when there is a clear need.

### Code Quality

- Follow established C# and TypeScript conventions.
- Use meaningful class, method, property, and variable names.
- Prefer encapsulation over unrestricted public setters.
- Keep validation behavior consistent.
- Avoid unnecessary dependencies and premature complexity.
- Add appropriate unit tests when implementing business behavior.

### Git and Repository Hygiene

- Write meaningful commit messages.
- Keep changes focused on individual development tickets.
- Do not commit credentials, API keys, or private environment files.
- Do not commit `node_modules/`, `dist/`, or .NET `bin/` and `obj/` directories.
- Update documentation when project structure or completed functionality changes.

### Development Workflow

TableFlow follows a ticket-based development process:

1. Define a ticket with requirements and acceptance criteria.
2. Implement the solution.
3. Add or update automated tests.
4. Build and run the relevant projects.
5. Submit the changes for code review.
6. Address review feedback.
7. Commit and push approved changes.

This process is intended to reflect real-world software engineering practices.

---

## Development Roadmap

### Milestone 1 — Project Foundation

- [x] Initialize Git repository.
- [x] Configure `.gitignore`.
- [x] Create ASP.NET Core 10 solution.
- [x] Create API, Application, Domain, and Infrastructure projects.
- [x] Configure project references.
- [x] Initialize React + TypeScript frontend.
- [x] Verify backend build.
- [x] Verify frontend production build.
- [x] Document the development environment.

**Status: Completed — TF-001**

### Milestone 2 — Core Domain and Persistence

- [x] Implement Venue domain entity and validation (TF-002).
- [x] Implement venue type classification.
- [x] Implement venue time zone validation.
- [x] Add xUnit domain test project.
- [x] Verify 31 Venue test cases.
- [ ] Implement table and seating-related domain concepts.
- [ ] Configure PostgreSQL.
- [ ] Introduce Entity Framework Core.
- [ ] Create initial database migrations.
- [ ] Implement venue management application use cases.

**Status: In Progress**

### Milestone 3 — Reservation Engine

- [ ] Implement reservation creation.
- [ ] Implement availability checks.
- [ ] Prevent overlapping reservations.
- [ ] Support reservation cancellation and statuses.
- [ ] Handle concurrent reservation attempts safely.
- [ ] Add reservation unit and integration tests.

**Status: Planned**

### Milestone 4 — Interactive Floor Plans

- [ ] Implement seating zones and visual table layouts.
- [ ] Add a floor-plan management interface.
- [ ] Allow customers to select eligible tables.
- [ ] Connect floor-plan availability to reservation data.

**Status: Planned**

### Milestone 5 — Restaurant and Nightclub Features

- [ ] Support restaurant time-based reservations.
- [ ] Support nightclub event reservations.
- [ ] Introduce VIP table booking rules.
- [ ] Build venue reservation management dashboards.
- [ ] Support manually registered reservations and walk-ins.

**Status: Planned**

### Milestone 6 — Production Readiness

- [ ] Implement authentication and authorization.
- [ ] Introduce real-time updates with SignalR.
- [ ] Enable stricter TypeScript checks and improve frontend linting.
- [ ] Replace starter templates with production application code.
- [ ] Add automated build and test workflows using GitHub Actions.
- [ ] Expand test coverage and integration testing.
- [ ] Improve security, logging, and error handling.
- [ ] Prepare deployment configuration.
- [ ] Deploy a working demonstration.

**Status: Planned**

The roadmap is subject to refinement as development progresses.

---

## Project Purpose

TableFlow is being developed as a flagship full-stack software engineering portfolio project, with the long-term possibility of evolving into a commercial SaaS platform for hospitality venues.

The project focuses on:

- Practical full-stack application development.
- Clean architectural boundaries.
- Strong C# and TypeScript fundamentals.
- Domain-driven business modeling.
- Relational database design.
- Reliable and concurrency-safe reservation processing.
- Automated testing and maintainable code.
- Iterative development through real-world engineering practices.

The goal is not only to build a working product but also to develop a maintainable codebase that demonstrates practical software engineering skills.

---

## License

This project is licensed under the MIT License.

See [LICENSE](LICENSE) for details.
