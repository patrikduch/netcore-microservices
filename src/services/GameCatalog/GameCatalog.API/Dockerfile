#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/services/GameCatalog/GameCatalog.API/GameCatalog.API.csproj", "src/services/GameCatalog/GameCatalog.API/"]
RUN dotnet restore "src/services/GameCatalog/GameCatalog.API/GameCatalog.API.csproj"

ARG RABBITMQENV
ENV SA_RABBIT=$RABBITMQENV
RUN echo $(SA_RABBIT)


COPY . .
WORKDIR "/src/src/services/GameCatalog/GameCatalog.API"
RUN dotnet build "GameCatalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GameCatalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameCatalog.API.dll"]