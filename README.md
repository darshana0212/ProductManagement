## Product Management Api

This Api provides the ability to manage various Products along with their Options.

It exposes various end points to Create, View, Update and Delete, Products and Product Options.

## Tech Stack
* Visual Studio 2019
* ASP.Net Core 3.1 - WebApi
* Database Sql Server
* Unit Tests using - Moqs and xUnit Fact 
* SeriLog for Logging
* Swagger for Api Specification
* GitHub for Version Control

## Solution Structure 

The solution is broken down into the following projects. Each project has its own responsibility.

* ProductManagement.Api - This is the host project which is responsible for host files, and set up including startup files, swagger specification, app settings, controllers etc..

* ProductManagement.Service - This is the service project which communicates with the Controllers in the Api project. There are two services in this project ProductCommandService (for adding and updating the data) and ProductQueryService (for reading the data). 

* ProductManagement.Data - This project contains the database connections, EF Migrations to maintain the database and repositories to access the data. The service project calls various CRUD operations in the repository to read/update/delete products and product options.

* ProductManagement.Api.Tests - This is the unit test project which contains unit tests. Unit tests are written for positive scenarios as well as negative scenarios.

## Steps To Run

#Prerequisites -
* Requires .Net Core and Sql Server to be installed on the machine

Once done

* Clone the repository
* Install the application dependencies from [nuget.org](https://www.nuget.org/)
* Run the ProductManagement.Api project
* Test the application from the Swagger dashboard

## In Development 
Docker Support for Containerization

# Implementation Spec

* Swagger Specification
![alt text](https://github.com/darshana0212/ProductManagement/blob/master/Swagger%20Specification.png)

