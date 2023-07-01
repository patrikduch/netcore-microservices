# Use the official Microsoft .NET 6.0 SDK image to build the project
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app

# Copy the whole solution
COPY . ./

RUN ls -la /app

ARG NUGET_PAT

# Set environment variables
ENV NUGET_CREDENTIALPROVIDER_SESSIONTOKENCACHE_ENABLED true
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS '{"endpointCredentials":[{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Dbs/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"},{"endpoint":"https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Configuration/nuget/v3/index.json","username":"NoRealUserNameAsIsNotRequired","password":"'${NUGET_PAT}'"}]}'

# Get and install the Artifact Credential provider
RUN wget -O - https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh  | bash


# Copy csproj and restore dependencies
COPY ./src/webapps/Web.Blazor/Client/Web.Blazor.Client.csproj src/webapps/Web.Blazor/Client/Web.Blazor.Client.csproj
# Restore your nugets from nuget.org and your private feed.
RUN dotnet restore -s "https://api.nuget.org/v3/index.json" -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Dbs/nuget/v3/index.json" -s "https://pkgs.dev.azure.com/duchpatrick/netmicroservices/_packaging/NetMicroservices.Configuration/nuget/v3/index.json" "src/webapps/Web.Blazor/Client/Web.Blazor.Client.csproj"

RUN dotnet publish -c Release -o out src/webapps/Web.Blazor/Client/Web.Blazor.Client.csproj

# Use the Nginx image to host our application
FROM nginx:alpine

WORKDIR /var/www/web

# Copy build output from build-env
COPY --from=build-env /app/out/wwwroot .

# Copy Nginx configuration
COPY nginx.conf /etc/nginx/nginx.conf