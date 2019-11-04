# InnserSpaceConfiguration
A api that manage configurations for customers and give different roles different set of functions

Introduction
Location: https://github.com/DureSameen/InnserSpaceConfiguration
This solution contains a configuration API and Identity-Server website for authentication. Following instruction may help to run the project.
The unit tests projects use in Memory database and while API uses a SQL database.

A)	Preparing Database

1.	Set Configuration API “InnerSpace.ConfigurationApi” as startup project.

2.	Change connection string of database in appsettings.json of configuration API “InnerSpace.ConfigurationApi”

3.	In Package Manager console, run “Update-Database”, command that will create database and tables. 


B)	Understanding Entities 

1.	Configurations (AdminOnly)	Basic configuration attributes that needed to be managed.
2.	Subscriptions:  (AdminOnly)          Different kind of available subscription types like for example “Standard”, “Professional” and “Free” etc.
3.	SubscriptionConfigurations : (AdminOnly) Each subscription contains a set of configurations and their settings.
4.	UsersSubscriptions : (CustomerOnly ,FieldEnginnerOnly ) A field engineer or customer can subscribe to different subscription and save APIKey for it.
5.	CustomerSubscriptionConfigurations: (CustomerOnly)   details of a customer, manage his own configurations enabled and disabled them.
6.	EventLogs: (AuditorOnly)logs of events of custom subscription configurations available for security audit.

C)	Users and Roles
You can use swagger Authorize button to authorize user with one of these credentials.
                    Users:  
1.	Username = "admin1",
                  	Password = "password",
                  	Role= "admin"

2.	Username = "fieldEngineer1",
                     Password = "password",
                     Role= “field Engineer"
               
3.	Username = "customer1",
                     Password = "password",
                     Role=       "customer 
 
4. Username = "auditor1",
                	Password = "password",
                     Role= " auditor"
 
D)	Running Projects:
1.	Configuration API is configured at URL: https://localhost:44370/, if is not same one then updates Models\Clients.cs in Identity-Server API.

2.	Identity-Server is configured at URL : https://localhost:44387/ , if it is not same then update appsettings.cs in Configuration API.

3.	Set multiple startup Projects as Configuration API and IdentityServer. And run the swagger interface of API. You may need to login to different credentials to execute different end points.

 

