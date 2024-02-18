# BookAPI

### Hope to Practice
- .Net 8 Web API
- Entity Framework Core
- Repository Pattern, UnitOfWork Pattern
- Unit Test
- Integrate Swagger
- Well-Organized File Structure


### EF CORE Migrations
``` shell
# Create a new migration record
dotnet ef migrations add [ RECORD_NAME ] -p .\Book.Dao\ -s .\Book.Api\  

# Update the database
dotnet ef database update -p .\Book.Dao\ -s .\Book.Api\
```
