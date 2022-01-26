# Challenge
CRUD WebAPI with .NET 6, SQL Server && Entity Framework Core 6.

//Patterns and Libraries used:
- Repository Pattern;
- Dependency Injection;
- Data Transfer Objects (DTO);
- AutoMapper;

//Endpoints
[HttpPost]
Creates an item

[HttpGet("{brand}")]
Returns all the items of that brand

[HttpGet("GetAll")]
Returns all the items

[HttpPut]
Updates an item

[HttpDelete("{id}")]
Deletes the item with the specific id

//Entity Framework Core 6
To add a Migration run the following command on .NET CLI:
dotnet ef migrations add <message>

To update database run the following command on .NET CLI:
dotnet ef database update

//Search Material:
https://www.learmoreseekmore.com/2021/12/dotnet6-web-api-crud-operation-with-entity-frameworkcore.html
https://docs.automapper.org/en/latest/Getting-started.html
https://docs.microsoft.com/en-us/ef/core/what-is-new/ef-core-6.0/whatsnew
https://docs.microsoft.com/en-us/dotnet/api/system.stringcomparer.invariantcultureignorecase?view=net-6.0
