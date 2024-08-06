"# .NetCustomerApplication" 
This project is a customer rewards management system for major telecommunications companies. The system allows agents to input customer data and assign rewards, as well as generate reports based on successful purchases. The system uses a SOAP service for customer data retrieval and ASP.NET Web API for interaction with the user interface.

Used technologies ASP.NET Web Forms SOAP Web Services Bootstrap 5 Postman SQL Server Management Studio (SSMS) C#

User Interface Customer Input Page (UsersForm.aspx) & Agent Login Form (LoginForm.aspx): Forms for entering customer data, including name, ID, email, phone, and reward. Button to generate reports. Button to search customers by ID - which is connected to SOAP service.

ASP.NET Web API SOAP Client Endpoint: /api/soapclient/find/{id} Method: GET Functionality: Uses SOAP service to retrieve customer data and returns the data in JSON format

Database Management Database: SQL Server Management Tool: SQL Server Management Studio (SSMS) Functionality: Stores customer data and reward information. Used for retrieving and updating customer information as needed.

Running First RUN the Login Form
