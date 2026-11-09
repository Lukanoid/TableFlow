
# TableFlow

**TableFlow** is a full-stack reservation management platform for restaurants, bars, and nightclubs. The goal is to make it easier for guests to find and reserve tables while giving venues a clear way to manage availability, floor plans, and bookings.

> **Project status:** Initial setup (TF-001). The ASP.NET Core API and React frontend are scaffolded and run locally. The reservation features described below are planned, not implemented yet.

## Planned features

- **Guest reservations:** Find a venue, choose a date and time, enter party size, and request an available table.
- **Interactive floor plans:** View table locations and select from available seating.
- **Venue dashboard:** Manage tables, reservations, blocked time slots, and manual adjustments.
- **Conflict-safe bookings:** Prevent overlapping reservations for the same table and time slot.
- **Authentication and authorization:** Separate guest and venue-management permissions.

## Tech stack

| Layer | Technology |
| --- | --- |
| Frontend | React, TypeScript, Vite |
| Backend | C#, ASP.NET Core 10 Web API |
| Database (planned) | PostgreSQL |
| Data access (planned) | Entity Framework Core |
| Version control | Git and GitHub |

## Repository structure

```text
TableFlow/
├── backend/
│   ├── TableFlow.sln
│   └── TableFlow.Api/
│       ├── Controllers/
│       ├── Properties/
│       ├── Program.cs
│       ├── appsettings.json
│       └── TableFlow.Api.csproj
├── frontend/
│   ├── public/
│   ├── src/
│   ├── package.json
│   ├── tsconfig.json
│   └── vite.config.ts
├── .gitignore
└── README.md
```

This is a simplified overview; generated and supporting files are omitted.

## Getting started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Node.js](https://nodejs.org/) and npm
- Git

PostgreSQL will be needed when persistence is introduced; it is **not required** to run the current starter applications.

### 1. Clone the repository

```bash
git clone https://github.com/Lukanoid/TableFlow.git
cd TableFlow
```

### 2. Run the backend

From the repository root:

```bash
dotnet restore backend/TableFlow.sln
dotnet run --project backend/TableFlow.Api --launch-profile https
```

Visual Studio users can also open `backend/TableFlow.sln` and press **F5**.

The application prints its local URLs in the terminal. With the current development configuration, the sample endpoint has been available at:

```text
https://localhost:7295/weatherforecast
```

The port can vary by machine or launch profile. The `/weatherforecast` route is a template-generated test endpoint and will be removed as TableFlow's real API is developed. If prompted to trust a local HTTPS development certificate, only approve it if you initiated the development server yourself.

### 3. Run the frontend

Open a second terminal and, from the repository root, run:

```bash
cd frontend
npm install
npm run dev
```

Open the local URL printed by Vite (typically `http://localhost:5173`).

### 4. Verify the builds

From the repository root, build the backend:

```bash
dotnet build backend/TableFlow.sln
```

Then build the frontend:

```bash
cd frontend
npm run build
```

## Development notes

- The backend and frontend are currently **independent starter applications**; API integration is a future task.
- Do not commit credentials, API keys, local `.env` files, `node_modules/`, `dist/`, or .NET `bin/` and `obj/` folders.
- Keep configuration specific to your machine outside version control. Safe example configuration can be documented as it becomes necessary.

## Roadmap

- [x] Initialize repository and `.gitignore`
- [x] Create and run ASP.NET Core API
- [x] Create and build React + TypeScript frontend
- [ ] Define domain entities and database schema
- [ ] Set up PostgreSQL and Entity Framework Core
- [ ] Add authentication and role-based authorization
- [ ] Implement venue and table management
- [ ] Implement reservation availability and booking rules
- [ ] Add interactive floor-plan management
- [ ] Connect frontend to backend API
- [ ] Add automated tests and deployment workflows

## Purpose

TableFlow is being built as a portfolio and learning project with a focus on full-stack architecture, practical API design, TypeScript, relational data modeling, and concurrency-safe reservation workflows.
