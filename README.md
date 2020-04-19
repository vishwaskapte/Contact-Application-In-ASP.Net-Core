# Contact-Application-In-ASP.Net-Core

ASP.NET CORE MVC Project (Contact Information)

This Project is developed in Asp.net MVC Core 3.0.0 with No Authentication.

This project is complete aim on to autonate entries of contact.

There is only 1 end User of project

1)	Admin end

<b>About Platform Used</b>

I had developed this Application using Microsoft Visual Studio Community 2019 with Microsoft SQL server 2019.
Server-side Technology used is ASP.NET Core MVC 3.0 and Language used for developing in C#, along with this Entity Framework Core
and Dependency Injection for database accessing and finally for using Services we have Used Web API.
Added Unit Testing for additional help.

1) Microsoft Visual Studio 2019
2) Sql Server 2019
3) xUnit for Unit Testing
4) Web API
5) Entity Framework Core (Code First Approach)
6) Logging facility
7) Validation


<b>How to Create Database in SQL Server</b>

With the use of Entity Framework, You can only Create Database. Other things Like Tables are created at Context Classes.
For Database Migration some of the CLI Commands to use Code First Approach.

Add-Migration 
Drop-Database
Update-Database

Steps to Create Tables
1) Create Context Classes
2) Run Command Add-Migration Initial
After Build Success
3) Run Command Update-Database
to create tables into DB.

<b>How to Login</b>

Credentials
1) UserId - Admin
2) Password - Admin

<b>ScrenShots</b>

Project Structure

![ProjectStructure](https://user-images.githubusercontent.com/45562090/79686927-75eb1280-8261-11ea-8602-2ab32aff1559.PNG)


WEB API Swagger Page

![Swagger](https://user-images.githubusercontent.com/45562090/79686842-e180b000-8260-11ea-8306-cb19b18f436e.png)


Login Page

![Login](https://user-images.githubusercontent.com/45562090/79686840-df1e5600-8260-11ea-9dbd-3efe4eee9044.png)


First Page After Login

![Index](https://user-images.githubusercontent.com/45562090/79686836-db8acf00-8260-11ea-8c86-69b1ce798766.png)


Unit Test case (Success State)

![Unit Test cases](https://user-images.githubusercontent.com/45562090/79687125-b303d480-8262-11ea-8887-c07ab0eb041e.png)


Validation fired on Create Page

![Validation](https://user-images.githubusercontent.com/45562090/79688348-67a1f400-826b-11ea-8890-4aab087b7009.png)

Log Generated

![LoggingText](https://user-images.githubusercontent.com/45562090/79688351-6a9ce480-826b-11ea-83d9-2ade34863e97.png)


