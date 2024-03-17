# User Management Application

Welcome to the User Management Application! The application is an ASP.NET Core web application backed by Entity Framework Core, which faciliates management of some fictional users.
This application allows you to manage users, including Viewing, Editing, Adding, and Deleting users.

## Project Structure

The project is structured into three main folders:

1. **UM.Data**: This folder contains the data access layer, including database context and entity classes.
    - **Attributes**: Custom validation attributes.
    - **Entities**: Entity classes representing database tables.
    - **Extensions**: Extension methods.
    - **DataContext.cs**: Database context class.
    - **IDataContext.cs**: Interface for the database context.

2. **UM.Services**: This folder contains the service layer, including service interfaces and implementations.
    - **Dependencies**: Dependency injection related files.
    - **Extensions**: Extension methods.
    - **Implementations**: Service implementations.
    - **Interfaces**: Service interfaces.
    - **ServiceCollectionExtensions.cs**: Dependency injection extension methods.

3. **UM.Web**: This folder contains the web application, including controllers, models, and views.
    - **Connected Services**: External service configurations.
    - **Dependencies**: Dependency injection related files.
    - **Properties**: Project properties.
    - **wwwroot**: Static web assets (CSS, JavaScript, etc.).
    - **Controllers**: MVC controllers.
    - **Models**: View models.
    - **Views**: Razor views.

## Getting Started

To run the application, follow these steps:

1. Clone the repository to your local machine.
2. Open the solution file (`UserManagement.sln`) in Visual Studio or your preferred IDE.
3. Build the solution to restore packages and compile the code.
4. Set up the database connection in `appsettings.json` if needed.
5. Run the application using the built-in debugger or by pressing `F5`.
6. Access the application in your web browser at the specified URL.

## Features

### 1. Filters Section

The users page contains 3 buttons below the user listing - **Show All**, **Active Only** and **Non Active**.
* Show All - This shows all users irrespective of their `IsActive` property status
* Active Only – This shows only users where their `IsActive` property is set to `true`
* Non Active – This shows only users where their `IsActive` property is set to `false`

### 2. User Model Properties

Added a new property to the `User` class in the system called `DateOfBirth` which is used and displayed in relevant sections of the app.

### 3. Actions Section

Created the code and UI flows for the following actions
* **Add** – A screen that allows you to create a new user and return to the list
* **View** - A screen that displays the information about a user
* **Edit** – A screen that allows you to edit a selected user from the list  
* **Delete** – A screen that allows you to delete a selected user from the list

Each of these screens should contain appropriate data validation, which is communicated to the end user.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, please submit a pull request or open an issue on GitHub.
