#Entity Framework Demo (efdemo)
There is a small project using EF and basic CRUD APIs.

#### Swagger
* Swagger documentation is set up and could be accessed using url `https://localhost:5001/swagger/index.html`

#### .NET 8 build-in Auth
*** Note that API has been upgraded to .NET 8 first ***
* This is an out-of-the-box setup for .NET 8 Auth whish has become very handly. The Postman collection is stored in a /Postman folder. 
Setup is quite easy and you would need to use `IdentityDbContext` with `IdentityUser`
![AspNetUsers-table](Img/AspNetUsers-table.jpg)

#### Testcontainers Note
*** This is wip ***
* todo: `RepositoryTests` needs to be fixed due to the Auth change.

If tests are not running with exception about Docker unauthorised login password,
try to run the command:
```
docker login index.docker.io
```
