#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/services/Inventory/Inventory.API/Inventory.API.csproj", "src/services/Inventory/Inventory.API/"]

ARG NUGET_PAT

# Set environment variables
ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED true
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS '{"endpointCredentials":[{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Dbs/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"},{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Configuration/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"},{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Messaging/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"}]}'

# Get and install the Artifact Credential provider
RUN wget -O - https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | bash

# Restore your nugets from nuget.org and your private feed.
RUN dotnet restore -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Messaging/nuget/v3/index.json" -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Dbs/nuget/v3/index.json" -s "https://api.nuget.org/v3/index.json" -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Configuration/nuget/v3/index.json" "src/services/Inventory/Inventory.API/Inventory.API.csproj"



COPY . .
WORKDIR "/src/src/services/Inventory/Inventory.API"
RUN dotnet build "Inventory.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inventory.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inventory.API.dll"]