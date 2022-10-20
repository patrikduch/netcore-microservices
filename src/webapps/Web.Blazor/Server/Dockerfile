#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/webapps/Web.Blazor/Server/Web.Blazor.Server.csproj", "src/webapps/Web.Blazor/Server/"]
COPY ["src/webapps/Web.Blazor/Client/Web.Blazor.Client.csproj", "src/webapps/Web.Blazor/Client/"]
COPY ["src/webapps/Web.Blazor/Shared/Web.Blazor.Shared.csproj", "src/webapps/Web.Blazor/Shared/"]

ARG NUGET_PAT

# Set environment variables
ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED true
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS '{"endpointCredentials":[{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Configuration/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"}]}'

# Get and install the Artifact Credential provider
RUN wget -O - https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | bash

# Restore your nugets from nuget.org and your private feed.
RUN dotnet restore -s "https://api.nuget.org/v3/index.json" -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Configuration/nuget/v3/index.json" "src/webapps/Web.Blazor/Server/Web.Blazor.Server.csproj"

COPY . .
WORKDIR "/src/src/webapps/Web.Blazor/Server"
RUN dotnet build "Web.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Blazor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Blazor.Server.dll"]