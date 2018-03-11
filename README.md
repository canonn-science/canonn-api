# Canonn-API vNext

This repository contains the Canonn Research API vNEXT.

The projects are mainly build with [.NET Core](https://www.microsoft.com/net).

## 1. Prerequisites

The following prerequisites are **required** to work on the API:

* [.NET Core SDK 2.1.4](https://www.microsoft.com/net/download/windows)
* [Node.js 8 or 9](https://nodejs.org)

The following prerequisites are **optional** to work on the API:

* [Docker](https://docs.docker.com/install/)  
    For external dependencies on 3rd party infrastructure services like _Event Store_ we provide configurations for Docker.

## 2. Preparation

### Project ReportingHub

* Visual Studio Code  
    Run `npm i` in the `ReportingHub` folder before openening the project in.
* Visual Studio 2017  
   When opening the `MicroServices.sln` in Visual Studio 2017, it should automatically install all required Node modules and NuGet packages. You can of course manually install the Node packages.
