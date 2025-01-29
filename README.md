The Products Application consists of a .NET API (Products.sln) and the frontend React application (products-client).

**Below are the steps for launching the React frontend**
- Install NPM packages:  run the command - >  npm install
- To run the application: run the command -> npm run dev 
- To get to the application, navigate to -  http://localhost:5173/
  

**Below are the steps to run the API**
- Open the Products.sln file in Visual Studio
- Restore NuGet packages - Right click on the solution -> Restore NuGet Packages
- Rebuild the solution -  Right click on the solution -> Rebuild Solution
- Run the application with "https" option, this should open the Swagger page for the API - (https://localhost:7048/swagger/index.html)
  

**Below are the API end points that can be viewed/tested from Swagger **
- GET (Gets all products) -> /api/Products
- GET (Gets a product by Id) -> /api/Products/{id}
- POST (Creates a new product) -> /api/Products
  

**Additional Details:**
- AG-Grid and AG-Charts components are used for the table and charts in the React application.
- Axios is used for making the API calls from the frontend.
- Sql Server database - Database.mdf is used for data storage. It is present in the folder Products.API/App_Data
- AutoMapper is used for mapping the Dtos and entity.
- FluentValidation is used to put together all validations for Products.

**Solution Structure**
- Products.API -> Startup API project with Controllers and Middleware.
- Products.Application -> Application layer with ProductService implementation and validator.
- Products.Domain -> Domain layer with the Entities, Repositories (interfaces) and Exceptions.
- Products.Infrastructure -> Data layer with repository implementation that interacts with the database using EntityFramework.
- Products.Tests -> Integration tests to test the API functionality.
- products-client -> The React frontend application
  
  
PS: The solution is setup to be containerized using Docker. However, I am having issues with Docker setup on my personal computer. Hence the docker build (optional task) could not be done.



