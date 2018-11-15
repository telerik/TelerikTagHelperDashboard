# Tag Helper Dashboard

![](https://raw.githubusercontent.com/telerik/TelerikTagHelperDashboard/completed/TelerikTagHelperDashboard/wwwroot/images/completed-app.jpg)

This app demonstrates how to use Tag Helpers from the Telerik UI for ASP.NET Core library. 

The product documentation is found at https://docs.telerik.com/aspnet-core/introduction.

## Prerequisites

- [.NET Core SDK v2.1 or later](https://www.microsoft.com/net/download)
- Telerik UI for ASP.NET Core license or [30-day free trial](https://www.telerik.com/aspnet-core-ui)

## Clone repository

To get started, clone this GitHub repository. Using the **master** branch, follow the [YouTube video series](https://www.youtube.com/playlist?list=PLvmaC-XMqeBbdRl1LptZVSG8TqnG31ubO) after completing the steps outlined in the sections below.

To see the completed code, review the **completed** branch.

## Configure NuGet

A private Telerik NuGet feed is required to build the project. To configure the NuGet feed, see https://docs.telerik.com/aspnet-mvc/getting-started/nuget-install#set-up-nuget-package-source.

This app was built using the full licensed version of Telerik UI for ASP.NET Core. If using a trial license, reference the `.Trial` NuGet package in place of the full version. Use NuGet Package Manager or manually edit the *.csproj file by changing the following references:

```xml
<!-- If using a 30-day free trial, use the *.Trial package instead -->
<PackageReference Include="Telerik.UI.for.AspNet.Core" Version="<current version>" />
<!--<PackageReference Include="Telerik.UI.for.AspNet.Core.Trial" Version="<current version>" />-->
```

## Store connection string

The app uses the Northwind database, which is found in the project's *App_Data* directory. Store the database connection string as a user secret. Follow the instructions below for Visual Studio or the .NET Core CLI.

### Visual Studio

1. Right-click the project in **Solution Explorer**, and select **Manage User Secrets** from the context menu.
1. Replace the contents of *secrets.json* with the following. Remember to replace `<path-to-App_Data>` with your project's *App_Data* directory path:

    ```json
    {
      "ConnectionStrings": {
        "NorthwindDB": "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=<path-to-App_Data>\\Northwind.MDF;Integrated Security=True;Connect Timeout=30"
      }
    }
    ```

### .NET Core CLI

1. From a command shell, navigate to the root project directory. This directory contains the *.csproj file.
1. Run the following command, replacing `<path-to-App_Data>` with your project's *App_Data* directory path:

    ```console
    dotnet user-secrets set ConnectionStrings:NorthwindDB "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=<path-to-App_Data>\Northwind.MDF;Integrated Security=True;Connect Timeout=30"
    ```

## Test app

In a browser, navigate to `http://<localhost>/employees/employees_read`. 

The endpoint returns `[{"employeeId":2,"fullName":"Andrew Fuller","hasChildren":true}]`.
