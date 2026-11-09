# TableFlow

**TableFlow** is a full-stack reservation management platform for restaurants, bars, and nightclubs.

The goal is to make table reservations easier for customers while giving venues a centralized system to manage availability, seating arrangements, bookings, and guests.

> **Project Status:** Foundation setup (TF-001). The ASP.NET Core 10 backend and React + TypeScript frontend are initialized and can run independently. Business functionality is planned but has not yet been implemented.

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

These features are planned for future development milestones.

## Technology Stack

| Layer | Technology |
|---|---|
| Frontend | React, TypeScript, Vite |
| Backend | C#, ASP.NET Core 10 Web API |
| Architecture | Clean Architecture-inspired layered architecture |
| Database (planned) | PostgreSQL |
| ORM (planned) | Entity Framework Core |
| Authentication (planned) | ASP.NET Core Identity |
| Real-time (planned) | SignalR |
| Version Control | Git & GitHub |
| Testing (planned) | xUnit, frontend tests |

## Project Architecture

TableFlow uses a **modular monolith architecture** with separate backend projects for different responsibilities.

### Backend Projects

**TableFlow.Api**

The entry point of the backend application.

Responsibilities:
- Handle HTTP requests and responses.
- Define API controllers and endpoints.
- Configure middleware and dependency injection.
- Expose application functionality to the frontend.

**TableFlow.Application**

Coordinates application use cases and business workflows.

Responsibilities:
- Implement application services and use cases.
- Define interfaces for external dependencies.
- Coordinate domain logic and persistence operations.
- Handle application-level validation and DTOs.

**TableFlow.Domain**

Contains the core business concepts and rules.

Responsibilities:
- Define domain entities and value objects.
- Enforce business rules and invariants.
- Represent reservations, venues, and tables.
- Remain independent of database and web technologies.

**TableFlow.Infrastructure**

Implements technical dependencies and integrations.

Responsibilities:
- Handle database persistence using EF Core.
- Implement interfaces defined in the application layer.
- Configure database access and repositories when needed.
- Integrate external services such as email and payments.

### Dependency Structure

The backend follows these project references:

| Project | References |
|---|---|
| TableFlow.Api | Application, Infrastructure |
| TableFlow.Application | Domain |
| TableFlow.Infrastructure | Application, Domain |
| TableFlow.Domain | None |

The Domain project is independent of the other projects.

This separation helps keep business logic testable and prevents core domain rules from depending directly on database frameworks or HTTP infrastructure.

## Repository Structure

```text
TableFlow/
├── backend/
│   ├── TableFlow.sln
│   │
│   ├── TableFlow.Api/
│   │   ├── Controllers/
│   │   ├── Properties/
│   │   ├── Program.cs
│   │   ├── appsettings.json
│   │   └── TableFlow.Api.csproj
│   │
│   ├── TableFlow.Application/
│   │   └── TableFlow.Application.csproj
│   │
│   ├── TableFlow.Domain/
│   │   └── TableFlow.Domain.csproj
│   │
│   └── TableFlow.Infrastructure/
│       └── TableFlow.Infrastructure.csproj
│
├── frontend/
│   ├── public/
│   ├── src/
│   ├── package.json
│   ├── package-lock.json
│   ├── tsconfig.json
│   └── vite.config.ts
│
├── .gitignore
├── LICENSE
└── README.md
```

This structure shows the main project files. Generated and supporting files are omitted.

## Getting Started

### Prerequisites

Make sure the following tools are installed:

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) (a version compatible with the installed Vite release) and npm
- [Git](https://git-scm.com/)
- Visual Studio or Visual Studio Code

PostgreSQL is not required yet because database persistence has not been implemented.

### 1. Clone the Repository

```bash
git clone https://github.com/Lukanoid/TableFlow.git
cd TableFlow
```

### 2. Run the Backend

From the repository root:

```bash
dotnet restore backend/TableFlow.sln
dotnet run --project backend/TableFlow.Api --launch-profile https
```

Alternatively, open `backend/TableFlow.sln` in a compatible version of Visual Studio and run the API.

With the current development launch settings, the backend uses:

```text
https://localhost:7295
```

A sample endpoint from the ASP.NET Core template is available at:

```text
https://localhost:7295/weatherforecast
```

The endpoint is provided by the initial ASP.NET Core template and will be replaced by TableFlow-specific endpoints in future tickets.

### 3. Run the Frontend

Open another terminal and navigate to the frontend directory:

```bash
cd frontend
npm ci
npm run dev
```

Vite will display the local development URL, usually:

```text
http://localhost:5173
```

The frontend currently displays the starter application. The actual TableFlow interface will be implemented in upcoming milestones.

### 4. Build the Backend

From the repository root:

```bash
dotnet build backend/TableFlow.sln
```

All four backend projects should compile successfully.

### 5. Build the Frontend

From the frontend directory:

```bash
npm run build
```

This runs TypeScript compilation and creates a production build using Vite.

The generated output is placed in the `frontend/dist/` directory, which is excluded from version control.

## Development Guidelines

- Keep the Domain layer independent of infrastructure and presentation concerns.
- Follow the established project-reference architecture.
- Implement new features through focused development tickets.
- Use meaningful Git commit messages.
- Avoid committing secrets, credentials, or environment-specific configuration.
- Do not commit `node_modules/`, `dist/`, or .NET `bin/` and `obj/` directories.
- Introduce new technologies only when required by the application.
- Add appropriate automated tests as business features are developed.
- Keep documentation updated as the project evolves.

## Development Roadmap

### Milestone 1 — Foundation

- [x] Initialize Git repository.
- [x] Configure `.gitignore`.
- [x] Create ASP.NET Core 10 solution.
- [x] Create API, Application, Domain, and Infrastructure projects.
- [x] Configure project references.
- [x] Initialize React + TypeScript frontend.
- [x] Verify backend build.
- [x] Verify frontend production build.
- [x] Document the initial development environment.

### Milestone 2 — Core Domain and Persistence

- [ ] Design venue and table domain entities.
- [ ] Configure PostgreSQL.
- [ ] Introduce Entity Framework Core.
- [ ] Create initial database migrations.
- [ ] Implement venue management functionality.

### Milestone 3 — Reservation Engine

- [ ] Implement reservation creation.
- [ ] Implement table availability checks.
- [ ] Prevent overlapping reservations.
- [ ] Support cancellation and reservation statuses.
- [ ] Add concurrency and integration tests.

### Milestone 4 — Interactive Floor Plans

- [ ] Implement seating zones and visual table layouts.
- [ ] Add a floor-plan management interface.
- [ ] Allow customers to select eligible tables.
- [ ] Connect floor-plan availability to reservation data.

### Milestone 5 — Restaurant and Nightclub Features

- [ ] Support restaurant time-based reservations.
- [ ] Support nightclub event reservations.
- [ ] Introduce VIP table booking rules.
- [ ] Build venue reservation management dashboards.

### Milestone 6 — Production Readiness

- [ ] Introduce real-time updates.
- [ ] Implement authentication and authorization.
- [ ] Add automated tests and CI/CD.
- [ ] Improve security and error handling.
- [ ] Deploy a working demonstration.

The roadmap is subject to refinement as development progresses.

## Project Purpose

TableFlow is being developed as a flagship full-stack portfolio project with the long-term possibility of becoming a commercial SaaS platform for hospitality venues.

The project emphasizes:

- Practical full-stack software engineering.
- Clean architectural boundaries.
- Strong TypeScript and C# fundamentals.
- Relational database modeling.
- Reliable, concurrency-safe booking logic.
- Automated testing and maintainable code.
- Incremental delivery through real-world development practices.

Development follows a ticket-based workflow with independent implementation, code reviews, and continuous improvement.

## License

This project is licensed under the MIT License. See [LICENSE](LICENSE) for details.
