This solution contains 5 projects:

* ProductsApp.Web - Presentation Layer
* ProductsApp.Service - Service Layer
* ProductsApp.Service.Tests - Unit tests of the Service Layer
* ProductsApp.Models - POCO/DTO objects
* ProductsApp.Data - Data Layer

The uses of each should be self expanatory.  The code is not commented because it is also very simple and readable.  There are unit tests only of the service layer because I do not need to test MVC itself at the controller level and I do not need to test EF itself or the data access as an integration test.  The logic is in the service layer, therefore, that is what is tested.