# Tag Helper Dashboard

This app is intented to teach developers how to use Tag Helpers from the Telerik UI for ASP.NET Core library.

A full video series showing the process step-by-step can be found on YouTube at: https://www.youtube.com/playlist?list=PLvmaC-XMqeBbdRl1LptZVSG8TqnG31ubO

To get stared Clone or copy the master branch and follow the video tutorial after completing the steps below.

The completed application code can be found under the `completed` branch in this repository.

## Telerik UI for ASP.NET Core

In order to use the application you must have a license or 30 day free trial.

A 30 day free trial can be obtained from https://www.telerik.com/aspnet-core-ui

Documentation and installation instructions can be found at: https://docs.telerik.com/aspnet-core/introduction

Before building the application, please refer to the Dependency Management section and follow the instructions on obtaning the Telerik NuGet feed.

## Dependency Management

This application was built using the full licensed version of Telerik UI for ASP.NET Core.

A private NuGet feed is required to successfully build this project. For complete instructions on obtaining the Telerik NuGet feed, please see: https://docs.telerik.com/aspnet-mvc/getting-started/nuget-install#set-up-nuget-package-source

If you're using a trial license you will need to reference the `.Trial` dependency in place of the full version. This change can be made from the NuGet Package Manager or via the application's `.csproj` file by changing the followinig references.

```
<!--If using a 30 day free trial use the *.Trial package instead-->
<PackageReference Include="Telerik.UI.for.AspNet.Core" Version="<current version>" />    
<!--<PackageReference Include="Telerik.UI.for.AspNet.Core.Trial" Version="<current version>" />-->
```

## Database Connections

The applicaiton uses the Northwind Database which is included in the application's `/App_Data` directory for ease of use.

Before running the application, set the connection string to the database using the following method.

1. **From the command line** Open the project folder of the application (this is the folder containing the .csproj file).
2. Run following command using your applicaiton's path. `dotnet user-secrets set ConnectionStrings:NorthwindDB "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=<path to App_Data>\Northwind.MDF;Integrated Security=True;Connect Timeout=30"`
3. Check the application by running the app and testing the endpoint `<localhost>/employees/employees_read`. The endpoint will return `[{"employeeId":2,"fullName":"Andrew Fuller","hasChildren":true}]`

