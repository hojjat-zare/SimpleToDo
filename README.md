# SimpleToDo ASP.NET Core with Clean Architecture and CQRS

## Introduction

This project is a simple web application built with ASP.NET Core, designed to demonstrate the implementation of Clean Architecture principles and the CQRS (Command Query Responsibility Segregation) pattern. The application enables users to manage ToDo items through basic CRUD (Create, Read, Update, Delete) operations. It is structured to promote separation of concerns, maintainability, and testability, making it an ideal example for learning modern software architecture practices in .NET.

## Configuring Database in appsettings
By default, the application is configured to use a InMemory database for development purposes. However, it can be easily switched to use a SQL Server database by modifying `appsettings.Development.json` file and removing below part:

```json
  "UseOnlyInMemoryDatabase": true,
```
This allows for persistent data storage and is suitable for production environments.

To set up SQL Server database for the application, follow these steps:

1. **Locate the Configuration File**

   - Open the `appsettings.json` file located in the `PublicApi` project directory.

2. **Update the Connection String**

   - Find the `ConnectionStrings` section and modify the `ToDoContext` string to match your database server details. Below is an example for a local SQL Server instance:

     ```json
     "ConnectionStrings": {
      "ToDoContext": "Server=.;Integrated Security=true;Initial Catalog=SimpleToDoDB;TrustServerCertificate=True;"
      }
     ```

   - Replace `.` with your SQL Server instance name and `TodoDb` with your preferred database name.

3. **Apply Database Migrations**

   - Ensure you have the .NET Core SDK installed on your machine.

   - Install the Entity Framework Core tools globally by running:

     ```
     dotnet tool install --global dotnet-ef
     ```

   - Open a terminal in the `Infrastructure` project directory.

   - Execute the following command to apply migrations and create the database:

     ```
     dotnet ef --startup-project ../PublicApi/ database update --context ToDoContext
     ```

   - This command uses the migrations defined in the `Infrastructure` project and the configuration from the `PublicApi` project to set up the database.

## Building and Running the Application

Follow these steps to build and run the application locally:

1. **Prerequisites**

   - Ensure you have the .NET Core SDK 8.0 or later installed. You can download it from the official .NET website.

2. **Build the Solution**

   - Open a terminal in the `PublicApi` project directory.

   - Run the following command to compile the project:

     ```
     dotnet build
     ```

   - This ensures all dependencies are resolved and the code is compiled successfully.

3. **Run the Application**

   - Start the application by running:

     ```
     dotnet run
     ```

   
## Additional Information

- The application uses Entity Framework Core for data access and assumes a SQL Server database. To use a different database provider, update the EF Core configuration in the `Infrastructure` project accordingly.
- For further exploration, the solution includes unit tests in the `Tests` project, which can be executed with `dotnet test` from the test project directory.
- Optionally, you can deploy the application to a cloud platform like Azure by following standard .NET deployment practices.

This README provides the essential steps to get the TodoApp up and running. For more details on the project structure, refer to the source code and accompanying comments.