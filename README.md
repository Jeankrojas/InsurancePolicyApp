# InsurancePolicyApp
1. Debe tener acceso a un motor de SQLServer
2. dotnet Core version 2.2.401
3. node version 8.11.2
4. Angular CLI version 6.0.8
5. Configurar con sus datos(Servidor de base de datos) el connectionstring 
   que se encuentra en el archivo InsurancePolicyApp.API/appsettings.json
6. En la consola posicionarse en el folder InsurancePolicyApp/InsurancePolicyApp.API
   y ejecutar el comando 'dotnet ef database update' para ejecutar los migrations
8. En la consola posicionarse en el folder InsurancePolicyApp/InsurancePolicyApp-SPA 
   y ejecurtar el comando 'npm install'

**EN ESTE PUNTO DEBE ESTAR LISTO PARA CORRER LA APLICACIÓN**

9. En consola posicionarse en el folder InsurancePolicyApp/InsurancePolicyApp.API
   y ejecutar el comando 'dotnet run'
10. Cuando haya corrido el API por primera vez por favor abrir el archivo Startup.cs y comente las lineas de la 83 a la 87
            seeder.SeedUsers();
            seeder.SeedRiskTypes();
            seeder.SeedEventTypes();
            seeder.SeedPolicies();
            seeder.SeedClients();
    esto evitará que se siga cargando datos de prueba a la DB.
11. En consola posicionarse en el folder InsurancePolicyApp/InsurancePolicyApp-SPA 
   y ejecutar el comando 'ng serve' para iniciar el cliente.
12. En el navegador vaya a http://localhost:4200
13. Inicie sesión con el usuario "admin" y constraseña "password" o cree su propio usuario en la opción "Register"
14. Para realizar pruebas del API (http://localhost:5000/api/) utilice una herramienta como Postman
15. Tomar en cuenta que se utiliza autenticación por token por lo que 
    deberá generar primero su token en la siguiente ruta http://localhost:5000/api/auth/login (desde postman)
16. Esto le devolverá un token que deberá copiar en los headers de la siguiente manera
    KEY: *Authorization*
    VALUE: *Bearer TokenGenerado* (debe dejar un espacio entre la palabra Bearer y su token)
