#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetCoreMicroservices.API/NetCoreMicroservices.API.csproj", "NetCoreMicroservices.API/"]
RUN dotnet restore "NetCoreMicroservices.API/NetCoreMicroservices.API.csproj"
COPY . .
WORKDIR "/src/NetCoreMicroservices.API"
RUN dotnet build "NetCoreMicroservices.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetCoreMicroservices.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetCoreMicroservices.API.dll"]
