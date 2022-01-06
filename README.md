# project 1: store web application
Nov 15 2021 Arlington .NET / Richard Hawkins, Nick Escalona

## functionality
* interactive console application with a REST HTTP API backend - [x]
* place orders to store locations for customers 
* add a new customer - [x]
* search customers by name - [x]
* display details of an order - [x]
* display all order history of a store location - [x]
* display all order history of a customer - [x]
* input validation (in the console app and also in the server)
* exception handling, including foreseen SQL and HTTP errors
* persistent data; no prices, customers, order history, etc. hardcoded in C# - [x]
* (recommended: asynchronous network & other I/O, at least on the REST API)
* (optional: logging of exceptions and other events
* (optional: order history can be sorted by earliest, latest, cheapest, most expensive)
* (optional: get a suggested order for a customer based on his order history)
* (optional: display some statistics based on order history)

## design
* use ADO.NET (not Entity Framework) - [x]
* use ASP.NET Core Web API - [x]
* use an Azure SQL DB in third normal form - [x]
* have a SQL script that can set up the database from scratch - [x]
* don't use public fields - [x]
* define and use at least one interface - [x]
* best practices: separation of concerns, OOP principles, SOLID, REST, HTTP
* XML documentation - [x]

### REST API

* the API should own the business logic of the application, not just the data access logic - [x]
* it shouldn't trust that the console app hasn't been tampered with
* should be able to handle multiple instances of the console app connecting to it at the same time - [x]
* use dependency injection for controller dependencies
* separate different concerns into different classes - [x]
* use repository pattern for data access - [x]
* recommended to keep the Web API project for only HTTP input/output concerns
* recommended to use separate classes to help validate/format the HTTP message bodies (DTOs for model binding and action results)
* recommended to separate business logic into a separate project from the Web API project and any HTTP or ADO.NET concerns
* recommended to separate the data access into a separate project too

#### customer
* has first name, last name, etc. - [x]
* (optional: has a default store location to order from) 

#### order
* has a store location - [x]
* has a customer - [x]
* has an order time (when the order was placed) - [x]
* can contain multiple kinds of product in the same order 
* rejects orders with unreasonably high product quantities - [x]
* (optional: some additional business rules, like special deals)

#### location
* has an inventory - [x]
* inventory decreases when orders are accepted
* rejects orders that cannot be fulfilled with remaining inventory
* (optional: for at least one product, more than one inventory item decrements when ordering that product)

#### product (etc.)

### console app
* the console app provides a UI, interprets user input, uses the REST API over HTTP, and formats output - [x]
* should gracefully handle HTTP error codes from the server, as well as connection errors
* separate different concerns into different classes - [x]
* recommended to separate the connection to the API into a separate project
* recommended to keep the console app project for only console interface concerns, not HTTP concerns

### tests
* at least 10 test methods
* at least 1 test should use Moq
* no tests should connect to the app's actual database