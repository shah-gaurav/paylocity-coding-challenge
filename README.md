# Paylocity Coding Challenge

[![Build Status](https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_apis/build/status/paylocity-coding-challenge-ASP.NET%20Core-CI?branchName=master)](https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_build/latest?definitionId=1?branchName=master) [![](https://img.shields.io/azure-devops/tests/shahgaurav/paylocity-coding-challenge/1.svg)](https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_build/latest?definitionId=1?branchName=master) [![](https://img.shields.io/azure-devops/coverage/shahgaurav/paylocity-coding-challenge/1.svg)](https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_build/latest?definitionId=1?branchName=master) [![](https://vsrm.dev.azure.com/shahgaurav/_apis/public/Release/badge/1f45e0ad-55b2-48e6-8f6b-63c5bae1265a/1/1)](https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_release?view=mine&definitionId=1) [![](https://img.shields.io/website-up-down-green-red/https/gaurav-shah-paylocity-coding-challenge.azurewebsites.net.svg?label=Demo%20Website)](https://gaurav-shah-paylocity-coding-challenge.azurewebsites.net)

## Problem Statement
We provide our clients with the ability to pay for their employees’ benefits packages. A portion of these costs are deducted from their paycheck, and we handle that deduction. Please demonstrate how you would code the following scenario:
* The cost of benefits is $1000/year for each employee
* Each dependent (children and possibly spouses) incurs a cost of $500/year
* Anyone whose name starts with ‘A’ gets a 10% discount, employee or dependent

We’d like to see this calculation used in a web application where employers input employees and their dependents, and get a preview of the costs.

Please implement a web application based on these assumptions:
* All employees are paid $2000 per paycheck before deductions
* There are 26 paychecks in a year.

## Solution
### Decomposing the Problem
For the purpose of this exercise lets assume that a meeting was conducted between the product owner and the users. Out of that meeting the following user stories were created.
#### User Stories
##### Epic and/or Feature

> As an employer  
> I want to receive an estimate of my employee's paycheck after the costs of benefits have been deducted  
> So that I can preview it and share it with them

##### User Stories
This feature would then be broken down by the team into smaller user stories that can be completed in a day or two. Here is one such example break down:

> As an employer  
> I want to calculate my employee's paycheck after the cost of benefits are deducted 
> So that I provide that information to him/her  
> The cost to cover each employee is $1000/year

> As an employer  
> I want to calculate my employee's paycheck after the costs of benefits for the employee and their dependents are deducted  
> So that the employee can get a complete picture of what the costs would be to cover their entire family  
> The cost to cover each dependent (child and potentially spouse) is $500/year

> As an employer  
> I want to provide a 10% discount in the cost of benefits to all employees and their dependents whose name starts with the letter 'A'  
> So that my company's business rules are satisfied

> As an employer  
> I want to provide information about the employee and their dependents on a website and get a report of the yearly and monthly salary with the cost of benefits deduction  
> So that I can provide these to the employee

### Implementation
#### Technologies Used

 - Visual Studio 2017 Community Edition
 - .NET Standard 2.0
 - ASP.NET Core 2.2

#### Instructions
1. Make sure .NET Core 2.2 or higher SDK is installed on your machine using the command 'dotnet --version'
2. Clone the repository locally using 'git clone https://github.com/shah-gaurav/paylocity-coding-challenge.git'
3. Navigate to the Paylocity.CodingChallenge.Web folder
4. Execute command 'dotnet run' to start the website and navigate to the URL provided in the console output in your favorite browser.
5. To run the unit tests, navigate into the Paylocity.CodingChallenge.Business.Tests, Paylocity.CodingChallenge.Web.Tests, and Paylocity.CodingChallenge.Web.Tests.Integration folders individually and run the 'dotnet test' command.

#### Project Organization
- **Paylocity.CodingChallenge.Entities** (*.NET Standard 2.0*) - Contains the shared entities and definitions.
- **Paylocity.CodingChallenge.Business** (*.NET Standard 2.0*) - Contains the business logic for calculating the benefits deduction. 
- **Paylocity.CodingChallenge.Busines.Tests** (*.NET Core 2.2*) - Contains the unit tests to test the business logic.
- **Paylocity.CodingChallenge.Web** (*.NET Core 2.2*) - Contains the web interface implementation of the benefits calculator. This project uses ASP.NET Core 2.2 Razor Pages and is not based on the ASP.NET Core MVC pattern. Information about Razor Pages is available at [https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.2&tabs=visual-studio](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.2&tabs=visual-studio).
- **Paylocity.CodingChallenge.Web.Tests** (*.NET Core 2.2*) - Contains the unit tests to test the services and Razor Pages in the Web project. Details about the Razor Pages unit tests are provided in the Unit Testing section below.
- **Paylocity.CodingChallenge.Web.Tests.Integration** (*.NET Core 2.2*) - Contains the integration tests for testing the web interface. Details about these integration tests are provided in the Integration Testing section below.

#### Notable Implemenation/Design Decisions
In keeping with the [Agile principles](https://www.agilealliance.org/agile101/12-principles-behind-the-agile-manifesto/) of working software is the primary measure of progress and simplicity is essential, I have implemented the minimal solution required to satisfy the problem statement and complete the user stories listed above. Once the customer sees the working software they can provide feedback about what other features to implment and their priorites. The following is a potential list of enhancements that the customer can consider for furture releases:
- User authentication and session management for a personalized experience. 
- Ability for different employers to have different deduction costs and discount rules (SaaS multi-tenant model).
- Integrate with other systems to automatically retrieve employee data for calculations.
- Store the calculations done by the system in a data store (relational or non-relational).
- User interface enhancements like:
	- Adding client side code to add or remove dependents dynamically on the employee information page.
	- Showing calcuation results without doing a full page post back.  

Some of these enhancements might change the architecture of the application to be a multi-tiered application with an API and/or a database backend. The current application architecture follows SOLID design principles to allows for such enhancements to be made with ease and in a maintainable way. 

### Testing
#### Unit Testing
The unit tests provided in this example exercise the public interfaces for the various classes to ensure that the classes provide the functionality that is expected and that invalid data and corner cases are correctly handled. Unit tests for the Razor Pages in this application were developed based on Microsoft guidelines for writing unit tests for Razor Pages in ASP.NET Core available at [https://docs.microsoft.com/en-us/aspnet/core/test/razor-pages-tests?view=aspnetcore-2.2](https://docs.microsoft.com/en-us/aspnet/core/test/razor-pages-tests?view=aspnetcore-2.2).

> **A note about Code Coverage**
> My goal was to provide 100% code coverage for all the code that I created/wrote. To achieve this goal I excluded all template generated code from being counted towards code coverage by using the *ExcludeFromCodeCoverage* attribute. There is also a *CodeCoverage.RunSettings* file provided in the repository that excludes certain 3rd party assemblies and the unit test projects themselves.

#### Integration Testing
Integration tests exercise the entire application stack to identify integration issues between different layers of the application. Example integration tests provided with this sample are developed based on Microsoft guidelines for writing integration tests for ASP.NET Core applications available at [https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2](https://docs.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-2.2).
#### Manual Testing
A manual test plan should be created so that human validation can be performed on each release before it is promoted to production. The manual test plan should look for things like:
- Look and feel of the website
- Spelling and grammatical errors on the pages
- Error conditions and validation messages are displayed correctly to the user
- Test happy path to ensure that most major functionalities of the website is not affected by the release
#### Performance Testing
A load test plan should be in place and executed on each build that is promoted to production. The purpose of this plan is to establish that the baseline performance is within the set guidelines for the product and to make sure that performance is not negatively affected by new features or changes that are implemented in the future.

### Deployment
#### Continuous Integration
This repository is setup for continuous integration using Azure Pipelines Build system. Build history, including details of build statu, test results and code coverage can be viewed in at the link below:

[https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_build/latest?definitionId=1?branchName=master](https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_build/latest?definitionId=1?branchName=master)
#### Continuous Delivery
If a build is successful and all unit tests pass, the build is automatically deployed to a demo/staging website using Azure Pipelines Release system. Detail history of the past releases  and their logs can be viewed at the link below:

[https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_release?view=mine&definitionId=1](https://dev.azure.com/shahgaurav/paylocity-coding-challenge/_release?view=mine&definitionId=1)
#### Demo Website
After successful deployment, the results of the code changes can be verified at the following website:

[https://gaurav-shah-paylocity-coding-challenge.azurewebsites.net](https://gaurav-shah-paylocity-coding-challenge.azurewebsites.net)

This website is running on [Azure Web Apps](https://azure.microsoft.com/en-us/services/app-service/web/) platform  on Windows.

### Monitoring
Before the solution is deployed to a production environment an APM solution like [Application Insights](https://docs.microsoft.com/en-us/azure/application-insights/app-insights-overview) should be integrated with it to help with logging, performance monitoring, gaining user insights, and help with finding and fixing issues.


> Written by [Gaurav Shah](http://www.linkedin.com/in/gaurav-shah-boise).