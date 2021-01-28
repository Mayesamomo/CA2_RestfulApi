
asp.netcore 3.1 restful api with swaggerUI 
# Anime DB CRUD API
`RESTful API built with ASP.NET Core 3.1 to show how to create RESTful services using a decoupled and maintainable architecture.`

# Added Swagger documentation through Swashbuckle;
- Changed animes listing to allow filtering by category ID, to show how to perform specific queries with EF Core;
- Changed ModelState validation to use ApiController attribute and InvalidResponseFactory in Startup.
- Frameworks and Libraries
- ASP.NET Core 3.1;
- Entity Framework Core (for data access);
- SQL EXPRESS server;
- AutoMapper (for mapping resources and models);
- Swashbuckle (Swagger UI API documentation).
- Download and install sqlexpress 2018 `https://www.microsoft.com/en-us/download/details.aspx?id=101064`
# How Run
- First,clone or download the repo open it with Visual studio/Code

- Navigate to https://localhost:5001/api/ to check if the API is working. If you see a HTTPS security error, just add an exception to see the results. Navigate to Properties folder and change launchSettings.json

  `` "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "launchUrl": "swagger", //change the api launch url to swagger UI
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    },
    "CrudAPI": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "https://localhost:5001;http://localhost:5000",
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    } ``
