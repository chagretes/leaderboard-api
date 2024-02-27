Create a database postgres and set the user in `appsettings.json`
To run the migrations and create the table execute:
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate                 
```
