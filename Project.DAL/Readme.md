# Docker Setup MS SQL
[Microsoft SQL Server Docker](https://hub.docker.com/_/microsoft-mssql-server)
# Setup Migrations 
```
dotnet ef --startup-project Assignment2/Assignment2.csproj migrations add InitialModel -p Project.DAL/Project.DAL.csproj --context AppDbContext
```
# Update Database
```
dotnet ef --startup-project Assignment2/Assignment2.csproj  database update
```
# ! Update `appsettings.json` > `ConnectionString`!