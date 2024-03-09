# Microservicio de Customers

Este microservicio de customers es parte de una aplicaci�n bancaria desarrollada en .NET 8.

## Requisitos

- SQL Server instalado
- .NET Core SDK 8 o superior

## Configuraci�n

1. Clona este repositorio en tu m�quina local:

    ```bash
    git clone https://github.com/DanielDeveloper25/BankTech-Customers.git
    ```

2. Abre el proyecto en tu entorno de desarrollo preferido.

3. Agrega el Connection String a tu configuraci�n. Puedes utilizar el secret proporcionado para el entorno de desarrollo. Aseg�rate de tener el .NET CLI instalado.

    ```bash
    dotnet user-secrets set ConnectionStrings:DefaultConnection "Server=Nombre-de-tu-servidor;Database=BankTech-Customers;Trusted_Connection=true;MultipleActiveResultSets=True;TrustServerCertificate=True"
    ```

4. Ejecuta el siguiente comando en la consola de Package Manager para aplicar las migraciones y crear la base de datos:

    ```bash
    dotnet ef database update --project .\Customers.Infrastructure\Customers.Infrastructure.csproj
    ```

## Ejecuci�n

1. Compila y ejecuta el microservicio:

    ```bash
    dotnet run --project .\Customers.API\Customers.API.csproj
    ```

El microservicio estar� disponible en [http://localhost:5163](http://localhost:5163).

2. Accede a la documentaci�n de la API utilizando Swagger:

    [http://localhost:5163/swagger](http://localhost:5163/swagger)