# Alkomentor

- Создание миграции: `dotnet ef database update -s .\Alkomentor.Api\ -p .\Alkomentor.Infrastructure\ --context PostgresDbContext`
- Применение миграции: `dotnet ef migrations add InitMigration -s .\Alkomentor.Api\ -p .\Alkomentor.Infrastructure\ --context PostgresDbContext