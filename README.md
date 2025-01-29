The Products.sln has the .NET API for creating and viewing products. The product-client is the React application for the same.


React Application (products-client folder): 

Install NPM packages:  run - >  npm install
Run the application: -> npm run dev 
To get to the application, navigate to -  http://localhost:5173/ 

API:

Open the Products.sln file in Visual Studio
Restore NuGet packages - Right click on the solution -> Restore NuGet Packages
Rebuild the solution ->  Right click on the solution -> Rebuild Solution
Run the application with "https" option, this should open the Swagger page for the API - (https://localhost:7048/swagger/index.html)

The API end points can be viewed/tested from Swagger : 

GET (Gets all products)
/api/Products

POST (Creates a new product)
/api/Products

GET (Creates a product by Id)
/api/Products/{id}


Additional Details:

AG-Grid and AG-Charts components are used for the table and charts in the React application.
Axios is used for making the API calls from the react application.
Sql Server database - Database.mdf is used for data storage . Its present in the folder Products.API/App_Data
AutoMapper is used for mapping the Dtos and entity.
FluentValidation is used to put together all validations.

PS: The solution is setup to be containerized using Docker. However, I am having technical difficulty with setting up and getting Docker to run on my personal computer. Hence the docker build could not be done.



