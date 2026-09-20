#  Expense Tracker API

A robust, secure, and fully containerized RESTful API for tracking personal expenses and categories. Built with .NET 10 and PostgreSQL. This project implements Clean Architecture, JWT Authentication, and global exception handling.

##  Features

* **JWT Authentication:** Secure user Registration and Login flow using JSON Web Tokens.
* **Password Hashing:** Passwords are securely hashed using ASP.NET Core Identity's `PasswordHasher<T>`.
* **CRUD Operations:** Full Create, Read, Update, and Delete functionality for Expenses and Categories.
* **Data Security (Ownership):** Users can only view, edit, or delete their own expenses and categories. Data is isolated by `UserId`.
* **Global Exception Handling:** Centralized middleware for consistent and clean API error responses (404, 400, 500).
* **Swagger UI:** Interactive API documentation with JWT Authorization support.
* **Dockerized Environment:** Both the PostgreSQL database and the .NET API are containerized using Docker Compose for seamless setup.

##  Tech Stack

* **Framework:** .NET 10, ASP.NET Core Web API
* **Database:** PostgreSQL
* **ORM:** Entity Framework Core
* **Authentication:** JWT Bearer Tokens
* **Documentation:** Swashbuckle (Swagger)
* **Containerization:** Docker, Docker Compose

##  Project Architecture

The project follows a Clean Architecture approach with a strict separation of concerns:
* **Controllers:** Handle HTTP requests and responses. Kept thin.
* **Services:** Contain core business logic and data validation.
* **DTOs:** Data Transfer Objects for request/response models to prevent over-posting.
* **Middleware:** Global exception handling.
* **Data:** Entity Framework Core `DbContext` and configurations.

##  Getting Started

### Prerequisites
Make sure you have the following installed on your machine:
* [.NET 10 SDK](https://dotnet.microsoft.com/download)
* [Docker Desktop](https://www.docker.com/products/docker-desktop)

### Installation & Running

1. **Clone the repository:**
   ```bash
   git clone https://github.com/your-username/ExpenceTracker.git
   cd ExpenceTracker
   ```

2. **Start the application and database using Docker Compose:**
   This command will build the API image and start both the PostgreSQL database and the API in containers.
   ```bash
   docker compose up --build
   ```

3. **Apply database migrations:**
   Open a new terminal window in the project directory and run the following command to create the database schema:
   ```bash
   dotnet ef database update
   ```
   *(Note: Ensure your `appsettings.json` has the correct connection string pointing to `localhost:5432` for local EF Core commands).*

4. **Access the API:**
   Open your browser and navigate to:
   ```
   http://localhost:8080/swagger
   ```

##  Usage Guide (Testing in Swagger)

1. **Register a User:**
   * Go to `POST /api/Auth/Register`.
   * Provide a `Name`, `Email`, and `Password`. Click Execute.
   * Copy the `token` string from the response body.

2. **Authorize:**
   * Click the **Authorize**  button at the top right of the Swagger UI.
   * Paste the copied token into the input box and click Authorize.

3. **Create a Category:**
   * Go to `POST /api/Category`.
   * Create a category (e.g., "Food", "Transport"). Note the `Id` from the response.

4. **Track an Expense:**
   * Go to `POST /api/Expence`.
   * Provide the expense details, including the `CategoryId` you just created.



