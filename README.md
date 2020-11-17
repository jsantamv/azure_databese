# Azure Database
Como utilizar y crear una cuenta de bases de datos y con implementacion de API en C#

## Librerias Requeridas

1. Microsoft.EntityFrameworkCore.Design
2. Microsoft.EntityFrameworkCore
3. Microsoft.EntityFrameworkCore.SqlServer

## Comandos para EntityFramework
```b
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.0
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Para publicar o generar los binarios

```b
dotnet publish -c Release -o ./publish
````


Para consumir nuestra api podemos utilizar Insomnia o Postman.

[Comandos](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations?view=aspnetcore-5.0)

