# BigTimeApp

This is a personal project which includes a .net8 API and a simple React front-end.

## BigTimeApi details

- .net8 API.
  - Decided that working within the constraints of the existing project required too much refactoring - and for me created too many questions which I did not have the affordance of time to ask or get answers to. So, I decided to rewrite the API, which was an option in the bonus for the assignment.
  - When you run the API in dotnet, it will default to the get-all API call on http://localhost:8258
- Creates SQLite database when you start the application, creating one table (Customer) with one sample record.
- Repository data layer which leverages Dapper for the ORM and SQLite as the backing data store. 
  - Respository layer DI injected in Program.cs.
  - Basic CRUD operations for a single entity.
- Service layer acting as business wrapper for all repository calls.
  - Service layer DI injected in Program.cs.
  - Applies all business logic.
- Factory layer which encapsulates concrete object creation.
  - Factory layer DI injected in Program.cs.
- Unit tests on all service layer methods.

### Specific notations on assignment for back end api

- Create Customer object.
  - Should be implemented to specification.
- Implement Save() and Delete() methods on Customer object.
  - I was challenged by the idea of this, as I perceived that the object itself would have to have some knowledge of the servie or repository layer in order to know how to save or delete itself.
  - I decided to craft these methods in the ICustomerRepository instead, along with all the other CRUD methods; it seemd like a better fit, because all data abstraction could then happen in one place.
- Do not permit saving new or existing customers who do not have certain data.
  - This is implemented but validation occurs in the service layer. I think business logic like this belongs in the service layer.
- Create a repository for all Get methods (as well as the Save/Delete methods).
  - Should be implemented to specification.
- Wrote unit tests on the service layer so I could exercise business logic (which I felt was most important - and more realistic - to test). Mocked the repository methods in the unit tests on the service layer.
- Data access layer levergaes dependency injection, so if we wanted to leverage a different ORM or a different database technology, we could easily create a new instance of `ICustomerRepository` and builf that out.

## BigTimeUI details

- React application.
  - Much like the original front end solution, I had too many questions about how to work within the legacy solution. I opted to go with React.
  - When you run the UI (via `npm start`), it will stand up a server and run on http://localhost:8080
  - You can run the dotnet solution while running the front-end application for full round-trip.
- Created a CustomerList React component
- I wasn't sure if the project wanted me to exercise all API endpoints, so I built that UI, and all CRUD is implemented and works:
  - Create a new Customer.
  - Update an existing Customer.
  - Delete an existing Customer.
  - Get a specific Customer.
  - Get all Customers.
- All pages leverage Bootstrap (v4) and were built with simple grid classes to provide a minimal but fully functional responsive experience.

### Specific notations on assignment for front end app

- **I opted to not complete the filtering request**. Reasons:
  - I still don't fully cmprehend the language in the assignment's ask. "Add the ability to filter the customer list by any field on the customer object".
    - Does that mean simple add a search filter that searches across all fields of all customers in the list, and only show customers (rows) that match?
    - Does that mean some kind of UI that lists fields and inputs for each field, such that a user can search for "123" only in the street field?
  - Since this was listed as a bonus ask, and given my need to vet the ask further, I opted not to build this out.
