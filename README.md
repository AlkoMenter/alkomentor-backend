# Alkomentor

- Create migration: `dotnet ef migrations add InitMigration -s .\Alkomentor.Api\ -p .\Alkomentor.Infrastructure\ --context PostgresDbContext`
- Apply migration: `dotnet ef database update -s .\Alkomentor.Api\ -p .\Alkomentor.Infrastructure\ --context PostgresDbContext`
