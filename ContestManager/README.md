Contest Management 

A RESTful Web API built with ASP.NET Core 8 and Entity Framework Core for managing contests, processing complex scoring rules, and tracking user leaderboards.

Overview
- **Role-Based Access Control:** Distinct permissions for Admin, VIP, Normal, and Guest users using JWT Authentication.
- **Dynamic Scoring Engine:** Automatically calculates scores based on Single-select, Multi-select (exact match required), and True/False question types.
- **Leaderboard Generation:** Ranks users within a contest based on their submitted scores.
- **User History Tracking:** Retrieves completed contests (with mock prizes) and in-progress contests.
- **Security & Optimization:** Includes Global Error Handling and Rate Limiting (100 requests/minute).

---

SDK Version
- [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- SQL Server (LocalDB is configured by default)
- Visual Studio 2022 (Recommended) or VS Code
- Postman (for testing the API Collection)


The project is configured to use SQL Server LocalDB. If you are using a different SQL instance, update the `DefaultConnection` string in `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ContestDb;Trusted_Connection=True;"
}