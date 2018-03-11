FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
ENV ASPNETCORE_URLS http://+:81
EXPOSE 81

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Samples.sln ./
COPY ReportFormsSample/ReportFormsSample.csproj ReportFormsSample/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/ReportFormsSample
RUN npm i
RUN npm run build
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ReportFormsSample.dll"]
