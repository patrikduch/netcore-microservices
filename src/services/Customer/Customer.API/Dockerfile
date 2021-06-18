#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

ARG NUGET_PAT

# Set environment variables
ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED true
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS '{"endpointCredentials":[{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Messaging/nuget/v3/index.jso","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"},{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Dbs/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"},{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Configuration/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"}]}'

# Get and install the Artifact Credential provider
RUN wget -O - https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | bash

COPY ["src/services/Customer/Customer.API/Customer.API.csproj", "src/services/Customer/Customer.API/"]
COPY ["src/services/Customer/Customer.Domain/Customer.Domain.csproj", "src/services/Customer/Customer.Domain/"]
COPY ["src/services/Customer/Customer.Application/Customer.Application.csproj", "src/services/Customer/Customer.Application/"]
COPY ["src/services/Customer/Customer.Infrastructure/Customer.Infrastructure.csproj", "src/services/Customer/Customer.Infrastructure/"]
COPY ["src/services/Customer/Customer.Persistence/Customer.Persistence.csproj", "src/services/Customer/Customer.Persistence/"]

# Restore your nugets from nuget.org and your private feed.
RUN dotnet restore -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Dbs/nuget/v3/index.json" -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Messaging/nuget/v3/index.json" -s "https://api.nuget.org/v3/index.json" -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Configuration/nuget/v3/index.json" "src/services/Customer/Customer.API/Customer.API.csproj"


COPY . .
WORKDIR "/src/src/services/Customer/Customer.API"
RUN dotnet build "Customer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Customer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customer.API.dll"]