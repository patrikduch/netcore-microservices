#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk AS build
WORKDIR /src
#COPY ["src/services/Catalog/Catalog.API/nuget.config", "src/services/Catalog/Catalog.API/"]
COPY ["src/services/Catalog/Catalog.API/Catalog.API.csproj", "src/services/Catalog/Catalog.API/"]
RUN dotnet restore  -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Dbs/nuget/v3/index.json" "src/services/Catalog/Catalog.API/Catalog.API.csproj"
COPY . .
WORKDIR "/src/src/services/Catalog/Catalog.API"
RUN dotnet build "Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.API.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]