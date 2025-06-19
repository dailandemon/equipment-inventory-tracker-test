# Equipment Inventory Tracker API

A simple full-stack-ready REST API built with ASP.NET Core and MySQL for managing equipment, including categories, status, and serial numbers. Built as part of a full stack portfolio, it is decently barebones, good to work on top of and to keep templates for good practices.

## 🚀 Features

- 🔐 JWT authentication
- 🔑 Google account login via OAuth 2.0
- 📦 CRUD operations for equipment and categories
- 🗂 Filter equipment by category
- 🌐 Swagger UI for API testing
- 🐘 MySQL + Entity Framework Core for persistence
- 🧱 DTOs and clean architecture

## ⚙️ Technologies Used

- ASP.NET Core 9
- Entity Framework Core
- MySQL + Pomelo Connector
- JWT Bearer Authentication
- Google OAuth 2.0
- Swagger / OpenAPI

## 🧪 How to Run

1. Clone the repo:
   ```bash
   git clone https://github.com/your-username/equipment-inventory-tracker.git
   cd equipment-inventory-tracker
   
2.Set up your database connection in appsettings.json
Open the appsettings.json file and update the connection string to match your local MySQL instance:
```
"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=equipment_db;user=root;password=yourpassword"
}
```

3.Run database migrations (optional)
If you haven't already created the database tables via EF Core, run:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```
4. Run the project
Start the ASP.NET Core API:
```
dotnet run
```
6. Test the API via Swagger UI
Once running, open your browser and go to:
https://localhost:[yourport]/swagger


🔐 Authentication
JWT Auth
You can log in using a local username/password and receive a JWT token for protected routes.

Google Auth
Authenticate via your Google Account at:
GET /api/auth/google/login

You'll be redirected and issued a token once authenticated.
