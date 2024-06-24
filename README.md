# Library Management API
Using Clean Architecture with a glimpse of Vertical Slice for use case structuring.

Consist of 4 Projects
 - LibraryManagement.API --> Handles web api endpoints and building the project configurations.
 - LibraryManagement.Application --> Handles the use cases of the application. These use cases represent user interactions on the API.
 - LibraryManagement.Domain --> Handles enterprise logic and types that define business entities, rules, and concepts.
 - Libarrymanagement.Infrastructure.EFCore --> Handles the data saving to the database.

Technology
- AutoMapper
- FluentValidation
- MinimalAPI
- MediatR
- EFCore

  Design Pattern
  - Clean Architecture
  - Factory
  - Repository
  - REPR
  - MediatR
  - CQRS


