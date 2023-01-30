An example to show how you could use clean architecture and DDD and their advantages.

Using clean architecture as architecture style combines with Domain-driven Design because we completely focus on our domain core (entities and use cases). Domain-driven Design (DDD) combines with clean architecture due to the fact that DDD is focused on your business domain. Focusing on your domain is supported by the goal of clean architecture, keeping the domain free of any framework or technologies. E.g. your domain does not focus on how to persist something, it just tells the outgoing port to save it. The implementation of the port (placed on the adapter layer) decides to use, e.g., relational or non-relational databases.

Beside the matching goal of DDD and clean architecture, DDD tries to help you build complex designs around your domain, by e.g., building immutable objects that know all about their invariants, which helps you even more to structure your code.

![MicrosoftTeams-image (1)](https://user-images.githubusercontent.com/46405345/215432343-2e68656c-5372-4bcf-a791-15a530fb2d32.png)



<h1> 1. Core: </h1>
The core part of the application consists of the domain and application layer.
a) Entities (Domain)
Design domain entities
b) Use cases (Application)
Implemented use cases around entities using CQRS design patterns.
I have segregated this layer into two parts to facilitate cqrs pattern. Currently, we have a single app for both command and query operations but with this extensible approach, we can easily separate the logic for separate deployable apps.
<h1> 2. Infrastructure: </h2>
With the entities, use cases, and controllers in place, there’s only one more layer left: The infrastructure layer. This layer contains things like database adapters or API calls to third-party APIs.
I have segregated this layer into two parts to separate read and write database operations. Currently, we have a single app for both command and query operations but with this approach, we can easily separate the logic for separate deployable apps.
a)	For Command 
I’m using Entity Framework as ORM for database write operations.
b)	For Query
I’m using Dapper as Mico-ORM for database read operations.
<h3> 3. Presentation: </h3>
I have built a REST API, and the consumer of the API can invoke the use cases using a command handler.
