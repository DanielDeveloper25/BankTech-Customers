# Microservicio de Customers

Este microservicio de customers es parte de una aplicación bancaria desarrollada en .NET 8.

## Requisitos

- SQL Server instalado
- .NET Core SDK 8 o superior

## Configuración

1. Clona este repositorio en tu máquina local:

    ```bash
    git clone https://github.com/DanielDeveloper25/BankTech-Customers.git
    ```

2. Abre el proyecto en tu entorno de desarrollo preferido.

3. Agrega el Connection String a tu configuración. Puedes utilizar el secret proporcionado para el entorno de desarrollo. Asegúrate de tener el .NET CLI instalado.

    ```bash
    dotnet user-secrets set ConnectionStrings:DefaultConnection "Server=SMELTER-LE-NOVO;Database=BankTech-Customers;Trusted_Connection=true;MultipleActiveResultSets=True;TrustServerCertificate=True"
    ```

4. Ejecuta el siguiente comando en la consola de Package Manager para aplicar las migraciones y crear la base de datos:

    ```bash
    update-database
    ```

## Ejecución

1. Compila y ejecuta el microservicio:

    ```bash
    dotnet build
    dotnet run
    ```

El microservicio estará disponible en [http://localhost:5163](http://localhost:5163).