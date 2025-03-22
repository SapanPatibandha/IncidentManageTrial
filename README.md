# Incident Management System

This project is an Incident Management System built using ASP.NET Core 9 with minimal APIs and clean architecture principles. It provides a structured approach to managing incidents, allowing users to create, update, retrieve, and delete incident records.

## Project Structure

The project is organized into several layers, adhering to clean architecture principles:

- **IncidentManagement.Api**: Contains the API controllers and the entry point of the application.
- **IncidentManagement.Application**: Contains the business logic and service interfaces.
- **IncidentManagement.Domain**: Contains the domain entities and repository interfaces.
- **IncidentManagement.Infrastructure**: Contains the data access layer, including the database context and repository implementations.
- **tests**: Contains unit and integration tests for the application.

## Getting Started

### Prerequisites

- .NET 9 SDK
- A suitable database (e.g., SQL Server, SQLite)

### Setup

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```
   cd IncidentManagement
   ```

3. Restore the dependencies:
   ```
   dotnet restore
   ```

4. Update the `appsettings.json` file in the `IncidentManagement.Api` project with your database connection string.

5. Run the application:
   ```
   dotnet run --project src/IncidentManagement.Api
   ```

### API Endpoints

The following endpoints are available for managing incidents:

- `GET /api/incidents/{id}`: Retrieve an incident by ID.
- `POST /api/incidents`: Create a new incident.
- `PUT /api/incidents/{id}`: Update an existing incident.
- `DELETE /api/incidents/{id}`: Delete an incident.

## Testing

To run the unit and integration tests, use the following command:

```
dotnet test
```

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for more details.