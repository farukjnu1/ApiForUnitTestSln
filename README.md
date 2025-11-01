🧪 ApiForUnitTestSln
ApiForUnitTestSln is a simple yet powerful ASP.NET Core solution that demonstrates how to apply unit testing to a Web API project using MSTest, along with Moq and AutoFixture for mocking and data generation.

-----------------------

📁 Solution Structure
The solution consists of two projects:
| Project            | Description                                                                                                                                                                                  |
| ------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **ApiForUnitTest** | ASP.NET Core **Web API** project that exposes controller endpoints for demonstration purposes.                                                                                               |
| **TestsByMSTest**  | **Unit test project** built using MSTest, containing tests for the Web API controllers. It uses **Moq** for mocking dependencies and **AutoFixture** for generating test data automatically. |

--------------------------------------

⚙️ Technologies Used
ASP.NET Core Web API (.NET 9)
EF Core, Repository Pattern
MSTest – Unit testing framework
Moq – Mocking framework for dependency injection
AutoFixture – Automatic test data generation
Dependency Injection – To isolate and test controllers

---------------------------------------

🧰 Example Testing Setup
The testing focuses on controller-level unit tests, ensuring the API’s business logic behaves correctly in isolation.
Example Tools Used
dotnet add package MSTest.TestFramework
dotnet add package MSTest.TestAdapter
dotnet add package Moq
dotnet add package AutoFixture

----------------------------------------

🧩 Key Highlights
✅ Demonstrates clean separation between API and Test projects
✅ Uses Moq to mock service dependencies
✅ Leverages AutoFixture to reduce test boilerplate
✅ Applies unit testing best practices in ASP.NET Core
✅ Suitable as a starter template for Web API unit testing

-----------------------------------------

📸 Example Test Output
Test run for TestsByMSTest.dll (.NETCoreApp,Version=v9.0)
Passed!  - 10 tests in 1 test file.
