#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/webapps/Web.Blazor/Web.Blazor/Server/Web.Blazor.Server.csproj", "src/webapps/Web.Blazor/Web.Blazor/Server/"]
COPY ["src/webapps/Web.Blazor/Web.Blazor/Client/Web.Blazor.Client.csproj", "src/webapps/Web.Blazor/Web.Blazor/Client/"]
COPY ["src/webapps/Web.Blazor/Web.Blazor/Shared/Web.Blazor.Shared.csproj", "src/webapps/Web.Blazor/Web.Blazor/Shared/"]
RUN dotnet restore "src/webapps/Web.Blazor/Web.Blazor/Server/Web.Blazor.Server.csproj"
COPY . .
WORKDIR "/src/src/webapps/Web.Blazor/Web.Blazor/Server"
RUN dotnet build "Web.Blazor.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Blazor.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Blazor.Server.dll"]