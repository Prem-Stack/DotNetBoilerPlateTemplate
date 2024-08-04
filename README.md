# Project Name
	Template.Net6	
#### By _**LogicValley Technologies Private Limited**_

# Introduction 
.NET 6.0 Web API Boilerplate is a starting point for our next .NET 6 Clean Architecture Project that incorporates the most essential packages and features our projects.

## Prerequisites
Visual Studio 2022 Community or Visual Code
.Net 6.0 SDK
Basic Understanding of Architectures and Clean Code Principles

	
# Requirements
This module requires the following modules:
1. .Net 6.0
2. CQRS
3. MediatR
4. SeriLog
5. Middelwares
6. Swagger
7. Repository
8. Unit Of Works
9. Azure App Configuration with KeyVault
10. Service Bus


## Usage
#### `BoilerTemplate`

## Folder Structure
This Project contains 4 types of Folders namely
1. API
2. Core
3. Infra
4. Tests

Note: The GlobalUsing.cs files is available all the projects in this Solution. 

### API
The API folder contains the Template.WebApi Project which is used as the Starting Project for Whole Application. 
It is the user interface which has all the Controllers, Common helper files, Global Exception file.
This API project contains 3 types of folders namely CommonHelper, Controllers and Middlewares
In addition to that we have AppSettings.json and Program.cs

### Core
It is used for Model all business rules and entities in Core Project.
Application core layer contains all the business logic along with entities, domain services and inter-faces. 
The Core folder contains 2 types of projects namely Template.Application and Template.Domain	
The Application project contains 4 types of folders namely DTOs, Exceptions, Handlers and Wrappers
The Handlers folder contains 2 types of folders to implement CQRS concept like Commands and Queries.
The Domain Project contains 2 types of folders namely Common, Entities

### Infra
It depends on the Application layer for the business logic. 
It implements an interface from the application layer and provides functionality for accessing external systems.
The infrastructure layer also contains API Clients, File System, Email/SMS and System Clock. 
The Infra folder contains the Template.Infrastructure project.
This Infra project contains 4 types of folders namely Repositories, Services, StoredProcedures and UnitofWork
The Services folder contains 3 types of folders namely HttpClient, Notification and ServiceBus
In Addition to that we have BaseDataAccess.cs file in Infra folder.

### Tests
The Tests folder contains the Template.UnitTests project which is used to implement the unit test for the Application.
We have used the Xunit architecture for implementing unit tests using Moq.
The UnitTests project contains 4 types of folders namely CommonHelper, Controllers, Data and MockData
In addition to that we have BaseControllerTest.cs file in Tests folder.



# Installation
The below packages were installed in Template.Application Project.
| Packages Name               							|Version |Description  																|
| ------------------------------------------------------|--------|--------------------------------------------------------------------------|
| AutoMapper.Extensions.Microsoft.DependencyInjection	|8.1.0	 |AutoMapper extensions for ASP.NET Core									|
| MediatR.Extensions.Microsoft.DependencyInjection		|9.0.0	 |MediatR extensions for ASP.NET Core 										|
| System.Text.Json										|5.0.0	 |Provides high-performance and low-allocating types that serialize objects |
|														|		 |	to JavaScript Object Notation (JSON) text and deserialize JSON text to	|
|														|		 |	objects, with UTF-8 support built-in						|

The below packages were installed in Template.Infrastructure Project.
| Packages Name               							|Version |Description  																|
| ------------------------------------------------------|--------|--------------------------------------------------------------------------|
| Microsoft.Extensions.Http								|7.0.0	 |The HttpClient factory is a pattern for configuring and retrieving 		|
|														|		 |	named HttpClients in a composable way.  								|
| Microsoft.Extensions.Http.Polly						|7.0.1	 |This package integrates IHttpClientFactory with the Polly library, to add |
|														|		 |	transient-fault-handling and resiliency through fluent policies such as	|
|														|		 |	Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback.		|
| Serilog                                               |2.12.0  |Simple .NET logging with fully-structured events							|    
| Serilog.AspNetCore                                    |6.1.0   |Serilog support for ASP.NET Core logging									|
| Serilog.Sinks.AzureAnalytics                          |4.8.0   |Serilog event sink that writes to Azure Analytics							|
| System.Configuration.ConfigurationManager             |7.0.0   |Provides types that support using configuration files.					|
| System.Data.SqlClient                                 |4.8.5   |Provides the data provider for SQL Server. 								|


The below packages were installed in Template.WebApi Project.
| Packages Name               							|Version |Description  																|
| ------------------------------------------------------|--------|--------------------------------------------------------------------------|
| Microsoft.AspNetCore.Authentication.JwtBearer      	|6.0.11  |ASP.NET Core middleware that enables an application to receive an OpenID  |
|														|		 |	Connect bearer token.   												|
| Microsoft.Azure.AppConfiguration.AspNetCore        	|5.2.0   |Allows developers to use Microsoft Azure App Configuration service as a 	|
|														|		 |	configuration source in their applications.   							|
| Microsoft.Azure.ServiceBus                         	|5.2.0   |																			|
| Microsoft.EntityFrameworkCore                      	|6.0.0   |Entity Framework Core is a modern object-database mapper for .NET. 		|
| Microsoft.Identity.Web                             	|1.25.8  |This package enables ASP.NET Core web apps and web APIs to use the 		|
|														|		 |	Microsoft identity platform (formerly Azure AD v2.0).    				|
| Serilog                                            	|2.12.0  |Simple .NET logging with fully-structured events							|   
| Serilog.AspNetCore                                 	|6.1.0   |Serilog support for ASP.NET Core logging									|
| Serilog.Sinks.AzureAnalytics                       	|4.8.0   |Serilog event sink that writes to Azure Analytics							|
| Swashbuckle.AspNetCore                             	|6.2.3   |Swagger tools for documenting APIs built on ASP.NET Core					|


The below packages were installed in Template.UnitTests Project.
| Packages Name               							|Version |Description  																|
| ------------------------------------------------------|--------|--------------------------------------------------------------------------|
| coverlet.collector                         			|3.1.2   |Coverlet is a cross platform code coverage library for .NET, with support |
|														|		 |	for line, branch and method coverage.    								|
| Microsoft.DotNet.PlatformAbstractions      			|3.1.6   |Abstractions for making code that uses file system and environment 		|
|														|		 |	testable.																|
| Microsoft.NET.Test.Sdk                     			|17.3.2  |The MSbuild targets and properties for building .NET test projects.		|
| Moq                                        			|4.18.3  |Moq is the most popular and friendly mocking framework for .NET.			|
| xunit                                      			|2.4.2   |xUnit.net is a developer testing framework, built to support Test Driven 	|
|														|		 |	Development, with a design goal of extreme simplicity and alignment 	|
|														|		 |	with framework features.    											|
| xunit.runner.visualstudio                  			|2.4.5   |Visual Studio 2019 16.8+ Test Explorer runner for the xUnit.net framework	|


# configuration
We have implemented Azure App Configuration Settings to fetch the Secret values



