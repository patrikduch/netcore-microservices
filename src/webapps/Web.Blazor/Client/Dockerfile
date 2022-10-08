FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/webapps/Web.Blazor/Client/Web.Blazor.Client.csproj", "src/webapps/Web.Blazor/Client/"]

RUN dotnet restore "src/webapps/Web.Blazor/Client/Web.Blazor.Client.csproj"
COPY . .

WORKDIR "/src/src/webapps/Web.Blazor/Client"
RUN dotnet build "Web.Blazor.Client.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "Web.Blazor.Client.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
COPY --from=publish /app/publish/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf