#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebAPI-GW/WebAPI-GW.csproj", "WebAPI-GW/"]
RUN dotnet restore "WebAPI-GW/WebAPI-GW.csproj"
COPY . .
WORKDIR "/src/WebAPI-GW"
RUN dotnet build "WebAPI-GW.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI-GW.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI-GW.dll"]